using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using CurseForgeClient.Extensions;
using System.Runtime.Caching;
using CurseForgeClient.Downloader;
using CurseForgeClient.CustomControl;

namespace CurseForgeClient
{
    public partial class MainForm : Form
    {
        private readonly ObjectCache _cache = MemoryCache.Default;
        private readonly List<string> _gameVersions = new List<string> 
        {
            "Все версии",
            "1.7.10",
            "1.12.2",
            "1.15.2",
            "1.16.5",
            "1.19.2"
        };
        private readonly Dictionary<string, string> _sortOrder = new()
        {
            { "По возрастанию", "asc" },
            { "По убыванию", "desc" },
        };
        private int PageHaveSeen { get; set; } = 0;
        private string DirectoryPath = string.Empty;
        private const int PageSize = 28;
        private string SortOrder = "asc";
        private SortField SortFieldName = SortField.Name;
        private int _page = 0;
        private string GameVersion = string.Empty;
        private static ModController _controller;
        private static List<Mod> _currentMods;
        public MainForm()
        {
            InitializeComponent();
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            foreach(var gameVersion in _gameVersions)
                gameVersionStripComboBox.Items.Add(gameVersion);
            foreach (SortField sortField in Enum.GetValues(typeof(SortField)))
                sortFieldStripComboBox.Items.Add(sortField.ToString());
            foreach(var sortOrder in _sortOrder.Keys)
                sortOrderStripComboBox.Items.Add(sortOrder.ToString());
            await Init();        
        }
        private async Task Init()
        {
            _controller = new ModController(new CurseClientContext());
            //_currentMods = await _controller.GetMods(sortOrder: SortOrder, pageSize: PageSize);
            _currentMods = await GetModsFromCacheOrFetch(gameVersion: GameVersion);
            _bindingSource.DataSource = _currentMods;
            _dataGridView.DataSource = _bindingSource;

            _dataGridView.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["Slug"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["ModLogo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //_dataGridView.Columns["Selection"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["Logo"].Visible = false;

            var selectionColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Selection",
                HeaderText = "Select",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DisplayIndex = 6,

            };
            _dataGridView.Columns.Insert(0, selectionColumn);

            for (int i = 0; i < _dataGridView.Columns.Count; i++)
            {
                if (_dataGridView.Columns[i].Name == "Selection")
                {
                    _dataGridView.Columns[i].ReadOnly = false;
                }
                else
                {
                    _dataGridView.Columns[i].ReadOnly = true;
                }
            }


            FetchImages();
        }
        private async Task<List<Mod>> GetModsFromCacheOrFetch(string slug = "",
            SortField sortField = SortField.Name,
            string sortOrder = "asc",
            string gameVersion = "")
        {
            // Create a cache key based on the current game version, page number, slug, sort field, and sort order
            string cacheKey = "ModsPage_" + gameVersion + "" + slug + "" + sortField + "" + sortOrder + "" + _page;
            string selectedModsCacheKey = "SelectedMods_" + GameVersion + "_" + _page;

            // Check if there's a cache entry for the current game version and page
            if (_cache[cacheKey] is List<Mod> mods)
            {
                //RestoreSelectionState();               

                if (_cache[selectedModsCacheKey] is Dictionary<int, Mod> selectedMods)
                {
                    foreach (DataGridViewRow row in _dataGridView.Rows)
                    {
                        Mod mod = (Mod)row.DataBoundItem;
                        if (selectedMods.ContainsKey(mod.Id))
                        {
                            row.Cells[_dataGridView.Columns["Selection"].Index].Value = true;
                        }
                    }
                }

                return mods;
            }

            // If there's no cache entry for the current game version and page, fetch the data
            mods = await _controller.GetMods(gameVersion: gameVersion, slug: slug,
                        sortField: sortField, sortOrder: sortOrder, index: _page * PageSize, pageSize: PageSize);

            // Add the fetched data to the cache with a 1 hour expiration time
            _cache.Add(cacheKey, mods, DateTime.Now.AddHours(1));

            // Return the fetched data
            return mods;
        }
        private void RestoreSelectionState()
        {
            string cacheKey = "SelectedMods_" + GameVersion + "_" + _page;
            if (_cache[cacheKey] is Dictionary<int, Mod> selectedMods)
            {
                foreach (DataGridViewRow row in _dataGridView.Rows)
                {
                    Mod mod = (Mod)row.DataBoundItem;
                    if (selectedMods.ContainsKey(mod.Id))
                    {
                        row.Cells[_dataGridView.Columns["Selection"].Index].Value = true;
                    }
                }
            }
            _dataGridView.Refresh();
            _dataGridView.Invalidate();
            _dataGridView.InvalidateColumn(_dataGridView.Columns["Selection"].Index);
        }
        private void FetchImages()
        {
            if (CheckImages())
                return;
            var task = new Task(async () =>
            {
                for (int i = 0; i < _currentMods.Count; i++)
                {
                    Mod mod = _currentMods[i];
                    mod.ModLogo = await _controller.DownloadImage(mod.Logo.Url);

                    mod.ModLogo = mod.ModLogo.Resize(new Size(32, 32));

                    _currentMods[i] = mod;
                }

                _dataGridView.Invoke((MethodInvoker)delegate
                {
                    _dataGridView.Refresh();
                    _dataGridView.Invalidate();
                    _dataGridView.InvalidateColumn(_dataGridView.Columns["ModLogo"].Index);
                });
            });

            task.Start();
        }
        private bool CheckImages()
        {
            foreach(var mod in _currentMods)
            {
                if (mod.ModLogo == null)
                    return false;
            }
            return true;
        }
        private void _dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            // Get the row index of the selected row
            int rowIndex = e.RowIndex;

            // Make sure a row was selected
            if (rowIndex >= 0)
            {
                // Get the selected Mod object
                Mod selectedMod = (Mod)_dataGridView.Rows[rowIndex].DataBoundItem;

                // Display the Mod.Id in a MessageBox
                MessageBox.Show(selectedMod.ToString());
            }
        }


        //TODO Пределать
        private async void nextStripButton_Click(object sender, EventArgs e)
        {
            if (_page + 1 + PageSize > 10000)
                return;
            _page++;
            PageHaveSeen++;
            await SetTable();
            _pageStripLabel.Text = _page.ToString();
        }

        private async void backStripButton_Click(object sender, EventArgs e)
        {
            _page--;
            if(_page < 1)
            {
                _page = 0;
                await SetTable();
                _pageStripLabel.Text = _page.ToString();
                return;
            }
            await SetTable();
            _pageStripLabel.Text = _page.ToString();
        }

        private async void gameVersionStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameVersion = (string)gameVersionStripComboBox.SelectedItem;
            if (GameVersion == "Все версии")
                GameVersion = string.Empty;
            await SetTable();
        }
        private async Task SetTable(
            string slug = "",
            SortField sortField = SortField.Name,
            string sortOrder = "asc")
        {

            //_currentMods = await _controller.GetMods(gameVersion: GameVersion, slug: slug,
            //        sortField: sortField, sortOrder: sortOrder, index: _page * PageSize, pageSize: PageSize);

            _currentMods = await GetModsFromCacheOrFetch(slug: slug,
                    sortField: SortFieldName, sortOrder: SortOrder, gameVersion: GameVersion);

            _bindingSource.DataSource = _currentMods;
            _bindingSource.ResetBindings(false);
            _dataGridView.DataSource = _bindingSource;

            RestoreSelectionState();

            FetchImages();
        }

        private async void sortFieldStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Enum.TryParse(sortFieldStripComboBox.SelectedItem as string, out SortField sortField))
            {
                SortFieldName = sortField;
                await SetTable(sortField: SortFieldName, sortOrder: SortOrder);
            }
        }

        private async void sortOrderStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedOrder = sortOrderStripComboBox.SelectedItem.ToString();
            SortOrder = _sortOrder[selectedOrder];
            await SetTable(sortOrder: SortOrder);
        }

        private void выбратьПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryPath = folderBrowserDialog.SelectedPath;
            }
        }

        private async void installModsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DirectoryPath == string.Empty)
                    throw new InvalidDataException("Choose directory path");

                var downloader = new ModDownloader(DirectoryPath);
                List<Mod> mods = new();

                for (int i = 0; i <= PageHaveSeen; i++)
                {
                    var selectedMods = (_cache["SelectedMods_" + GameVersion + "_" + i] as Dictionary<int, Mod>).Values.ToList();
                    mods.AddRange(selectedMods);
                }
              
                if (mods == null)
                    throw new NullReferenceException("Error occured while downloading mods");

                downloadingStripProgressBar.Minimum = 0;
                downloadingStripProgressBar.Maximum = 100;
                var progress = new ToolStripProgressBarUpdater(downloadingStripProgressBar);

                try
                {
                    await downloader.StartDownloading(mods, gameVersion: GameVersion, progress);
                    MessageBox.Show("Mods successfully installed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error installing mods: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    downloadingStripProgressBar.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while downloading mods {ex.Message} \n {ex.StackTrace}");
            }
        }

        private void _dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex].Name == "Selection")
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = _dataGridView.Rows[rowIndex];
                Mod mod = (Mod)row.DataBoundItem;

                bool isSelected = (bool)row.Cells[_dataGridView.Columns["Selection"].Index].Value;

                string cacheKey = "SelectedMods_" + GameVersion + "_" + _page;
                if (_cache[cacheKey] is Dictionary<int, Mod> selectedMods)
                {
                    if (isSelected)
                    {
                        selectedMods[mod.Id] = mod;
                    }
                    else
                    {
                        selectedMods.Remove(mod.Id);
                    }
                    _cache[cacheKey] = selectedMods;
                }
                else
                {
                    Dictionary<int, Mod> newSelectedMods = new Dictionary<int, Mod>();
                    if (isSelected)
                    {
                        newSelectedMods[mod.Id] = mod;
                    }
                    _cache[cacheKey] = newSelectedMods;
                }
            }
        }
        private void _dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void _dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_dataGridView.IsCurrentCellDirty)
            {
                _dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}

/*
    //await GetModAsync("238222");
    //await SearchModAsync();
    //await GetModFileAsync("775946", "4260213");
    //await DownloadFileAsync("https://edge.forgecdn.net/files/3040/523/jei_1.12.2-4.16.1.301.jar");
 */
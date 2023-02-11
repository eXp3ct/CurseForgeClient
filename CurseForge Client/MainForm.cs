using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using CurseForgeClient.Extensions;
using System.Runtime.Caching;
using CurseForgeClient.Downloader;

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
            _dataGridView.Columns["Logo"].Visible = false;

            var selectionColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Selection",
                HeaderText = "Select",
                DisplayIndex = 6,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
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

            // Check if there's a cache entry for the current game version and page
            if (_cache[cacheKey] is List<Mod> mods)
            {
                // If there is a cache entry, return the cached value
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
            List<Mod> selectedMods = new List<Mod>();

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selection"].Value))
                {
                    selectedMods.Add((Mod)row.DataBoundItem);
                }
            }

            var downloader = new ModDownloader(DirectoryPath);
            downloader.StartDownloading(selectedMods, gameVersion: GameVersion);
        }
    }
}

/*
    //await GetModAsync("238222");
    //await SearchModAsync();
    //await GetModFileAsync("775946", "4260213");
    //await DownloadFileAsync("https://edge.forgecdn.net/files/3040/523/jei_1.12.2-4.16.1.301.jar");
 */
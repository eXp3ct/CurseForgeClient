using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using System.Net;
using System.Windows.Forms;
using CurseForgeClient.Extensions;

namespace CurseForgeClient
{
    public partial class MainForm : Form
    {
        private const int PageSize = 28;
        private const string SortOrder = "asc";
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
            await Init();        
        }
        private async Task Init()
        {
            _controller = new ModController(new CurseClientContext());
            _currentMods = await _controller.GetMods(sortOrder: SortOrder, pageSize: PageSize);

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

        private void FetchImages()
        {
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
            if(_page <= 1)
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
            await SetTable();
        }
        private async Task SetTable(
            string slug = "",
            SortField sortField = SortField.Name,
            string sortOrder = SortOrder)
        {

            _currentMods = await _controller.GetMods(gameVersion: GameVersion, slug: slug,
                    sortField: sortField, sortOrder: sortOrder, index: _page * PageSize, pageSize: PageSize);
            _bindingSource.DataSource = _currentMods;
            _dataGridView.DataSource = _bindingSource;

            FetchImages();
        }

        private async void _dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (_dataGridView.Columns[e.ColumnIndex].Name == "Logo")
            {
                var mod = (Mod)_dataGridView.Rows[e.RowIndex].DataBoundItem;
                e.Value = await _controller.DownloadImage(mod.Logo.Url);
                e.FormattingApplied = true;
            }*/
        }

        private void _dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _dataGridView.Refresh();
        }
    }

}

/*
    //await GetModAsync("238222");
    //await SearchModAsync();
    //await GetModFileAsync("775946", "4260213");
    //await DownloadFileAsync("https://edge.forgecdn.net/files/3040/523/jei_1.12.2-4.16.1.301.jar");
 */
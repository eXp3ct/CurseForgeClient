using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using System.Net;
using System.Windows.Forms;
using CurseForgeClient.Extensions;

namespace CurseForgeClient
{
    public partial class MainForm : Form
    {
        private const int PageSize = 50;
        private const string SortOrder = "asc";
        private int _page = 0;
        private string GameVersion = string.Empty;
        private ModController _controller;
        private List<Mod> _currentMods;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();        
            

        }
        private async void Init()
        {
            _controller = new ModController(new CurseClientContext());
            _currentMods = await _controller.GetMods(sortOrder: SortOrder);
            
            /*foreach(var mod in _currentMods)
            {
                var image = await _controller.DownloadImage(mod.Logo.Url);
                mod.ModLogo = image;
            }*/
            //foreach(var mod in _currentMods)
            //    MessageBox.Show($"{mod.Logo.Url}");
            //_currentMods.ForEach(async mod => mod.ModLogo = await _controller.DownloadImage(mod.Logo.Url));

            //TODO оптимизировать
            for (int i = 0; i < _currentMods.Count; i++)
            {
                Mod mod = _currentMods[i];
                mod.LatestFiles = _currentMods[i].LatestFiles;
                mod.Logo = _currentMods[i].Logo;
                mod.Id = _currentMods[i].Id;
                mod.Summary = _currentMods[i].Summary;
                mod.Slug = _currentMods[i].Slug;

                mod.ModLogo = await _controller.DownloadImage(mod.Logo.Url);

                mod.ModLogo = mod.ModLogo.Resize(new Size(32,32));

                _currentMods[i] = mod;
            }

            _bindingSource.DataSource = _currentMods;
            _dataGridView.DataSource = _bindingSource;

            _dataGridView.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["Slug"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["ModLogo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dataGridView.Columns["Logo"].Visible = false;
                
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
        private void nextStripButton_Click(object sender, EventArgs e)
        {
            _page++;
            SetTable();
            _pageStripLabel.Text = _page.ToString();
        }

        private void backStripButton_Click(object sender, EventArgs e)
        {
            _page--;
            if(_page <= 1)
            {
                _page = 0;
                SetTable();
                _pageStripLabel.Text = _page.ToString();
                return;
            }
            SetTable();
            _pageStripLabel.Text = _page.ToString();
        }

        private void gameVersionStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameVersion = (string)gameVersionStripComboBox.SelectedItem;
            SetTable();
        }
        private async void SetTable(
            string slug = "",
            SortField sortField = SortField.Name,
            string sortOrder = SortOrder)
        {
            _currentMods = await _controller.GetMods(gameVersion: GameVersion, slug: slug,
                sortField: sortField, sortOrder: sortOrder, index: _page * PageSize);
            _bindingSource.DataSource = _currentMods;

            _dataGridView.DataSource = _bindingSource;
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
    }

}

/*
    //await GetModAsync("238222");
    //await SearchModAsync();
    //await GetModFileAsync("775946", "4260213");
    //await DownloadFileAsync("https://edge.forgecdn.net/files/3040/523/jei_1.12.2-4.16.1.301.jar");
 */
using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using System.Net;
using System.Windows.Forms;

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
            _bindingSource.DataSource = _currentMods;
            _dataGridView.DataSource = _bindingSource;

            //_dataGridView.Columns["Logo"].CellTemplate = new DataGridViewImageCell();
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
                foreach(var file in selectedMod.LatestFiles)
                {
                    MessageBox.Show($"FileId: {file.Id}| ModId: {file.ModId}");
                }
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
            if (_dataGridView.Columns[e.ColumnIndex].Name == "Links")
            {
                var mod = (Mod)_dataGridView.Rows[e.RowIndex].DataBoundItem;
                e.Value = mod.Links.WebSiteUrl;
                e.FormattingApplied = true;
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
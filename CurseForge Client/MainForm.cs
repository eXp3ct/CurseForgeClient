using CurseForgeClient.ApiClient;
using CurseForgeClient.Extensions;
using Newtonsoft.Json;

namespace CurseForgeClient
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            var controller = new ModController(new CurseClientContext());
            /*var mod = await controller.GetMod();
            MessageBox.Show($"{mod.Id} | {mod.Slug}");
*/
            /*var list = await controller.GetMods();

            foreach(var mod in list)
                MessageBox.Show($"{mod.Name} | {mod.DownloadUrl}");*/

            _bindingSource.DataSource = await controller.GetMods(gameVersion: "1.12.2", sortOrder: "desc");
            _dataGridView.DataSource = _bindingSource;
        }
    }
}

/*
    //await GetModAsync("238222");
    //await SearchModAsync();
    //await GetModFileAsync("775946", "4260213");
    //await DownloadFileAsync("https://edge.forgecdn.net/files/3040/523/jei_1.12.2-4.16.1.301.jar");
 */
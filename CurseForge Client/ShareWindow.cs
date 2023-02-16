using CurseForgeClient.Compression;
using CurseForgeClient.CustomControl;
using CurseForgeClient.Downloader;
using Server;
namespace CurseForgeClient
{
    public partial class ShareWindow : Form
    {
        private string DirectoryPath { get; set; }
        private Server.Program HostServer { get; set; }
        public ShareWindow(string directoryPath)
        {
            InitializeComponent();
            DirectoryPath = directoryPath;
            this.HostServer = new Server.Program("26.101.220.140");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var zipPath = Compressor.StartCompress(DirectoryPath);
            try
            {
                if(ipInput.Text == null)
                {
                    throw new ArgumentNullException(nameof(ipInput));
                }
                HostServer.Ip = ipInput.Text;
                Server.Program.FilePath = zipPath;
                await HostServer.RunServer();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                serverStatus.Text = "Сервер работает";
            }
        }

        private async void ShareWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await HostServer.StopServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                serverStatus.Text = "Сервер не работает";
            }
        }

        private async void downloadFromServer_Click(object sender, EventArgs e)
        {
            try
            {
                var folderInfo = new FolderBrowserDialog();
                var folder = string.Empty;
                if(folderInfo.ShowDialog() == DialogResult.OK)
                {
                    folder = folderInfo.SelectedPath;
                }
                await ApiDownloader.Download($"http://{ipInput.Text}:5051/mods", folder, progressBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                progressBar.Value = 0;
            }
        }
    }
}

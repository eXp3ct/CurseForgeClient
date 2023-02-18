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
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var zipPath = Compressor.StartCompress(DirectoryPath);
            try
            {
                if(string.IsNullOrEmpty(ipInput.Text))
                {
                    throw new ArgumentNullException(nameof(ipInput));
                }
                HostServer = new Server.Program(ipInput.Text);
                Server.Program.FilePath = zipPath;
                await HostServer.RunServer();
                serverStatus.Text = "Сервер работает";
                MessageBox.Show($"Сервер успешно запущен на IP: {HostServer.Ip}", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                serverStatus.Text = "Сервер не работает";
                MessageBox.Show(ex.ToString());
            }
        }

        private async void ShareWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HostServer == null)
                    return;
                await HostServer.StopServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                var zipPath = await ApiDownloader.Download($"http://{ipInput.Text}:5051/mods", folder, progressBar);
                Compressor.Decompress(zipPath);
                MessageBox.Show($"Моды успешно получены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

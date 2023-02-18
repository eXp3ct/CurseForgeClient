using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;

namespace CurseForgeClient.Downloader
{
    public class ModDownloader : FileDownloader, IModDownloader
    {

        public override string DirectoryPath { get; set; }

        public ModDownloader(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public async Task StartDownloading(List<Mod> mods, string gameVersion, IProgress<double> progress)
        {
            var controller = new ModController(new CurseClientContext());
            var dependeciesListString = "";
            var dependeciesList = new List<Mod>();
            long totalBytes = 0;
            foreach (var mod in mods)
            {
                var files = await controller.GetModFiles(mod.Id, gameVersion: gameVersion, modLoaderType: ModLoaderType.Forge, pageSize: 5);
                totalBytes += files.Sum(f => f.FileLength);
            }
            var bytesDownloaded = 0L;
            foreach (var mod in mods)
            {
                var files = await controller.GetModFiles(mod.Id, gameVersion: gameVersion, modLoaderType: ModLoaderType.Forge, pageSize: 5);
                var file = files.FirstOrDefault();
                var dependeciesId = new List<int>();
                if(file.Dependencies.Count > 0)
                {
                    foreach (var dep in file.Dependencies)
                    {
                        dependeciesId.Add(dep.ModId);
                    }
                }
                if(dependeciesId.Count > 0)
                {
                    foreach(var id in dependeciesId)
                    {
                        var dependenceMod = await controller.GetMod(id);
                        if (dependeciesList.Contains(dependenceMod))
                            continue;
                        dependeciesList.Add(dependenceMod);
                        dependeciesListString += dependenceMod.Name + "\n";
                    }
                    
                }
                await Download(file.DownloadUrl, file.FileName, new Progress<double>(p =>
                {
                    bytesDownloaded += (long)(p * file.FileLength);
                    var progressValue = (double)bytesDownloaded / totalBytes;
                    if (progressValue < 0)
                    {
                        progressValue = 0;
                    }
                    if (progressValue > 1)
                    {
                        progressValue = 1;
                    }
                    progress.Report(progressValue);
                }));
            }
            if(dependeciesList.Count > 0)
            {
                var downloadDependeciedDialog = MessageBox.Show($"Найдены следующие зависимости для выбранных модов, скачать их? \n{dependeciesListString}", "Зависимости",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (downloadDependeciedDialog == DialogResult.OK)
                {
                    await DownloadDependecies(gameVersion, controller, dependeciesList);
                }
            }
        }

        private async Task DownloadDependecies(string gameVersion, ModController controller, List<Mod> dependeciesList)
        {
            foreach (var dependenceMod in dependeciesList)
            {
                var dependenceModFiles = await controller.GetModFiles(dependenceMod.Id, gameVersion: gameVersion, modLoaderType: ModLoaderType.Forge, pageSize: 5);
                var dependenceModFile = dependenceModFiles.FirstOrDefault();

                await Download(dependenceModFile.DownloadUrl, dependenceModFile.FileName, new Progress<double>(p =>
                {

                }));
            }
        }
    }
}

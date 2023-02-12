using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}

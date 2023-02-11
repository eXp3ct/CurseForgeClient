using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.Downloader
{
    public class ModDownloader : IModDownloader
    {
        public string DirectoryPath { private get; set; }

        public ModDownloader(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        private async Task Download(string url, string fileName)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var path = Path.Combine(DirectoryPath, $"{fileName}");
            using var fileStream = new FileStream(path,
                FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            await response.Content.CopyToAsync(fileStream);
        }

        public async Task StartDownloading(List<Mod> mods, string gameVersion)
        {
            var controller = new ModController(new CurseClientContext());
            foreach (var mod in mods)
            {
                var files = await controller.GetModFiles(mod.Id, gameVersion: gameVersion, modLoaderType: ModLoaderType.Forge, pageSize: 5);
                var file = files.FirstOrDefault();
                await Download(file.DownloadUrl, file.FileName);
            }
        }
    }
}

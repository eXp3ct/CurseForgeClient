using CurseForgeClient.ApiClient;
using CurseForgeClient.Model;
using System;
using System.Collections.Generic;
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

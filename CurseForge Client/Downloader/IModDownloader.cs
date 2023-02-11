using CurseForgeClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.Downloader
{
    public interface IModDownloader
    {
        public Task StartDownloading(List<Mod> mods, string gameVersion);
    }
}

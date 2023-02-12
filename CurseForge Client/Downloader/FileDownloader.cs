using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.Downloader
{
    public abstract class FileDownloader
    {
        public abstract string DirectoryPath { get; set; }
        public async Task Download(string url, string fileName)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var path = Path.Combine(DirectoryPath, $"{fileName}");
            using var fileStream = new FileStream(path,
                FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            await response.Content.CopyToAsync(fileStream);
        }
    }
}

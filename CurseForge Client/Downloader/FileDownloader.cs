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
        public async Task Download(string url, string fileName, IProgress<double> progress)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var totalBytes = response.Content.Headers.ContentLength;
            var path = Path.Combine(DirectoryPath, $"{fileName}");
            using var fileStream = new FileStream(path,
                FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);

            var totalBytesRead = 0L;
            var buffer = new byte[4096];
            var bytesRead = await (await response.Content.ReadAsStreamAsync()).ReadAsync(buffer);
            while (bytesRead > 0)
            {
                await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
                totalBytesRead += bytesRead;
                progress.Report((double)totalBytesRead / (double)totalBytes);
                bytesRead = await (await response.Content.ReadAsStreamAsync()).ReadAsync(buffer);
            }
        }

    }
}

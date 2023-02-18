using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.Downloader
{
    public class ApiDownloader
    {
        public static async Task<string> Download(string url, string destPath, ProgressBar progressBar)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/octet-stream"));
            using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var fileSize = response.Content.Headers.ContentLength;
            var buffer = new byte[8192];
            var totalBytesRead = 0;
            using var contentStream = await response.Content.ReadAsStreamAsync();
            var zipPath = Path.Combine(destPath, "mods.zip");
            using var fileStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            while (true)
            {
                var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    break;
                }
                await fileStream.WriteAsync(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;
                var progressPercentage = (double)totalBytesRead / fileSize * 100;
                progressBar.Value = (int)progressPercentage;
            }
            return zipPath;
        }
    }
}

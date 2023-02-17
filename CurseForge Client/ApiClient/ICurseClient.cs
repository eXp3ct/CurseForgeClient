using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.ApiClient
{
    public interface ICurseClient
    {
        private const string JsonFolder = @"D:\\Projects\\C# Projects\\CurseForge Client\\CurseForge Client\\debugJson";
        public Task<string> GetModAsync(int modId);
        public Task<string> SearchModAsync(
            string gameVersion = "",
            string slug = "",
            int index = 0,
            SortField sortField = SortField.Name,
            string sortOrder = "asc",
            int pageSize = 10,
            int? categoryId = null);
        public Task<string> GetModFileAsync(int modId, int fileId);
        public static bool ConnectionStatus(HttpResponseMessage response) => response.IsSuccessStatusCode;
        public static async Task ResponseToJson(HttpResponseMessage response, bool search = false, bool getFile = false)
        {
            string json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(json);

            string fileName;
            if (search)
                fileName = "mods.json";
            else if (getFile)
                fileName = result.data.displayName + ".json";
            else
                fileName = result.data.slug + ".json";
            string path = Path.Combine(JsonFolder, fileName);
            File.WriteAllText(path, JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        public Task<string> GetModFiles(int modId, string gameVersion = "", ModLoaderType modLoaderType = ModLoaderType.Forge, int index = 0,
            int pageSize = 50);
        public Task<byte[]> FetchImage(string url);
        public Task<string> GetCategories();

    }
}

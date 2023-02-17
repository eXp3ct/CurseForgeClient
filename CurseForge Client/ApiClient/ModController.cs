using CurseForgeClient.Extensions;
using CurseForgeClient.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.ApiClient
{
    public class ModController
    {
        private readonly ICurseClient _client;
        public ModController(ICurseClient client)
        {
            _client = client;
        }


        public async Task<Mod> GetMod(int modId = 0)
        {
            var json = await _client.GetModAsync(modId);
            var result = JsonConvert.DeserializeObject<ModData>(json);

            return result.Data;
        }

        public async Task<List<Mod>> GetMods(
            string gameVersion = "",
            string slug = "",
            int index = 0,
            SortField sortField = SortField.Name,
            string sortOrder = "asc", int pageSize = 10, int? categoryId = null)
        {
            var jsonString = await _client.SearchModAsync(gameVersion: gameVersion, slug: slug,
                index: index, sortField: sortField, sortOrder: sortOrder, pageSize: pageSize, categoryId: categoryId);
            var mods = JsonConvert.DeserializeObject<ModsData>(jsonString);
            var modsList = new List<Mod>(mods.Data.Count);

            foreach(var mod in mods.Data)
                modsList.Add(mod);

            return modsList;
        }

        public async Task<Image> DownloadImage(string url)
        {
            var imageBytes = await _client.FetchImage(url);

            return Image.FromStream(new MemoryStream(imageBytes));
        }

        public async Task<List<ModFile>> GetModFiles(int modId, string gameVersion = "", ModLoaderType modLoaderType = ModLoaderType.Forge, int index = 0,
            int pageSize = 50)
        {
            var jsonString = await _client.GetModFiles(modId: modId, gameVersion: gameVersion, 
                modLoaderType: modLoaderType, index: index, pageSize: pageSize);

            var modFiles = JsonConvert.DeserializeObject<ModFiles>(jsonString);
            var filesList = new List<ModFile>(modFiles.Data.Count);

            foreach(var file in modFiles.Data)
                filesList.Add(file);

            return filesList;

        }
        public async Task<List<Category>> GetCategories()
        {
            var jsonString = await _client.GetCategories();

            var categories = JsonConvert.DeserializeObject<Categories>(jsonString);
            var categoriesList = new List<Category>(categories.Data.Count);

            foreach(var category in categories.Data)
                categoriesList.Add(category);

            return categoriesList;
        }
    }
    
}

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


        public async Task<Mod> GetMod(string modId = "")
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
            string sortOrder = "asc")
        {
            var jsonString = await _client.SearchModAsync(gameVersion: gameVersion, slug: slug,
                index: index, sortField: sortField, sortOrder: sortOrder);
            var mods = JsonConvert.DeserializeObject<ModsData>(jsonString);
            var modsList = new List<Mod>(mods.Data.Count);

            foreach(var mod in mods.Data)
                modsList.Add(mod);

            return modsList;
        }

       
    }
    
}

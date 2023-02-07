using CurseForgeClient.Extensions;
using Newtonsoft.Json;

namespace CurseForgeClient.ApiClient
{
    public class CurseClientContext : ICurseClient
    {
        private const string ApiKey = "$2a$10$ELJ0FcxFLTXGmPRWzynsYOj051DwZtEuuyK8ALgZUho3CIuYbvQZS";
        private const string BaseUrl = "https://api.curseforge.com";
        private readonly Dictionary<string, string> Headers = new()
        {
            { "Accept", "application/json" },
            { "x-api-key", ApiKey }

        };
        private readonly Dictionary<string, string> Endpoints = new()
        {
            { "GetMod", "/v1/mods/" },
            { "SearchMod", "/v1/mods/search" },
        };
        public CurseClientContext()
        {

        }
        public async Task<string> GetModAsync(string modId)
        {
            using var client = new HttpClient();
            client.AddHeaders(Headers);

            using var response = await client.GetAsync($"{BaseUrl}{Endpoints["GetMod"]}{modId}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> SearchModAsync(
            string gameVersion = "",
            string slug = "",
            int index = 0,
            SortField sortField = SortField.Name,
            string sortOrder = "asc")
        {
            using var client = new HttpClient();
            client.AddHeaders(Headers);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}{Endpoints["SearchMod"]}");
            foreach (var header in Headers)
                request.Headers.Add(header.Key, header.Value);

            var queryParams = new Dictionary<string, string>
            {
                { "gameId", "432" },
                { "classId", "6" },
                { "gameVersion", gameVersion },
                { "slug", slug },
                { "index", index.ToString() },
                { "sortField", sortField.ToString() },
                { "sortOrder", sortOrder },
                { "pageSize", "50" },
            };
            var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            request.RequestUri = new Uri($"{request.RequestUri}?{queryString}");

            var response = await client.SendAsync(request);
            
            return await response.Content.ReadAsStringAsync();

        }
        public async Task<string> GetModFileAsync(string modId, string fileId)
        {
            using var client = new HttpClient();
            client.AddHeaders(Headers);

            var queryString = $"{BaseUrl}/v1/mods/{modId}/files/{fileId}";
            using var response = await client.GetAsync(queryString);

            return await response.Content.ReadAsStringAsync();
        }
    }
}

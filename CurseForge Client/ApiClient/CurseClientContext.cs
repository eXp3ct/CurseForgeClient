﻿using CurseForgeClient.Extensions;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Windows.Forms;
using System;
using System.Reflection;

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
        public async Task<string> GetModAsync(int modId)
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
            string sortOrder = "asc",
            int pageSize = 10,
            int? categoryId = null)
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
                { "pageSize", pageSize.ToString() },
                { "modLoaderType", ((int)ModLoaderType.Forge).ToString() },
                { "categoryId", categoryId.ToString() },
            };
            var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            //var queryString = $"gameId={432}&classId={6}&index={0}&pageSize={500}";
            request.RequestUri = new Uri($"{request.RequestUri}?{queryString}");

            var response = await client.SendAsync(request);
            
            return await response.Content.ReadAsStringAsync();

        }
        public async Task<string> GetModFileAsync(int modId, int fileId)
        {
            using var client = new HttpClient();
            client.AddHeaders(Headers);

            var queryString = $"{BaseUrl}/v1/mods/{modId}/files/{fileId}";
            using var response = await client.GetAsync(queryString);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<byte[]> FetchImage(string url)
        {
            byte[] image;

            using var client = new HttpClient();
            try
            {
                image = await client.GetByteArrayAsync(url);
                return image;
            }
            catch (Exception)
            {

                MessageBox.Show($"{url}");
            }

            return new byte[] { };
        }

        public async Task<string> GetModFiles(int modId, string gameVersion = "", ModLoaderType modLoaderType = ModLoaderType.Forge, int index = 0,
            int pageSize = 50)
        {
            //v1/mods/{modId}/files
            using var client = new HttpClient();
            client.AddHeaders(Headers);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/v1/mods/{modId}/files");
            foreach (var header in Headers)
                request.Headers.Add(header.Key, header.Value);

            var queryParams = new Dictionary<string, string>
            {
                { "gameVersion", gameVersion },
                { "modLoaderType", ((int)modLoaderType).ToString()},
                { "index", index.ToString()},
                { "pageSize", pageSize.ToString()},
            };
            var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            //var queryString = $"gameId={432}&classId={6}&index={0}&pageSize={500}";
            request.RequestUri = new Uri($"{request.RequestUri}?{queryString}");

            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCategories()
        {
            using var client = new HttpClient();
            client.AddHeaders(Headers);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/v1/categories");
            foreach (var header in Headers)
                request.Headers.Add(header.Key, header.Value);

            var queryParams = new Dictionary<string, string>
            {
                { "gameId", "432"},
                { "classId", "6"},
            };
            var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            //var queryString = $"gameId={432}&classId={6}&index={0}&pageSize={500}";
            request.RequestUri = new Uri($"{request.RequestUri}?{queryString}");

            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}

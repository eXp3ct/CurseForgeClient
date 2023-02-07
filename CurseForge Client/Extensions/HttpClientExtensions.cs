namespace CurseForgeClient.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHeaders(this HttpClient client, Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }
}

namespace Server
{
    public class Program
    {
        public string Ip { get; set; }
        public static string FilePath { get; set; }
        private static IHost? _host;
        public Program(string ip)
        {
            Ip = ip;

            _host = Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseUrls($"http://{Ip}:5051");
                webBuilder.UseStartup<Startup>();
            })
            .Build();
        }
        public static void Main(string[] args)
        {

        }
        public async Task RunServer()
        {
            await _host.StartAsync();
        }
        public async Task StopServer()
        {
            if (_host != null)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
                _host.Dispose();
            }
        }
    }
}
using Microsoft.AspNetCore.Builder;

namespace Server
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders();
            app.UseStaticFiles();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var ip = context.Connection.RemoteIpAddress.ToString();
                //Console.WriteLine($"Request from IP address: {ip}");
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}

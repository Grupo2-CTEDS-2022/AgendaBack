using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using DotNetEnv;

namespace AgendaBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}

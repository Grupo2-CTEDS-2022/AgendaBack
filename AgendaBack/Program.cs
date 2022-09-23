using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AgendaBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
            CreateHostBuilder(args).Build().Run();
=======


            int id = 00000;
            User usuario = new User()
            {
                Id = id,
            };
            var json = EventRepository.ReadEvents(usuario);
            Console.WriteLine(json);
>>>>>>> 069479f0f0ea01dd80e673510ddddfc93b5d47f6
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

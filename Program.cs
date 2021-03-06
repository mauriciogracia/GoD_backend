using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GoD_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            prepareGameEngine();
            CreateHostBuilder(args).Build().Run();
        }

        private static void prepareGameEngine()
        {
            MovementsGameEngine mge ;
            string filePath ;
            bool rulesLoaded ;

            mge = new MovementsGameEngine();
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "gameEngine", "PaperRockScissors.json");
            rulesLoaded = mge.Init(filePath);
            Console.WriteLine(String.Format(">>GoD-Backend: {0} rulesLoaded: {1}", filePath, rulesLoaded));
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

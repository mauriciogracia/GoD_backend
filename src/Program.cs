using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GoD_backend
{
    public class Program
    {
        public static IGameEngine mge ;
        private static string rulesFile = "SheldonRules.json" ; //"PaperRockScissors.json"
        public static void Main(string[] args)
        {
            CustomLogger.Init(Path.Combine(Directory.GetCurrentDirectory(), "backendLog.txt")) ;
            GameSettings.loadEngine(rulesFile) ;
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

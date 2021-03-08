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
            IGameEngine mge ;
            string filePath ;

            filePath = Path.Combine(GameSettings.getGameEngineFolder(), "PaperRockScissors.json");

            mge = GameEngineFactory.Create(GameEngineType.MoveGameEngine, filePath);

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

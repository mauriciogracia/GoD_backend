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
            
            CustomLogger.Init(Path.Combine(Directory.GetCurrentDirectory(), "backendLog.txt")) ;

            filePath = Path.Combine(GameSettings.getGameEngineFolder(), "PaperRockScissors.json");
            CustomLogger.WriteLine(String.Format("GameSettings: {0}", filePath)) ;

            mge = GameEngineFactory.Create(GameEngineType.MoveGameEngine, filePath);
            CustomLogger.WriteLine("GameEngine has been created");
            
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

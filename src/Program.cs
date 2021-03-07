using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GoD_backend
{
    public class Program
    {
        //TODO: change this to some logic or to json settings
        public static string BACKEND_FOLDER = @"D:\MAO\repos\GoD_backend\src\gameEngine\" ;
        public static void Main(string[] args)
        {
            IGameEngine mge ;
            string filePath ;

            filePath = Path.Combine(BACKEND_FOLDER, "PaperRockScissors.json");

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

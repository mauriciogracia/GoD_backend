using System;
using System.Collections.Generic;
using System.IO;

namespace GoD_backend
{
    public class GameSettings {
        public List<GameRule> rules { set; get ;}
        public static IGameEngine currentGameEngine ;
        public static string getGameEngineFolder() {
            const string rootFolder = "GoD_backend\\" ;
            string folder ;

            var x = Directory.GetCurrentDirectory() ;
            var index = x.IndexOf(rootFolder) ;
            
            if(index > 0)
            {
                folder = Path.Combine(x.Substring(0, index + rootFolder.Length),"src","gameEngine") ;
            }
            else {
                folder = Path.Combine(x,"gameEngine") ;
            }

            return folder ;
        }

        public static void loadEngine(string jsonFile){
            string filePath ;
            
            filePath = Path.Combine(GameSettings.getGameEngineFolder(), jsonFile);
            currentGameEngine = GameEngineFactory.Create(GameEngineType.MoveGameEngine, filePath);
            CustomLogger.WriteLine(String.Format("GameEngine has been created: {0}", filePath)) ;
        }
    }
}
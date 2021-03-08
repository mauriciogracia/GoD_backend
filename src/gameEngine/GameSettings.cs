using System.Collections.Generic;
using System.IO;

namespace GoD_backend
{
    public class GameSettings {
        public List<GameRule> rules { set; get ;}

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
    }
}
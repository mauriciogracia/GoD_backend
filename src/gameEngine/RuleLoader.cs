using System;
using System.Collections.Generic;
using System.IO;
using GoD_backend;
using Newtonsoft.Json;

namespace GoD_backend
{
    public class RuleLoader {
        public GameSettings gr ;
        public RuleLoader(String jsonFile){
            init(jsonFile) ;
        }
        private void init(String jsonFile) {
            gr = null ;

            try
            {
                String jsonContent = File.ReadAllText(Path.Combine(getGameEngineFolder(), jsonFile));
                gr = JsonConvert.DeserializeObject<GameSettings>(jsonContent);

                if(isValidGameSettingsRules())
                {
                    gr.moves = new List<string>() ;

                    //Build the possible moves from the rules
                    foreach (GameRule gameRule in gr.rules)
                    {
                        if( ! gr.moves.Contains(gameRule.move)) {
                            gr.moves.Add(gameRule.move);
                        }
                        if( ! gr.moves.Contains(gameRule.beats)) {
                            gr.moves.Add(gameRule.beats);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //_logger.WriteLine(ex.Message);
            }
        }
        private bool isValidGameSettingsRules() {
            return ((gr != null) && (gr.rules != null));
        }
        
        public string getGameEngineFolder() {
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
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json ;
using System.Linq;

namespace GoD_backend
{
    public class MoveGameEngine : IGameEngine {
        private GameSettings gameSettings = null;
        private List<String> gameMoves = null ;
        internal MoveGameEngine(String pathToJsonRules){
            try
            {
                String jsonContent = File.ReadAllText(pathToJsonRules);
                gameSettings = JsonConvert.DeserializeObject<GameSettings>(jsonContent);

                if (isValidGameSettingsRules())
                {
                    gameMoves = new List<string>() ;

                    //Build the possible moves from the rules
                    foreach (GameRule gameRule in this.gameSettings.rules)
                    {
                        if( ! gameMoves.Contains(gameRule.move)) {
                            gameMoves.Add(gameRule.move);
                        }
                        if( ! gameMoves.Contains(gameRule.beats)) {
                            gameMoves.Add(gameRule.beats);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public GameSettings getGameSettings() {
            return gameSettings;
        }
        public List<String> getPossibleMoves() {
            return gameMoves ;
        }

        public bool isValidMove(string move) {
            bool? isValid = gameMoves?.Exists(m => m.ToUpper() == move.Trim().ToUpper()) ;

            return (isValid.HasValue ? isValid.Value : false)  ;
        }

        private bool isValidGameSettingsRules() {
            return ((this.gameSettings != null) && (this.gameSettings.rules != null));
        }

        public int determineResult(String movePlayerOne, String movePlayerTwo) {
            int moveResult ;

            //when no matching rule is found a TIE is assumed (i.e. rock vs rock)
            moveResult = 0 ;

            if (isValidGameSettingsRules())
            {
                var wins = this.gameSettings.rules.SingleOrDefault(x => (x.move == movePlayerOne) && (x.beats == movePlayerTwo));

                moveResult = (wins != null) ? 1 : 0;

                if(moveResult == 0) {
                    var loses = this.gameSettings.rules.SingleOrDefault(x => (x.move == movePlayerTwo) && (x.beats == movePlayerOne));

                    moveResult = (loses != null) ? -1 : 0;
                }
            }

            return moveResult ;
        }
    }
}
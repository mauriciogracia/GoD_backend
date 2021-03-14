using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json ;
using System.Linq;

namespace GoD_backend
{
    public class MoveGameEngine : IGameEngine {
        private GameSettings gameSettings = null;
        public MoveGameEngine(){

        }
        public GameSettings getGameSettings() {
            return gameSettings;
        }

        public void setGameSettings(GameSettings gs) {
            this.gameSettings = gs;
        }
        public List<String> getPossibleMoves() {
            CustomLogger.WriteLine("gameMoves:") ;
            this.gameSettings.moves.ForEach(i => CustomLogger.WriteLine(i));

            return this.gameSettings.moves ;
        }

        public bool isValidMove(string move) {
            bool? isValid = this.gameSettings.moves?.Exists(m => m.ToUpper() == move.Trim().ToUpper()) ;

            return (isValid ?? false)  ;
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
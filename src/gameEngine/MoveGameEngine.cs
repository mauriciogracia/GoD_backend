using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json ;
using System.Linq;

public class MoveGameEngine : IGameEngine {
    private GameSettings gameSettings = null;

    
    internal MoveGameEngine(String pathToJsonRules){
        try
        {
            String jsonContent = File.ReadAllText(pathToJsonRules);
            gameSettings = JsonConvert.DeserializeObject<GameSettings>(jsonContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public GameSettings getGameSettings() {
        return this.gameSettings;
    }
    public List<String> getPossibleMoves() {
        List<String> gameMoves ;

        gameMoves = new List<String>();

        if (isValidGameSettingsRules())
        {
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

        return gameMoves ;
    }

    private bool isValidGameSettingsRules() {
        return ((this.gameSettings != null) && (this.gameSettings.rules != null));
    }

    public int determinResult(String movePlayerOne, String movePlayerTwo) {
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
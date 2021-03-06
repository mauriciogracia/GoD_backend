using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json ;

public class MoveGameEngine : IGameEngine {
    private GameSettings gameSettings = null;

    
    public MoveGameEngine(String pathToJsonRules){
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

        if ((this.gameSettings != null) && (this.gameSettings.rules != null))
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

    public int determinResult(String movePlayerOne, String movePlayerTwo) {
        int moveResult ;

        //when no matching rule is found a TIE is assumed (i.e. rock vs rock)
        moveResult = 0 ;

        return moveResult ;
    }
}
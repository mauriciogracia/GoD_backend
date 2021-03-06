using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json ;

public class MovementsGameEngine : IGameEngine {
    public bool Init(String pathToJsonRules){
        bool rulesLoaded ;

        rulesLoaded = false ;

        try
        {
            String jsonContent = File.ReadAllText(pathToJsonRules);
            GameSettings gameSettings = JsonConvert.DeserializeObject<GameSettings>(jsonContent);
            rulesLoaded = gameSettings.rules != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return rulesLoaded ;
    }

    public List<String> getPossibleMoves() {
        List<String> gameMoves ;

        gameMoves = new List<String>();

        return gameMoves ;
    }

    public int determinResult(String movePlayerOne, String movePlayerTwo) {
        int moveResult ;

        //when no matching rule is found a TIE is assumed (i.e. rock vs rock)
        moveResult = 0 ;

        return moveResult ;
    }
}
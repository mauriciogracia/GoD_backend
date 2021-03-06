using System;
using System.Collections.Generic;

public interface IGameEngine {
    /// <summary>
    /// Initializes the games engine loading the json file path
    /// </summary>
    /// <param name="pathToJsonRules"></param>
    /// <returns>True when the rules where loaded correctly</returns>
    bool Init(String pathToJsonRules);

    /// <summary>
    /// Gets the possible moves from the game engine
    /// </summary>
    /// <returns>A list of posible moves for the game</returns>
    List<String> getPossibleMoves() ;

    /// <summary>
    /// This metod should return
    /// 
    /// +1 when movePlayerOne beats movePlayerTwo
    ///  0 when movePlayerOne ties with movePlayerTwo
    /// -1 when movePlayerOne loses to movePlayerTwo
    /// </summary>
    /// <param name="movePlayerOne">Move made by player one</param>
    /// <param name="movePlayerTwo">Move made by player two</param>
    /// <returns></returns>
    int determinResult(String movePlayerOne, String movePlayerTwo) ;
}
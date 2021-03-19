using System;
using System.Collections.Generic;

namespace GoD_backend
{
    public interface IGameEngine {
        /// <summary>
        /// Returns the current gameSettings of the game
        /// </summary>
        /// <returns></returns>
        GameSettings getGameSettings();

        /// <summary>
        /// Sets current gameSettings of the game
        /// </summary>
        /// <returns></returns>
        void setGameSettings(GameSettings value);

        /// <summary>
        /// Gets the possible moves from the game engine
        /// </summary>
        /// <returns>A list of posible moves for the game</returns>
        List<String> getPossibleMoves() ;

        bool isValidMove(string move) ;
        /// <summary>
        /// This metod should return
        /// 
        ///  1 when movePlayerOne beats movePlayerTwo
        ///  0 when movePlayerOne ties with movePlayerTwo
        /// -1 when movePlayerOne loses to movePlayerTwo
        /// </summary>
        /// <param name="movePlayerOne">Move made by player one</param>
        /// <param name="movePlayerTwo">Move made by player two</param>
        /// <returns></returns>
        int determineResult(String movePlayerOne, String movePlayerTwo) ;
    }
}
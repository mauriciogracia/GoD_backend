using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoD_backend.Controllersd
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameStatsRepository gameStatsRepo ;

        public GameController(GameStatsContext context)
        {
            gameStatsRepo = new GameStatsRepository(context);
        }

        [HttpGet("GetPossibleMoves")]
        public IEnumerable<String> GetPossibleMoves()
        {
            List<String> allMoves ;

            if(GameSettings.currentGameEngine != null) {
                allMoves = GameSettings.currentGameEngine.getPossibleMoves() ;
                Response.StatusCode = StatusCodes.Status200OK ;
            }
            else {
                allMoves = null ;
                Response.StatusCode = StatusCodes.Status204NoContent ;
            }
           
            return allMoves;
        }

        [HttpPost("DetermineResult/{movePlayerOne}/{movePlayerTwo}")]
        public int DetermineResult([FromRoute]string movePlayerOne, [FromRoute]string movePlayerTwo)
        {
            // Check that the parameters are valid moves 


            
            // TODO return FAILUR when parameters dont match expected input
            return GameSettings.currentGameEngine.determineResult(movePlayerOne, movePlayerTwo) ;
        }

        [HttpGet("GetGameStats")]
        public IEnumerable<GameStats> GetGameStats()
        {
            return gameStatsRepo.GetAll();
        }

        [HttpPut("UpdateGameStats")]
        public bool UpdateGameStats([FromBody]GameStats gameStats)
        {
             return gameStatsRepo.Update(gameStats);
        }
    }
}

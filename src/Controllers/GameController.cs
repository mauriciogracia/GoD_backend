using System;
using System.Collections.Generic;
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
            return GameSettings.currentGameEngine.getPossibleMoves();
        }

        [HttpPost("DetermineResult/{movePlayerOne}/{movePlayerTwo}")]
        public int DetermineResult([FromRoute]string movePlayerOne, [FromRoute]string movePlayerTwo)
        {
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

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GoD_backend.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
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

        [HttpGet("DetermineResult")]
        public int DetermineResult(string movePlayerOne, string movePlayerTwo)
        {
            return GameSettings.currentGameEngine.determineResult(movePlayerOne, movePlayerTwo) ;
        }

        [HttpGet("GetGameStats")]
        public IEnumerable<GameStats> GetGameStats()
        {
            return gameStatsRepo.GetAll();
            //return await _context.GameStatsItems.ToListAsync();
        }

        [HttpPut]
        public bool PutGameStats(GameStats gameStats)
        {
             return gameStatsRepo.Update(gameStats);
        }
    }
}

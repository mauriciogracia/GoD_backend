using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoD_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStatsController : ControllerBase
    {
        private readonly GameStatsRepository gameStatsRepo ;

        public GameStatsController(GameStatsContext context)
        {
            gameStatsRepo = new GameStatsRepository(context);
        }

        // GET: api/GameStats
        [HttpGet]
        public IEnumerable<GameStats> GetAllStats()
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

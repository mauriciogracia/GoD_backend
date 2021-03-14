using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoD_backend ;

namespace GoD_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStoreGameStats _gameStatsRepo ;
        public StatsController(IStoreGameStats gameStatsRepo)
        {
            _gameStatsRepo = gameStatsRepo ;
        }
       
        [HttpGet("GetAll")]
        public IEnumerable<GameStats> GetAll()
        {
            return _gameStatsRepo.GetAll();
        }

        [HttpPut("Update")]
        public bool Update([FromBody]GameStats gameStats)
        {
            bool updated ;

            updated = _gameStatsRepo.Update(gameStats);

            if(updated) {
                Response.StatusCode = StatusCodes.Status200OK ;
            }
            else {
                Response.StatusCode = StatusCodes.Status400BadRequest ;
            }

            return updated ;
        }
    }
}

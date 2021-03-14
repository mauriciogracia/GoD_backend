using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoD_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        IGameEngine _aGameEngine ;

        public GameController(IGameEngine aGameEngine)
        {
            RuleLoader rl ;

            _aGameEngine = aGameEngine ;
            rl = new RuleLoader("SheldonRules.json") ;
            _aGameEngine.setGameSettings(rl.gr) ;
        }

        [HttpGet("GetPossibleMoves")]
        public IEnumerable<String> GetPossibleMoves()
        {
            List<String> allMoves ;

            allMoves = _aGameEngine.getPossibleMoves() ;
            Response.StatusCode = StatusCodes.Status200OK ;
           
            return allMoves;
        }

        [HttpPost("DetermineResult/{movePlayerOne}/{movePlayerTwo}")]
        public int DetermineResult([FromRoute]string movePlayerOne, [FromRoute]string movePlayerTwo)
        {
            int resp ;

            // Check that the parameters are valid moves 
            if((_aGameEngine != null) && _aGameEngine.isValidMove(movePlayerOne) && _aGameEngine.isValidMove(movePlayerTwo))
            {
                resp = _aGameEngine.determineResult(movePlayerOne, movePlayerTwo) ;
                Response.StatusCode = StatusCodes.Status200OK ;
            }
            else {
                resp = -999 ;
                Response.StatusCode = StatusCodes.Status400BadRequest ;
            }
            
            return resp ;
        }
    }
}

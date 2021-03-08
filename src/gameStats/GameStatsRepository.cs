using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GoD_backend
{
    public class GameStatsRepository : IStoreGameStats {
        private readonly GameStatsContext _context;

        public GameStatsRepository(GameStatsContext context)
        {
            _context = context;
        }

        public bool Update(GameStats gameStats){
            bool success ;

            try {
                var gsFound = _context.GameStatsItems.FirstOrDefault(gs => gs.playerName.ToUpper() == gameStats.playerName.ToUpper());

                //update the stats for existing player
                if (gsFound != null)
                {
                    gsFound.gamesWon += gameStats.gamesWon;
                    _context.Entry(gsFound).State = EntityState.Modified ;
                }
                else {
                    _context.GameStatsItems.Add(gameStats);
                }

                _context.SaveChanges();
                success = true ;
            }
            catch (Exception ex) {
                CustomLogger.WriteLine(ex.Message) ;
                success = false ;
            }

            return success ;
        }

        public List<GameStats> GetAll(){
            return  _context.GameStatsItems.ToList<GameStats>() ;
        }

        public void Clear() {
            _context.GameStatsItems.RemoveRange(_context.GameStatsItems) ;
            _context.SaveChanges() ;
        }
    }
}
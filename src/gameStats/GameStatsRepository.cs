using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GoD_backend
{
    public class GameStatsRepository : IStoreGameStats {
        private readonly GameStatsContext _context;
        private readonly ILog _logger;

        public GameStatsRepository(GameStatsContext context, ILog logger)
        {
            _context = context;
            _logger = logger; 
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
                _logger.WriteLine(ex.Message) ;
                success = false ;
            }

            return success ;
        }

        public List<GameStats> GetAll(){
            List<GameStats> lstStats ;

            try {
                lstStats = _context.GameStatsItems.ToList<GameStats>() ;
                lstStats.Sort((g1,g2) => g2.gamesWon.CompareTo(g1.gamesWon)) ;
            } catch (Exception ex) {
                _logger.WriteLine(ex.Message) ;
                lstStats = null ;
            }

            return lstStats ;
        }

        public bool Clear() {
            bool success ;

            try {
                _context.GameStatsItems.RemoveRange(_context.GameStatsItems) ;
                _context.SaveChanges() ;
                success = true ;
            } catch (Exception ex) {
                _logger.WriteLine(ex.Message) ;
                success = false ;
            }

            return success ;
        }
    }
}
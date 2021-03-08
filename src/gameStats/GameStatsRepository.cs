using System.Collections.Generic;
using System.Linq;

public class GameStatsRepository : IStoreGameStats {
    private readonly GameStatsContext _context;

    public GameStatsRepository(GameStatsContext context)
    {
        _context = context;
    }

    public bool Update(GameStats gameStats){
        var gsFound = _context.GameStatsItems.FirstOrDefault(gs => gs.playerName.ToUpper() == gameStats.playerName.ToUpper());

        //update the stats for existing player
        if (gsFound != null)
        {
            gsFound.gamesWon += gameStats.gamesWon;
            
        }
        else {
            _context.GameStatsItems.Add(gameStats);
        }

        _context.SaveChanges();

        return false ;
    }

    public List<GameStats> GetAll(){
        return  _context.GameStatsItems.ToList<GameStats>() ;
    }
}
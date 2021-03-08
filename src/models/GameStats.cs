using System ;
using System.ComponentModel.DataAnnotations;

namespace GoD_backend
{
    public class GameStats {
        [Key]
        public String playerName {set; get;}
        public int gamesWon {set; get;}

        public GameStats() {
            
        }
        public GameStats(string name, int games)
        {
            this.playerName = name ;
            this.gamesWon = games ;
        }
    }
}
using System ;
using System.ComponentModel.DataAnnotations;

public class GameStats {
    [Key]
    public String playerName {set; get;}
    public int gamesWon {set; get;}
}
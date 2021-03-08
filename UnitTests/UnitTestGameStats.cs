using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;

public class UnitTestGameStats {


    private GameStatsRepository prepareStatsRepo() {
        GameStatsRepository repo ;
        GameStatsContext gameCtx ;

        var dbOptions = new DbContextOptionsBuilder<GameStatsContext>().UseInMemoryDatabase("testindDB").Options ;

        gameCtx = new GameStatsContext(dbOptions) ;

        repo = new GameStatsRepository(gameCtx) ;
        repo.Clear() ;

        return repo ;
    }

    [Fact]
    public void GameStats_Empty() {
        GameStatsRepository repo ;
        List<GameStats> lstStats ;

        repo = prepareStatsRepo() ;

        lstStats = repo.GetAll() ;

        Assert.True((lstStats != null) && (lstStats.Count == 0)) ;        
    }

    [Fact]
    public void GameStats_AddSingle() {
        GameStatsRepository repo ;
        List<GameStats> lstStats ;
        GameStats gs ;

        repo = prepareStatsRepo() ;


        gs = new GameStats(name: "Pedro", games: 3) ;
        repo.Update(gs);
        lstStats = repo.GetAll() ;

        Assert.True((lstStats != null) && (lstStats.Count == 1) && (lstStats[0].playerName == gs.playerName)) ;        
    }
}
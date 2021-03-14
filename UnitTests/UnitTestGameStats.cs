using System.Collections.Generic;
using GoD_backend;
using Microsoft.EntityFrameworkCore;
using Xunit;


public class UnitTestGameStats {
    private GameStatsRepository prepareStatsRepo() {
        GameStatsRepository repo ;
        GameStatsContext gameCtx ;

        var dbOptions = new DbContextOptionsBuilder<GameStatsContext>().UseInMemoryDatabase("testindDB").Options ;

        gameCtx = new GameStatsContext(dbOptions) ;

        var fl = new FileLogger() ;
        fl.Init("uniTests.txt") ;

        repo = new GameStatsRepository(gameCtx,fl) ;
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

        Assert.True((lstStats != null) && (lstStats.Count == 1) && (lstStats[0].playerName == gs.playerName) && (lstStats[0].gamesWon == gs.gamesWon)) ;        
    }

    [Fact]
    public void GameStats_Updateingle() {
        GameStatsRepository repo ;
        List<GameStats> lstStats ;
        GameStats gs ;

        repo = prepareStatsRepo() ;


        gs = new GameStats(name: "Pedro", games: 7) ;
        repo.Update(gs);

        gs = new GameStats(name: "pEdRo", games: 3) ;
        repo.Update(gs);
        
        lstStats = repo.GetAll() ;

        Assert.True((lstStats != null) && (lstStats.Count == 1) && (lstStats[0].playerName == "Pedro") && (lstStats[0].gamesWon == 10)) ;        
    }
}
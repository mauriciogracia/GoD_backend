using System;
using System.IO;
using GoD_backend;
using Xunit;

namespace UnitTests
{
    public class UnitTestBackend
    {
        private IGameEngine aGameEngine ;
        private GameEngineType currentGameEngine = GameEngineType.MoveGameEngine;
        private string jsonRulesFile = Path.Combine(Program.BACKEND_FOLDER,"PaperRockScissors.json");

        [Fact]
        public void TestGameEngineInit_Fails()
        {
            aGameEngine = GameEngineFactory.Create(currentGameEngine,"INCORRECT_FILE.json");
            var gs = aGameEngine.getGameSettings();

            Assert.True((gs == null) || (gs.rules == null));
        }

        [Fact]
        public void TestGameEngineInit_Success()
        {
            aGameEngine = GameEngineFactory.Create(currentGameEngine, jsonRulesFile);
            var gs = aGameEngine.getGameSettings();

            Assert.True((gs != null) && (gs.rules != null));              
        }

        [Fact]
        public void TestGameEngine_GetPossibleMoves()
        {
            aGameEngine = GameEngineFactory.Create(currentGameEngine, jsonRulesFile);
            var lstMoves = aGameEngine.getPossibleMoves();

            Assert.NotNull(lstMoves);
        }

        [Fact]
        public void TestGameEngine_Rules()
        {
            aGameEngine = GameEngineFactory.Create(currentGameEngine, jsonRulesFile);
            int moveResult = aGameEngine.determinResult("paper", "rock");

            Assert.Equal(1, moveResult);
        }
    }
}


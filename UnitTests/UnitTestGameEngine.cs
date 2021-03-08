using System.IO;
using GoD_backend;
using Xunit;

namespace UnitTests
{
    public class UnitTestGameEngine
    {
        private IGameEngine aGameEngine ;
        private GameEngineType currentGameEngine = GameEngineType.MoveGameEngine;
        private string jsonRulesFile = Path.Combine(GameSettings.getGameEngineFolder(),"PaperRockScissors.json");

        
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
            int moveResult;
            aGameEngine = GameEngineFactory.Create(currentGameEngine, jsonRulesFile);

            moveResult = aGameEngine.determinResult("paper", "rock");
            Assert.Equal(1, moveResult);

            moveResult = aGameEngine.determinResult("rock", "scissors");
            Assert.Equal(1, moveResult);

            moveResult = aGameEngine.determinResult("scissors", "paper");
            Assert.Equal(1, moveResult);

            moveResult = aGameEngine.determinResult("rock", "paper");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determinResult("scissors", "rock");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determinResult("paper", "scissors");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determinResult("paper", "scissors");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determinResult("rock", "paper");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determinResult("scissors", "rock");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determinResult("paper", "paper");
            Assert.Equal(0, moveResult);

            moveResult = aGameEngine.determinResult("rock", "rock");
            Assert.Equal(0, moveResult);

            moveResult = aGameEngine.determinResult("scissors", "scissors");
            Assert.Equal(0, moveResult);
        }
    }
}


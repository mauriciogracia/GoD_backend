using System.IO;
using GoD_backend;
using Xunit;

namespace UnitTests
{
    public class UnitTestGameEngine
    {
        private IGameEngine aGameEngine = null ;

        private void initEngine(string fileName) {
            RuleLoader rl ;
        
            if(aGameEngine == null) {
                var fl = new FileLogger() ;
                fl.Init("uniTests.txt") ;

                aGameEngine = new MoveGameEngine() ;
                aGameEngine.setLogger(fl) ;

                rl = new RuleLoader(fileName) ;
                aGameEngine.setGameSettings(rl.gr) ;
            }
        }

        [Fact]
        public void TestGameEngineInit_Fails()
        {
            initEngine("INCORRECT_FILE.json") ;
            var gs = aGameEngine.getGameSettings();

            Assert.True((gs == null) || (gs.rules == null));
        }

        [Fact]
        public void TestGameEngineInit_Success()
        {
            initEngine("SheldonRules.json") ;
            var gs = aGameEngine.getGameSettings();

            Assert.True((gs != null) && (gs.rules != null));              
        }

        [Fact]
        public void TestGameEngine_GetPossibleMoves()
        {
            initEngine("SheldonRules.json") ;
            var lstMoves = aGameEngine.getPossibleMoves();

            Assert.NotNull(lstMoves);
        }

        [Fact]
        public void TestGameEngine_Rules()
        {
            int moveResult;
            
            initEngine("SheldonRules.json") ;

            moveResult = aGameEngine.determineResult("paper", "rock");
            Assert.Equal(1, moveResult);

            moveResult = aGameEngine.determineResult("rock", "scissors");
            Assert.Equal(1, moveResult);

            moveResult = aGameEngine.determineResult("scissors", "paper");
            Assert.Equal(1, moveResult);

            moveResult = aGameEngine.determineResult("rock", "paper");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determineResult("scissors", "rock");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determineResult("paper", "scissors");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determineResult("paper", "scissors");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determineResult("rock", "paper");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determineResult("scissors", "rock");
            Assert.Equal(-1, moveResult);

            moveResult = aGameEngine.determineResult("paper", "paper");
            Assert.Equal(0, moveResult);

            moveResult = aGameEngine.determineResult("rock", "rock");
            Assert.Equal(0, moveResult);

            moveResult = aGameEngine.determineResult("scissors", "scissors");
            Assert.Equal(0, moveResult);
        }

        [Fact]
        public void TestGameEngine_ValidMove()
        {
            initEngine("SheldonRules.json") ;

            bool isValid = aGameEngine.isValidMove("rOcK"); 

            Assert.True(isValid);
        }

        [Fact]
        public void TestGameEngine_InvalidMove()
        {
            initEngine("SheldonRules.json") ;

            bool isValid = aGameEngine.isValidMove("ThisIsNot_a_Move"); 

            Assert.False(isValid);
        }

        [Fact]
        public void TestGameEngine_EmptyMove()
        {
            initEngine("SheldonRules.json") ;

            bool isValid = aGameEngine.isValidMove("   "); 

            Assert.False(isValid);
        }
    }
}


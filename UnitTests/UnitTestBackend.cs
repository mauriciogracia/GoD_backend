using System;
using System.IO;
using GoD_backend;
using Xunit;

namespace UnitTests
{
    public class UnitTestBackend
    {
        private IGameEngine aGameEngine ;
        private string jsonRulesFile = "PaperRockScissors.json";

        [Fact]
        public void TestGameEngineInit_Fails()
        {
            aGameEngine = new MoveGameEngine("INCORRECT_FILE.json");
            var gs = aGameEngine.getGameSettings();

            Assert.True((gs == null) || (gs.rules == null));
        }

        [Fact]
        public void TestGameEngineInit_Success()
        {
            aGameEngine = new MoveGameEngine(Path.Combine(Program.BACKEND_FOLDER, jsonRulesFile));
            var gs = aGameEngine.getGameSettings();

            Assert.True((gs != null) && (gs.rules != null));              
        }

        [Fact]
        public void TestGameEngine_GetPossibleMoves()
        {
            aGameEngine = new MoveGameEngine(Path.Combine(Program.BACKEND_FOLDER, jsonRulesFile));
            var lstMoves = aGameEngine.getPossibleMoves();
        }
    }
}


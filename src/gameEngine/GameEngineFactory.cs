using System ;

public static class GameEngineFactory
{
    public static IGameEngine Create(GameEngineType gameEngineType, string configFile)
    {
        switch(gameEngineType)
        {
            case GameEngineType.MoveGameEngine:
                return new MoveGameEngine(configFile);
            /*    
            case GameEngineType.AnotherGameEngine:
                return new AnotherGameEngine();
            */
            default:
                throw new NotImplementedException();
        }
    }
}
using System ;

public class GameEngineFactory
{
    public IGameEngine Create(GameEngineType gameEngineType, string configFile)
    {
        switch(gameEngineType)
        {
            case GameEngineType.MoveGameEngine:
                return new MoveGameEngine(configFile);
            /*    
            case GameEngineType.AnotherGameEngine:
                return new Motorbike();
            */
            default:
                throw new NotImplementedException();
        }
    }
}
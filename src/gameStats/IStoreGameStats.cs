using System.Collections.Generic;

public interface IStoreGameStats {
    bool Update(GameStats gs);

    List<GameStats> GetAll();
}
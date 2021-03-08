using System.Collections.Generic;

namespace GoD_backend
{
    public interface IStoreGameStats {
        bool Update(GameStats gs);

        List<GameStats> GetAll();

        void Clear() ;
    }
}
using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IDobavljacRobeManager
    {
        void Insert(Dobavljac_robe entity);
        bool Update(Dobavljac_robe entity);
        bool Delete(int id);
        Dobavljac_robe GetById(int id);
        IQueryable<Dobavljac_robe> GetAll(int pageIndex, int pageSize);
        int Count();
        bool AddMenadzer(int dobId, int menId);
        bool DeleteMenadzer(int dobId, int menId);
    }
}

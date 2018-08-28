using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IHipermarketManager
    {
        void Insert(Hipermarket entity);
        bool Update(Hipermarket entity);
        bool Delete(int id);
        Hipermarket GetById(int id);
        IQueryable<Hipermarket> GetAll(int pageIndex, int pageSize);
        int Count();
        bool AddMenadzer(int hipId, int menId);
        bool DeleteMenadzer(int hipId, int menId);
    }
}

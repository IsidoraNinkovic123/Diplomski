using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IDostavljacManager
    {
        bool Insert(Dostavljac entity);
        bool Update(Dostavljac entity);
        bool Delete(int id);
        Dostavljac GetById(int id);
        IQueryable<Dostavljac> GetAll(int pageIndex, int pageSize);
        int Count();
        Dostavljac GetRandom();
    }
}

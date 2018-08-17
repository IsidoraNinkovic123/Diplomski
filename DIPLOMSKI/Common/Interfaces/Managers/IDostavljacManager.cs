using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IDostavljacManager
    {
        void Insert(Dostavljac entity);
        bool Update(Dostavljac entity);
        bool Delete(int id);
        Dostavljac GetById(int id);
        IQueryable<Dostavljac> GetAll();
        Dostavljac GetRandom(int resId);
        IQueryable<Dostavljac> GetForRestoran(int resId);
    }
}

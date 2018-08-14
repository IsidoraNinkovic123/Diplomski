using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IDostavljacManager
    {
        void Insert(Dostavljac entity);
        bool Update(Dostavljac entity);
        bool Delete(string id);
        Dostavljac GetById(string id);
        IQueryable<Dostavljac> GetAll();
        Dostavljac GetRandom(int resId);
        IQueryable<Dostavljac> GetForRestoran(int resId);
    }
}

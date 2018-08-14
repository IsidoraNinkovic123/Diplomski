using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IDostavaManager
    {
        void Insert(Dostava entity);
        bool Update(Dostava entity);
        bool Delete(string id);
        Dostava GetById(string id);
        IQueryable<Dostava> GetAll();
    }
}

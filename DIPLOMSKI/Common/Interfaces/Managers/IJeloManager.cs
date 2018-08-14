using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IJeloManager
    {
        void Insert(Jelo entity);
        bool Update(Jelo entity);
        bool Delete(string id);
        Jelo GetById(string id);
        IQueryable<Jelo> GetAll();
        IQueryable<Jelo> GetForRestoran(int? resId);
    }
}

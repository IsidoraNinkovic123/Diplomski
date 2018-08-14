using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface ISastojakManager
    {
        void Insert(Sastojak entity);
        bool Update(Sastojak entity);
        bool Delete(int id);
        Sastojak GetById(int id);
        IQueryable<Sastojak> GetAll();
    }
}

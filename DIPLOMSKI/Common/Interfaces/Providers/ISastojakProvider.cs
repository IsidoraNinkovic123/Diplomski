using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface ISastojakProvider
    {
        void Insert(Sastojak entity);
        void Update(Sastojak entity);
        void Delete(int id);
        Sastojak GetById(int id);
        IQueryable<Sastojak> GetAll();
    }
}

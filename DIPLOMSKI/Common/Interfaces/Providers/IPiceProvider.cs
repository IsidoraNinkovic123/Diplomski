using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IPiceProvider
    {
        void Insert(Pice entity);
        void Update(Pice entity);
        void Delete(string id);
        Pice GetById(string id);
        IQueryable<Pice> GetAll();
    }
}

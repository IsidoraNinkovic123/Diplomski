using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IDostavljacProvider
    {
        void Insert(Dostavljac entity);
        void Update(Dostavljac entity);
        void Delete(string id);
        Dostavljac GetById(string id);
        IQueryable<Dostavljac> GetAll();
    }
}

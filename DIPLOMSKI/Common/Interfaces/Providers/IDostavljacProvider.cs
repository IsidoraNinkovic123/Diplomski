using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IDostavljacProvider
    {
        void Insert(Dostavljac entity);
        void Update(Dostavljac entity);
        void Delete(int id);
        Dostavljac GetById(int id);
        IQueryable<Dostavljac> GetAll();
    }
}

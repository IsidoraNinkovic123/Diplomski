using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IDostavaProvider
    {
        void Insert(Dostava entity);
        void Update(Dostava entity);
        void Delete(string id);
        Dostava GetById(string id);
        IQueryable<Dostava> GetAll();
    }
}

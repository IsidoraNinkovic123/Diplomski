using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IRestoranProvider
    {
        void Insert(Restoran entity);
        void Update(Restoran entity);
        void Delete(int id);
        Restoran GetById(int? id);
        IQueryable<Restoran> GetAll();
    }
}

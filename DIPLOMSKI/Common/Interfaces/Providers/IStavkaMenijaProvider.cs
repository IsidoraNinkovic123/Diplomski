using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IStavkaMenijaProvider
    {
        void Insert(Stavka_menija entity);
        void Update(Stavka_menija entity);
        void Delete(string id);
        Stavka_menija GetById(string id);
        IQueryable<Stavka_menija> GetAll();
    }
}

using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IKonobarProvider
    {
        void Insert(Konobar entity);
        void Update(Konobar entity);
        void Delete(string id);
        Konobar GetById(string id);
        IQueryable<Konobar> GetAll();
    }
}

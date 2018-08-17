using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IKonobarProvider
    {
        void Insert(Konobar entity);
        void Update(Konobar entity);
        void Delete(int id);
        Konobar GetById(int id);
        IQueryable<Konobar> GetAll();
    }
}

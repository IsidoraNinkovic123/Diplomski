using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IMeniProvider
    {
        void Insert(Meni entity);
        void Update(Meni entity);
        void Delete(int id);
        Meni GetById(int? id);
        IQueryable<Meni> GetAll();
    }
}

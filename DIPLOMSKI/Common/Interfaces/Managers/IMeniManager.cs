using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IMeniManager
    {
        void Insert(Meni entity);
        bool Update(Meni entity);
        bool Delete(int id);
        Meni GetById(int? id);
        IQueryable<Meni> GetAll();
    }
}

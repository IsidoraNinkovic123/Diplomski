using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IRestoranManager
    {
        void Insert(Restoran entity);
        bool Update(Restoran entity);
        bool Delete(int id);
        Restoran GetById(int? id);
        IQueryable<Restoran> GetAll();
    }
}

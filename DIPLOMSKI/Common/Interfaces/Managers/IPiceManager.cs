using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IPiceManager
    {
        void Insert(Pice entity);
        bool Update(Pice entity);
        bool Delete(string id);
        Pice GetById(string id);
        IQueryable<Pice> GetAll();
    }
}

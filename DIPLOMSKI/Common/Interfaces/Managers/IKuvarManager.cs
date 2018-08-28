using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IKuvarManager
    {
        bool Insert(Kuvar entity);
        bool Update(Kuvar entity);
        bool Delete(int id);
        Kuvar GetById(int id);
        IQueryable<Kuvar> GetAll(int pageIndex, int pageSize);
        int Count();
        bool AddJelo(string jeloId, int kuvId);
        bool DeleteJelo(string jeloId, int kuvId);
    }
}

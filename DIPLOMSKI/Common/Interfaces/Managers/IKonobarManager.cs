using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IKonobarManager
    {
        bool Insert(Konobar entity);
        bool Update(Konobar entity);
        bool Delete(int id);
        Konobar GetById(int id);
        IQueryable<Konobar> GetAll(int pageIndex, int pageSize);
        int Count();
    }
}

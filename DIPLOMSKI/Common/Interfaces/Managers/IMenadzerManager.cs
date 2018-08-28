using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IMenadzerManager
    {
        bool Insert(Menadzer entity);
        bool Update(Menadzer entity);
        bool Delete(int id);
        Menadzer GetById(int id);
        IQueryable<Menadzer> GetAll(int pageIndex, int pageSize);
        IQueryable<Menadzer> GetAll();
        int Count();
    }
}

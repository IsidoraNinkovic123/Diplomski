using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IZaposleniManager
    {
        void Insert(Zaposleni entity);
        bool Update(Zaposleni entity);
        bool Delete(int id);
        Zaposleni GetById(int id);
        IQueryable<Zaposleni> GetAll();
    }
}

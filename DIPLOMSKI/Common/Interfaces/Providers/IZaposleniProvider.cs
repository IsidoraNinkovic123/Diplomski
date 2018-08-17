using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IZaposleniProvider
    {
        void Insert(Zaposleni entity);
        void Update(Zaposleni entity);
        void Delete(int id);
        Zaposleni GetById(int id);
        IQueryable<Zaposleni> GetAll();
    }
}

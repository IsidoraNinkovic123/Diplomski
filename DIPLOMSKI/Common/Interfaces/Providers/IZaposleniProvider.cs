using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IZaposleniProvider
    {
        void Insert(Zaposleni entity);
        void Update(Zaposleni entity);
        void Delete(string id);
        Zaposleni GetById(string id);
        IQueryable<Zaposleni> GetAll();
    }
}

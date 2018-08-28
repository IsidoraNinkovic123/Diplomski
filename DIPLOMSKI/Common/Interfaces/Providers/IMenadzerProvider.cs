using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IMenadzerProvider
    {
        void Insert(Menadzer entity);
        void Update(Menadzer entity);
        void Delete(int id);
        Menadzer GetById(int id);
        IQueryable<Menadzer> GetAll();
    }
}

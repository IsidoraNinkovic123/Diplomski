using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IDobavljacRobeProvider
    {
        void Insert(Dobavljac_robe entity);
        void Update(Dobavljac_robe entity);
        void Delete(int id);
        Dobavljac_robe GetById(int id);
        IQueryable<Dobavljac_robe> GetAll();
    }
}

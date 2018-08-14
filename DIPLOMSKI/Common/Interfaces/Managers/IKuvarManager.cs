using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IKuvarManager
    {
        void Insert(Kuvar entity);
        bool Update(Kuvar entity);
        bool Delete(string id);
        Kuvar GetById(string id);
        IQueryable<Kuvar> GetAll();
        bool AddJelo(string jeloId, string kuvId);
        bool DeleteJelo(string jeloId, string kuvId);
    }
}

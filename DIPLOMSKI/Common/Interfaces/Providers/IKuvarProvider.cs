using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IKuvarProvider
    {
        void Insert(Kuvar entity);
        void Update(Kuvar entity);
        void Delete(string id);
        Kuvar GetById(string id);
        IQueryable<Kuvar> GetAll();
        void AddJelo(string jeloId, string kuvId);
        void DeleteJelo(string jeloId, string kuvId);
    }
}

using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IKuvarProvider
    {
        void Insert(Kuvar entity);
        void Update(Kuvar entity);
        void Delete(int id);
        Kuvar GetById(int id);
        IQueryable<Kuvar> GetAll();
        void AddJelo(string jeloId, int kuvId);
        void DeleteJelo(string jeloId, int kuvId);
    }
}

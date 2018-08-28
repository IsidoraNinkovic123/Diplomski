using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IHipermarketProvider
    {
        void Insert(Hipermarket entity);
        void Update(Hipermarket entity);
        void Delete(int id);
        Hipermarket GetById(int id);
        IQueryable<Hipermarket> GetAll();
        void AddMenadzer(int hipId, int menId);
        void DeleteMenadzer(int hipId, int menId);
    }
}

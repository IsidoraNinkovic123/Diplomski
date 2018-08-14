using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IMenadzerProvider
    {
        void Insert(Menadzer entity);
        void Update(Menadzer entity);
        void Delete(string id);
        Menadzer GetById(string id);
        IQueryable<Menadzer> GetAll();
        void AddHipermarket(int hipId, string menId);
        void DeleteHipermarket(int hipId, string menId);
        void AddDobavljac(int dobId, string menId);
        void DeleteDobavljac(int dobId, string menId);
    }
}

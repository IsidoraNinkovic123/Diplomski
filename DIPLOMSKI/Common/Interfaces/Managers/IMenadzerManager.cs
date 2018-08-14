using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IMenadzerManager
    {
        void Insert(Menadzer entity);
        bool Update(Menadzer entity);
        bool Delete(string id);
        Menadzer GetById(string id);
        IQueryable<Menadzer> GetAll();
        bool AddHipermarket(int hipId, string menId);
        bool DeleteHipermarket(int hipId, string menId);
        bool AddDobavljac(int dobId, string menId);
        bool DeleteDobavljac(int dobId, string menId);
    }
}

using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IMenadzerManager
    {
        void Insert(Menadzer entity);
        bool Update(Menadzer entity);
        bool Delete(int id);
        Menadzer GetById(int id);
        IQueryable<Menadzer> GetAll();
        bool AddHipermarket(int hipId, int menId);
        bool DeleteHipermarket(int hipId, int menId);
        bool AddDobavljac(int dobId, int menId);
        bool DeleteDobavljac(int dobId, int menId);
    }
}

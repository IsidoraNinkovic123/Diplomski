using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IKonobarManager
    {
        void Insert(Konobar entity);
        bool Update(Konobar entity);
        bool Delete(int id);
        Konobar GetById(int id);
        IQueryable<Konobar> GetAll();
        Konobar GetRandom(int resId);
        IQueryable<Konobar> GetForRestoran(int resId);
    }
}

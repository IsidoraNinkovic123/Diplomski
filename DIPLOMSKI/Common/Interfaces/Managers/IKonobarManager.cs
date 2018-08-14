using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IKonobarManager
    {
        void Insert(Konobar entity);
        bool Update(Konobar entity);
        bool Delete(string id);
        Konobar GetById(string id);
        IQueryable<Konobar> GetAll();
        Konobar GetRandom(int resId);
        IQueryable<Konobar> GetForRestoran(int resId);
    }
}

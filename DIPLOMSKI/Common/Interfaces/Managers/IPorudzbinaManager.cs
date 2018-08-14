using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IPorudzbinaManager
    {
        void Insert(Porudzbina entity);
        bool Update(Porudzbina entity);
        bool Delete(string id);
        Porudzbina GetById(string id);
        IQueryable<Porudzbina> GetAll();
    }
}

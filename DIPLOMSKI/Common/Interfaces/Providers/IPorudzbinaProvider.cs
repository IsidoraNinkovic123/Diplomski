using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IPorudzbinaProvider
    {
        void Insert(Porudzbina entity);
        void Update(Porudzbina entity);
        void Delete(string id);
        Porudzbina GetById(string id);
        IQueryable<Porudzbina> GetAll();
    }
}

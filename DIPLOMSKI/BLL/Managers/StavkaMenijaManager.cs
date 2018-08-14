using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class StavkaMenijaManager : IStavkaMenijaManager
    {
        private IStavkaMenijaProvider _provider;

        public StavkaMenijaManager()
        {
            _provider = new StavkaMenijaProvider();
        }

        public void Insert(Stavka_menija entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Stavka_menija entity)
        {
            if (_provider.GetById(entity.ID) == null)
                return false;
            else
            {
                _provider.Update(entity);
                return true;
            }
        }

        public bool Delete(string id)
        {
            if (_provider.GetById(id) == null)
                return false;
            else
            {
                _provider.Delete(id);
                return true;
            }
        }

        public Stavka_menija GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Stavka_menija> GetAll()
        {
            return _provider.GetAll();
        }

        public IQueryable<Stavka_menija> GetForMeni(int meniID)
        {
            return _provider.GetAll().Where(s => s.Meni_ID == meniID);
        }
    }
}

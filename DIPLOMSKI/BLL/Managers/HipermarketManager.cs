using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class HipermarketManager : IHipermarketManager
    {
        private IHipermarketProvider _provider;

        public HipermarketManager()
        {
            _provider = new HipermarketProvider();
        }

        public void Insert(Hipermarket entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Hipermarket entity)
        {
            if (_provider.GetById(entity.ID) == null)
                return false;
            else
            {
                _provider.Update(entity);
                return true;
            }
        }

        public bool Delete(int id)
        {
            if (_provider.GetById(id) == null)
                return false;
            else
            {
                _provider.Delete(id);
                return true;
            }
        }

        public Hipermarket GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Hipermarket> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

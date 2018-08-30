using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class SastojakManager : ISastojakManager
    {
        private ISastojakProvider _provider;

        public SastojakManager()
        {
            _provider = new SastojakProvider();
        }

        public void Insert(Sastojak entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Sastojak entity)
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

        public Sastojak GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Sastojak> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class RestoranManager : IRestoranManager
    {
        private IRestoranProvider _provider;

        public RestoranManager()
        {
            _provider = new RestoranProvider();
        }

        public void Insert(Restoran entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Restoran entity)
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

        public Restoran GetById(int? id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Restoran> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

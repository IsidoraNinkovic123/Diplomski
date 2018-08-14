using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class DobavljacRobeManager : IDobavljacRobeManager
    {
        private IDobavljacRobeProvider _provider;

        public DobavljacRobeManager()
        {
            _provider = new DobavljacRobeProvider();
        }

        public void Insert(Dobavljac_robe entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Dobavljac_robe entity)
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

        public Dobavljac_robe GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Dobavljac_robe> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

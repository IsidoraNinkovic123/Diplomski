using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class MeniManager : IMeniManager
    {
        private IMeniProvider _provider;

        public MeniManager()
        {
            _provider = new MeniProvider();
        }

        public void Insert(Meni entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Meni entity)
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

        public Meni GetById(int? id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Meni> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

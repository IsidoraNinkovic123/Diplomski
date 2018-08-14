using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class DostavaManager : IDostavaManager
    {
        private IDostavaProvider _provider;

        public DostavaManager()
        {
            _provider = new DostavaProvider();
        }

        public void Insert(Dostava entity)
        {
            entity.Porudzbina.ID = Guid.NewGuid().ToString();
            entity.ID = entity.Porudzbina.ID;

            _provider.Insert(entity);
        }

        public bool Update(Dostava entity)
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

        public Dostava GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Dostava> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

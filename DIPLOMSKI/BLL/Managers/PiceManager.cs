using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class PiceManager : IPiceManager
    {
        private IPiceProvider _provider;

        public PiceManager()
        {
            _provider = new PiceProvider();
        }

        public void Insert(Pice entity)
        {
            entity.Stavka_menija.ID = Guid.NewGuid().ToString();
            entity.ID = entity.Stavka_menija.ID;

            _provider.Insert(entity);
        }

        public bool Update(Pice entity)
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

        public Pice GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Pice> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

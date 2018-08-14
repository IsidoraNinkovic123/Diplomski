using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class JeloManager : IJeloManager
    {
        private IJeloProvider _provider;

        public JeloManager()
        {
            _provider = new JeloProvider();
        }

        public void Insert(Jelo entity)
        {
            entity.Stavka_menija.ID = Guid.NewGuid().ToString();
            entity.ID = entity.Stavka_menija.ID;

            _provider.Insert(entity);
        }

        public bool Update(Jelo entity)
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

        public Jelo GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Jelo> GetAll()
        {
            return _provider.GetAll();
        }

        public IQueryable<Jelo> GetForRestoran(int? resId)
        {
            return _provider.GetAll().Where(j => j.Stavka_menija.Meni.Restoran_ID == resId);
        }
    }
}

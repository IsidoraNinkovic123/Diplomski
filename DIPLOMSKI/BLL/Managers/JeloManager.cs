using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;
using System.Collections.Generic;

namespace BLL.Managers
{
    public class JeloManager : IJeloManager
    {
        private IJeloProvider _provider;
        private ISastojakProvider _providerS;

        public JeloManager()
        {
            _provider = new JeloProvider();
            _providerS = new SastojakProvider();
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

        public IQueryable<Jelo> GetByType(int pageIndex, int pageSize, int type)
        {
            return _provider.GetAll().Where(x => x.TIP == type).OrderBy(j => j.Stavka_menija.NAZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<Jelo> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll().OrderBy(j => j.Stavka_menija.NAZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public int Count()
        {
            return _provider.GetAll().Count();
        }

        public int CountForType(int type)
        {
            return _provider.GetAll().Where(x => x.TIP == type).Count();
        }

        public bool AddSastojak(int sastojakId, string jeloId)
        {
            Jelo jelo = _provider.GetById(jeloId);
            if (jelo.Sastojaks.FirstOrDefault(x => x.ID == sastojakId) == null)
            {
                _provider.AddSastojak(sastojakId, jeloId);
                return true;
            }
            return false;
        }

        public bool DeleteSastojak(int sastojakId, string jeloId)
        {
            Jelo jelo = _provider.GetById(jeloId);
            if (jelo.Sastojaks.FirstOrDefault(x => x.ID == sastojakId) != null)
            {
                _provider.DeleteSastojak(sastojakId, jeloId);
                return true;
            }

            return false;
        }
    }
}

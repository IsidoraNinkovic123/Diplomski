using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class KuvarManager : IKuvarManager
    {
        private IKuvarProvider _provider;
        private IJeloProvider _providerJelo;

        public KuvarManager()
        {
            _provider = new KuvarProvider();
            _providerJelo = new JeloProvider();
        }

        public bool Insert(Kuvar entity)
        {
            if (_provider.GetById(entity.MBR) != null)
                return false;

            entity.Zaposleni.MBR = entity.MBR;

            _provider.Insert(entity);
            return true;
        }

        public bool Update(Kuvar entity)
        {
            if (_provider.GetById(entity.MBR) == null)
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

        public Kuvar GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Kuvar> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll().OrderBy(k => k.Zaposleni.PRZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public int Count()
        {
            return _provider.GetAll().Count();
        }

        public bool AddJelo(string jeloId, int kuvId)
        {
            Kuvar kuv = _provider.GetById(kuvId);
            Jelo jel = _providerJelo.GetById(jeloId);

            if (kuv != null && kuv.Jeloes.FirstOrDefault(x => x.ID == jeloId) == null)
            {
                _provider.AddJelo(jeloId, kuvId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteJelo(string jeloId, int kuvId)
        {
            Kuvar kuv = _provider.GetById(kuvId);
            Jelo jel = _providerJelo.GetById(jeloId);

            if (kuv != null && kuv.Jeloes.FirstOrDefault(x => x.ID == jeloId) != null)
            {
                _provider.DeleteJelo(jeloId, kuvId);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

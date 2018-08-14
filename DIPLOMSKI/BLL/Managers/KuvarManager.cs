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

        public void Insert(Kuvar entity)
        {
            entity.Zaposleni.MBR = Guid.NewGuid().ToString();
            entity.MBR = entity.Zaposleni.MBR;

            _provider.Insert(entity);
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

        public Kuvar GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Kuvar> GetAll()
        {
            return _provider.GetAll();
        }

        public bool AddJelo(string jeloId, string kuvId)
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

        public bool DeleteJelo(string jeloId, string kuvId)
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

using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class DostavljacManager : IDostavljacManager
    {
        private IDostavljacProvider _provider;

        public DostavljacManager()
        {
            _provider = new DostavljacProvider();
        }

        public void Insert(Dostavljac entity)
        {
            entity.Zaposleni.MBR = Guid.NewGuid().ToString();
            entity.MBR = entity.Zaposleni.MBR;

            _provider.Insert(entity);
        }

        public bool Update(Dostavljac entity)
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

        public Dostavljac GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Dostavljac> GetAll()
        {
            return _provider.GetAll();
        }

        public Dostavljac GetRandom(int resId)
        {
            Random ran = new Random();

            if (_provider.GetAll().Where(x => x.Zaposleni.Restoran_ID == resId).Count() > 0)
            {
                Dostavljac dos = _provider.GetAll().Where(x => x.Zaposleni.Restoran_ID == resId).ToList()[ran.Next(_provider.GetAll().Count())];
                return dos;
            }
            else
            {
                return null;
            }
        }

        public IQueryable<Dostavljac> GetForRestoran(int resId)
        {
            return _provider.GetAll().Where(x => x.Zaposleni.Restoran_ID == resId);
        }
    }
}

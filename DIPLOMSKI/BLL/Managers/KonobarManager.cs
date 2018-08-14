using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class KonobarManager : IKonobarManager
    {
        private IKonobarProvider _provider;

        public KonobarManager()
        {
            _provider = new KonobarProvider();
        }

        public void Insert(Konobar entity)
        {
            entity.Zaposleni.MBR = Guid.NewGuid().ToString();
            entity.MBR = entity.Zaposleni.MBR;

            _provider.Insert(entity);
        }

        public bool Update(Konobar entity)
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

        public Konobar GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Konobar> GetAll()
        {
            return _provider.GetAll();
        }

        public Konobar GetRandom(int resId)
        {
            Random ran = new Random();

            if (_provider.GetAll().Where(x => x.Zaposleni.Restoran_ID == resId).Count() > 0)
            {
                Konobar kon = _provider.GetAll().Where(x => x.Zaposleni.Restoran_ID == resId).ToList()[ran.Next(_provider.GetAll().Count())];
                return kon;
            }
            else
            {
                return null;
            }
        }

        public IQueryable<Konobar> GetForRestoran(int resId)
        {
            return _provider.GetAll().Where(x => x.Zaposleni.Restoran_ID == resId);
        }
    }
}

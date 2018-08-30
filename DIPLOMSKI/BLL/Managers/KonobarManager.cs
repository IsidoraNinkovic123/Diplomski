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

        public bool Insert(Konobar entity)
        {
            if (_provider.GetById(entity.MBR) != null)
                return false;

            entity.SIFRA = "KON" + entity.MBR;
            entity.Zaposleni.MBR = entity.MBR;

            _provider.Insert(entity);
            return true;
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

        public Konobar GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Konobar> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll().OrderBy(k => k.Zaposleni.PRZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public int Count()
        {
            return _provider.GetAll().Count();
        }

        public bool CheckPassword(string pass)
        {
            if (_provider.GetAll().Where(x => x.SIFRA == pass).Count() > 0)
                return true;
            else
                return false;
        }
    }
}

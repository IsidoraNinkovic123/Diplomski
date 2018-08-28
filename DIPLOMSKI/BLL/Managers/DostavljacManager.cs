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

        public bool Insert(Dostavljac entity)
        {
            if (_provider.GetById(entity.MBR) != null)
                return false;

            entity.Zaposleni.MBR = entity.MBR;

            _provider.Insert(entity);
            return true;
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

        public Dostavljac GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Dostavljac> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll().OrderBy(k => k.Zaposleni.PRZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public int Count()
        {
            return _provider.GetAll().Count();
        }

        public Dostavljac GetRandom()
        {
            Random ran = new Random();

            if (_provider.GetAll().Count() > 0)
            {
                Dostavljac dos = _provider.GetAll().ToList()[ran.Next(_provider.GetAll().Count())];
                return dos;
            }
            else
            {
                return null;
            }
        }
    }
}

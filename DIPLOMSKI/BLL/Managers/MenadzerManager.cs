using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class MenadzerManager : IMenadzerManager
    {
        private IMenadzerProvider _provider;

        public MenadzerManager()
        {
            _provider = new MenadzerProvider();
        }

        public bool Insert(Menadzer entity)
        {
            if (_provider.GetById(entity.MBR) != null)
                return false;

            entity.SIFRA = "MEN"+entity.MBR;
            entity.Zaposleni.MBR = entity.MBR;

            _provider.Insert(entity);
            return true;
        }

        public bool Update(Menadzer entity)
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

        public Menadzer GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Menadzer> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll().OrderBy(k => k.Zaposleni.PRZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<Menadzer> GetAll()
        {
            return _provider.GetAll();
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

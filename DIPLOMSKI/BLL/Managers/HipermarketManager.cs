using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;
using System.Collections.Generic;

namespace BLL.Managers
{
    public class HipermarketManager : IHipermarketManager
    {
        private IHipermarketProvider _provider;
        private IMenadzerProvider _providerMen;

        public HipermarketManager()
        {
            _provider = new HipermarketProvider();
            _providerMen = new MenadzerProvider();
        }

        public void Insert(Hipermarket entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Hipermarket entity)
        {
            if (_provider.GetById(entity.ID) == null)
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

        public Hipermarket GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Hipermarket> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll().OrderBy(x => x.NAZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public int Count()
        {
            return _provider.GetAll().Count();
        }

        public bool AddMenadzer(int hipId, int menId)
        {
            Hipermarket hip = _provider.GetById(hipId);
            List<Menadzer> menadzeri = _providerMen.GetAll().ToList();

            foreach (Menadzer men in menadzeri)
            {
                if (men.Hipermarkets.FirstOrDefault(x => x.ID == hipId) != null)
                {
                    return false;
                }
            }

            _provider.AddMenadzer(hipId, menId);
            return true;
        }

        public bool DeleteMenadzer(int hipId, int menId)
        {
            Hipermarket hip = _provider.GetById(hipId);
            List<Menadzer> menadzeri = _providerMen.GetAll().ToList();

            foreach (Menadzer men in menadzeri)
            {
                if (men.Hipermarkets.FirstOrDefault(x => x.ID == hipId) != null)
                {
                    _provider.DeleteMenadzer(hipId, menId);
                    return true;
                }
            }

            return false;
        }
    }
}

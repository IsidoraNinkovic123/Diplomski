using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;
using System.Collections.Generic;

namespace BLL.Managers
{
    public class DobavljacRobeManager : IDobavljacRobeManager
    {
        private IDobavljacRobeProvider _provider;
        private IMenadzerProvider _providerMen;

        public DobavljacRobeManager()
        {
            _provider = new DobavljacRobeProvider();
            _providerMen = new MenadzerProvider();
        }

        public void Insert(Dobavljac_robe entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Dobavljac_robe entity)
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

        public Dobavljac_robe GetById(int id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Dobavljac_robe> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll().OrderBy(x => x.NAZ).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public int Count()
        {
            return _provider.GetAll().Count();
        }

        public bool AddMenadzer(int dobId, int menId)
        {
            Dobavljac_robe dob = _provider.GetById(dobId);
            List<Menadzer> menadzeri = _providerMen.GetAll().ToList();

            foreach(Menadzer men in menadzeri)
            {
                if (men.Dobavljac_robe.FirstOrDefault(x => x.ID == dobId) != null)
                {
                    return false;
                }
            }

            _provider.AddMenadzer(dobId, menId);
            return true;
        }

        public bool DeleteMenadzer(int dobId, int menId)
        {
            Dobavljac_robe dob = _provider.GetById(dobId);
            List<Menadzer> menadzeri = _providerMen.GetAll().ToList();

            foreach (Menadzer men in menadzeri)
            {
                if (men.Dobavljac_robe.FirstOrDefault(x => x.ID == dobId) != null)
                {
                    _provider.DeleteMenadzer(dobId, menId);
                    return true;
                }
            }

            return false;
        }
    }
}

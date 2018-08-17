using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class MenadzerManager : IMenadzerManager
    {
        private IMenadzerProvider _provider;
        private IDobavljacRobeProvider _providerDobRobe;
        private IHipermarketProvider _providerHip;

        public MenadzerManager()
        {
            _provider = new MenadzerProvider();
            _providerDobRobe = new DobavljacRobeProvider();
            _providerHip = new HipermarketProvider();
        }

        public void Insert(Menadzer entity)
        {
            _provider.Insert(entity);
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

        public IQueryable<Menadzer> GetAll()
        {
            return _provider.GetAll();
        }

        public bool AddHipermarket(int hipId, int menId)
        {
            Menadzer men = _provider.GetById(menId);
            Hipermarket hip = _providerHip.GetById(hipId);

            if (men != null && men.Hipermarkets.FirstOrDefault(x => x.ID == hipId) == null)
            {
                _provider.AddHipermarket(hipId, menId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteHipermarket(int hipId, int menId)
        {
            Menadzer men = _provider.GetById(menId);
            Hipermarket hip = _providerHip.GetById(hipId);

            if (men != null && men.Hipermarkets.FirstOrDefault(x => x.ID == hipId) != null)
            {
                _provider.DeleteHipermarket(hipId, menId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddDobavljac(int dobId, int menId)
        {
            Menadzer men = _provider.GetById(menId);
            Dobavljac_robe dob = _providerDobRobe.GetById(dobId);

            if (men != null && men.Dobavljac_robe.FirstOrDefault(x => x.ID == dobId) == null)
            {
                _provider.AddDobavljac(dobId, menId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDobavljac(int dobId, int menId)
        {
            Menadzer men = _provider.GetById(menId);
            Dobavljac_robe dob = _providerDobRobe.GetById(dobId);

            if (men != null && men.Dobavljac_robe.FirstOrDefault(x => x.ID == dobId) != null)
            {
                _provider.DeleteDobavljac(dobId, menId);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

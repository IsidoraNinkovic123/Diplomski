using Common.Interfaces.Managers;
using System;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class PorudzbinaManager : IPorudzbinaManager
    {
        private IPorudzbinaProvider _provider;

        public PorudzbinaManager()
        {
            _provider = new PorudzbinaProvider();
        }

        public void Insert(Porudzbina entity)
        {
            if (entity.ID == null)
            {
                entity.ID = Guid.NewGuid().ToString();
            }

            entity.DAT = DateTime.Now;

            _provider.Insert(entity);
        }

        public bool Update(Porudzbina entity)
        {
            if (_provider.GetById(entity.ID) == null)
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

        public Porudzbina GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Porudzbina> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

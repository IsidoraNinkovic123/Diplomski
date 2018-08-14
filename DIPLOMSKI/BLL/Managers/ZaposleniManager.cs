using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class ZaposleniManager : IZaposleniManager
    {
        private IZaposleniProvider _provider;

        public ZaposleniManager()
        {
            _provider = new ZaposoleniProvider();
        }

        public void Insert(Zaposleni entity)
        {
            _provider.Insert(entity);
        }

        public bool Update(Zaposleni entity)
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

        public Zaposleni GetById(string id)
        {
            return _provider.GetById(id);
        }

        public IQueryable<Zaposleni> GetAll()
        {
            return _provider.GetAll();
        }
    }
}

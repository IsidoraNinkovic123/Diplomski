using Common.Interfaces.Managers;
using Common.Interfaces.Providers;
using DAL.Providers;
using System;

namespace BLL.Managers
{
    public class DnevniIzvestajManager : IDnevniIzvestajManager
    {
        private IDnevniIzvestajProvider _provider;

        public DnevniIzvestajManager()
        {
            _provider = new DnevniIzvestajProvider();
        }

        public string BrojPorudzbina(DateTime d)
        {
            return _provider.BrojPorudzbina(d);
        }

        public string NajprodavanijeJelo(DateTime d)
        {
            return _provider.NajprodavanijeJelo(d);
        }

        public string Promet(DateTime d)
        {
            return _provider.Promet(d);
        }
    }
}

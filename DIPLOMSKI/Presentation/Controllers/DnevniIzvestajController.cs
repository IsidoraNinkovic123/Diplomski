using BLL.Managers;
using Common.Interfaces.Managers;
using System;
using System.Web.Http;

namespace Presentation.Controllers
{
    public class DnevniIzvestajController : ApiController
    {
        private IDnevniIzvestajManager _manager;

        private DnevniIzvestajController()
        {
            _manager = new DnevniIzvestajManager();
        }

        [HttpGet]
        public string Podaci(DateTime d)
        {
            string ret = "";

            ret += _manager.BrojPorudzbina(d);
            ret += _manager.NajprodavanijeJelo(d);
            ret += _manager.Promet(d);

            return ret;
        }
    }
}

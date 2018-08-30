using BLL.Managers;
using Common.Database;
using Common.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation.Controllers
{
    public class SearchController : ApiController
    {
        private IStavkaMenijaManager _manager;

        private SearchController()
        {
            _manager = new StavkaMenijaManager();
        }

        [HttpGet]
        public IHttpActionResult SearchStavke(int pageIndex, int pageSize, string keyWords)
        {
            return Ok(new { stavke = _manager.Search(pageIndex, pageSize, keyWords), count = _manager.CountSearch(keyWords) });
        }
    }
}

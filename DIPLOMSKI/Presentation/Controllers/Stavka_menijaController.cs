using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class Stavka_menijaController : ApiController
    {
        private IStavkaMenijaManager _manager;

        private Stavka_menijaController()
        {
            _manager = new StavkaMenijaManager();
        }

        // GET: api/Stavka_menija
        public IHttpActionResult GetStavka_menija(int pageIndex, int pageSize, int meniId)
        {
            return Ok(new { stavke = _manager.GetAllMeni(pageIndex, pageSize, meniId), count = _manager.CountMeni(meniId) });
        }

        [HttpGet]
        public IHttpActionResult GetStavka_menija(int pageIndex, int pageSize)
        {
            return Ok(new { stavke = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        // GET: api/Stavka_menija/5
        [ResponseType(typeof(Stavka_menija))]
        public IHttpActionResult GetStavka_menija(string id)
        {
            Stavka_menija stavka_menija = _manager.GetById(id);
            if (stavka_menija == null)
            {
                return NotFound();
            }

            return Ok(stavka_menija);
        }

        // PUT: api/Stavka_menija/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStavka_menija(string id, Stavka_menija stavka_menija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavka_menija.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(stavka_menija);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Stavka_menija
        [ResponseType(typeof(Stavka_menija))]
        public IHttpActionResult PostStavka_menija(Stavka_menija stavka_menija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(stavka_menija);
            return CreatedAtRoute("DefaultApi", new { id = stavka_menija.ID }, stavka_menija);
        }

        // DELETE: api/Stavka_menija/5
        [ResponseType(typeof(Stavka_menija))]
        public IHttpActionResult DeleteStavka_menija(string id, int meniId)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(new { hipermarketi = _manager.GetAllMeni(1, 6, meniId), count = _manager.CountMeni(meniId) });
            }
            else
            {
                return BadRequest();
            }
        }

        private bool Stavka_menijaExists(string id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
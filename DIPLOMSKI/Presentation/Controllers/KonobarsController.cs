using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class KonobarsController : ApiController
    {
        private IKonobarManager _manager;

        private KonobarsController()
        {
            _manager = new KonobarManager();
        }

        // GET: api/Konobars
        public IHttpActionResult GetKonobars(int pageIndex, int pageSize)
        {
            return Ok(new { konobari = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        // GET: api/Konobars/5
        [ResponseType(typeof(Konobar))]
        public IHttpActionResult GetKonobar(int id)
        {
            Konobar konobar = _manager.GetById(id);
            if (konobar == null)
            {
                return NotFound();
            }

            return Ok(konobar);
        }

        // PUT: api/Konobars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKonobar(int id, Konobar konobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != konobar.MBR)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(konobar);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Konobars
        [ResponseType(typeof(Konobar))]
        public IHttpActionResult PostKonobar(Konobar konobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_manager.Insert(konobar))
                return CreatedAtRoute("DefaultApi", new { id = konobar.MBR }, konobar);
            else
                return BadRequest();
        }

        // DELETE: api/Konobars/5
        [ResponseType(typeof(Konobar))]
        public IHttpActionResult DeleteKonobar(int id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(new { konobari = _manager.GetAll(1, 10), count = _manager.Count() });
            }
            else
            {
                return BadRequest();
            }
        }

        private bool KonobarExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class ZaposlenisController : ApiController
    {
        private IZaposleniManager _manager;

        private ZaposlenisController()
        {
            _manager = new ZaposleniManager();
        }

        // GET: api/Zaposlenis
        public IHttpActionResult GetZaposlenis()
        {
            return Ok(_manager.GetAll());
        }

        // GET: api/Zaposlenis/5
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult GetZaposleni(int id)
        {
            Zaposleni zaposleni = _manager.GetById(id);
            if (zaposleni == null)
            {
                return NotFound();
            }

            return Ok(zaposleni);
        }

        // PUT: api/Zaposlenis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZaposleni(int id, Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zaposleni.MBR)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(zaposleni);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Zaposlenis
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult PostZaposleni(Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(zaposleni);
            return CreatedAtRoute("DefaultApi", new { id = zaposleni.MBR }, zaposleni);
        }

        // DELETE: api/Zaposlenis/5
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult DeleteZaposleni(int id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(_manager.GetAll());
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ZaposleniExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
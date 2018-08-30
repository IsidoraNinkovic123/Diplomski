using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class SastojaksController : ApiController
    {
        private ISastojakManager _manager;

        private SastojaksController()
        {
            _manager = new SastojakManager();
        }

        // GET: api/Sastojaks
        public IHttpActionResult GetSastojaks()
        {
            return Ok(_manager.GetAll());
        }

        // GET: api/Sastojaks/5
        [ResponseType(typeof(Sastojak))]
        public IHttpActionResult GetSastojak(int id)
        {
            Sastojak sastojak = _manager.GetById(id);
            if (sastojak == null)
            {
                return NotFound();
            }

            return Ok(sastojak);
        }

        // PUT: api/Sastojaks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSastojak(int id, Sastojak sastojak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sastojak.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(sastojak);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Sastojaks
        [ResponseType(typeof(Sastojak))]
        public IHttpActionResult PostSastojak(Sastojak sastojak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(sastojak);
            return CreatedAtRoute("DefaultApi", new { id = sastojak.ID }, sastojak);
        }

        // DELETE: api/Sastojaks/5
        [ResponseType(typeof(Sastojak))]
        public IHttpActionResult DeleteSastojak(int id)
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

        private bool SastojakExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
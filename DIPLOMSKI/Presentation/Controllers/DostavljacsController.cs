using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class DostavljacsController : ApiController
    {
        private IDostavljacManager _manager;

        private DostavljacsController()
        {
            _manager = new DostavljacManager();
        }

        // GET: api/Dostavljacs
        public IHttpActionResult GetDostavljacs(int pageIndex, int pageSize)
        {
            return Ok(new { dostavljaci = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        [HttpGet]
        public Dostavljac GetRandom()
        {
            return _manager.GetRandom();
        }

        // GET: api/Dostavljacs/5
        [ResponseType(typeof(Dostavljac))]
        public IHttpActionResult GetDostavljac(int id)
        {
            Dostavljac dostavljac = _manager.GetById(id);
            if (dostavljac == null)
            {
                return NotFound();
            }

            return Ok(dostavljac);
        }

        // PUT: api/Dostavljacs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDostavljac(int id, Dostavljac dostavljac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dostavljac.MBR)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(dostavljac);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Dostavljacs
        [ResponseType(typeof(Dostavljac))]
        public IHttpActionResult PostDostavljac(Dostavljac dostavljac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_manager.Insert(dostavljac))
                return CreatedAtRoute("DefaultApi", new { id = dostavljac.MBR }, dostavljac);
            else
                return BadRequest();
        }

        // DELETE: api/Dostavljacs/5
        [ResponseType(typeof(Dostavljac))]
        public IHttpActionResult DeleteDostavljac(int id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(new { dostavljaci = _manager.GetAll(1, 9), count = _manager.Count() });
            }
            else
            {
                return BadRequest();
            }
        }

        private bool DostavljacExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
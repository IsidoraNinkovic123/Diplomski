using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class DostavasController : ApiController
    {
        private IDostavaManager _manager;

        private DostavasController()
        {
            _manager = new DostavaManager();
        }

        // GET: api/Dostavas
        public IHttpActionResult GetDostavas()
        {
            return Ok(_manager.GetAll());
        }

        // GET: api/Dostavas/5
        [ResponseType(typeof(Dostava))]
        public IHttpActionResult GetDostava(string id)
        {
            Dostava dostava = _manager.GetById(id);
            if (dostava == null)
            {
                return NotFound();
            }

            return Ok(dostava);
        }

        // PUT: api/Dostavas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDostava(string id, Dostava dostava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dostava.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(dostava);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Dostavas
        [ResponseType(typeof(Dostava))]
        public IHttpActionResult PostDostava(Dostava dostava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(dostava);
            return Ok(dostava);
        }

        // DELETE: api/Dostavas/5
        [ResponseType(typeof(Dostava))]
        public IHttpActionResult DeleteDostava(string id)
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

        private bool DostavaExists(string id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
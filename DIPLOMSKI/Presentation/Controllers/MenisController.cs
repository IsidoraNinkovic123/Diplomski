using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class MenisController : ApiController
    {
        private IMeniManager _manager;

        private MenisController()
        {
            _manager = new MeniManager();
        }

        // GET: api/Menis
        public IHttpActionResult GetMenis()
        {
            return Ok(_manager.GetAll());
        }

        // GET: api/Menis/5
        [ResponseType(typeof(Meni))]
        public IHttpActionResult GetMeni(int id)
        {
            Meni meni = _manager.GetById(id);
            if (meni == null)
            {
                return NotFound();
            }

            return Ok(meni);
        }

        // PUT: api/Menis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeni(int id, Meni meni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meni.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(meni);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Menis
        [ResponseType(typeof(Meni))]
        public IHttpActionResult PostMeni(Meni meni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(meni);
            return CreatedAtRoute("DefaultApi", new { id = meni.ID }, meni);
        }

        // DELETE: api/Menis/5
        [ResponseType(typeof(Meni))]
        public IHttpActionResult DeleteMeni(int id)
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

        private bool MeniExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class RestoransController : ApiController
    {
        private IRestoranManager _manager;

        private RestoransController()
        {
            _manager = new RestoranManager();
        }

        // GET: api/Restorans
        public IHttpActionResult GetRestorans()
        {
            return Ok(_manager.GetAll());
        }

        // GET: api/Restorans/5
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult GetRestoran(int id)
        {
            Restoran restoran = _manager.GetById(id);
            if (restoran == null)
            {
                return NotFound();
            }

            return Ok(restoran);
        }

        // PUT: api/Restorans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestoran(int id, Restoran restoran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restoran.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(restoran);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Restorans
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult PostRestoran(Restoran restoran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(restoran);
            return CreatedAtRoute("DefaultApi", new { id = restoran.ID }, restoran);
        }

        // DELETE: api/Restorans/5
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult DeleteRestoran(int id)
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

        private bool RestoranExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
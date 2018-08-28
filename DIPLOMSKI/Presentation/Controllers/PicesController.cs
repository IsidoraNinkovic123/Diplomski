using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class PicesController : ApiController
    {
        private IPiceManager _manager;

        private PicesController()
        {
            _manager = new PiceManager();
        }

        // GET: api/Pices
        public IHttpActionResult GetPices(int pageIndex, int pageSize)
        {
            return Ok(new { pica = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        // GET: api/Pices/5
        [ResponseType(typeof(Pice))]
        public IHttpActionResult GetPice(string id)
        {
            Pice pice = _manager.GetById(id);
            if (pice == null)
            {
                return NotFound();
            }

            return Ok(pice);
        }

        // PUT: api/Pices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPice(string id, Pice pice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pice.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(pice);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Pices
        [ResponseType(typeof(Pice))]
        public IHttpActionResult PostPice(Pice pice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(pice);
            return CreatedAtRoute("DefaultApi", new { id = pice.ID }, pice);
        }

        // DELETE: api/Pices/5
        [ResponseType(typeof(Pice))]
        public IHttpActionResult DeletePice(string id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
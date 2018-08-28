using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class KuvarsController : ApiController
    {
        private IKuvarManager _manager;

        private KuvarsController()
        {
            _manager = new KuvarManager();
        }

        // GET: api/Kuvars
        public IHttpActionResult GetKuvars(int pageIndex, int pageSize)
        {
            return Ok(new { kuvari = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        // GET: api/Kuvars/5
        [ResponseType(typeof(Kuvar))]
        public IHttpActionResult GetKuvar(int id)
        {
            Kuvar kuvar = _manager.GetById(id);
            if (kuvar == null)
            {
                return NotFound();
            }

            return Ok(kuvar);
        }

        // PUT: api/Kuvars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKuvar(int id, Kuvar kuvar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kuvar.MBR)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(kuvar);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Kuvars
        [ResponseType(typeof(Kuvar))]
        public IHttpActionResult PostKuvar(Kuvar kuvar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_manager.Insert(kuvar))
                return CreatedAtRoute("DefaultApi", new { id = kuvar.MBR }, kuvar);
            else
                return BadRequest();
        }

        // DELETE: api/Kuvars/5
        [ResponseType(typeof(Kuvar))]
        public IHttpActionResult DeleteKuvar(int id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(new { kuvari = _manager.GetAll(1, 10), count = _manager.Count() });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public bool AddDeleteJelo(string jeloId, int kuvId, string operation)
        {
            bool ret = false;

            switch (operation)
            {
                case "add":
                    ret = _manager.AddJelo(jeloId, kuvId);
                    break;
                case "delete":
                    ret = _manager.DeleteJelo(jeloId, kuvId);
                    break;
            }

            return ret;
        }

        private bool KuvarExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class PorudzbinasController : ApiController
    {
        private IPorudzbinaManager _manager;

        private PorudzbinasController()
        {
            _manager = new PorudzbinaManager();
        }

        // GET: api/Porudzbinas
        public IHttpActionResult GetPorudzbinas()
        {
            return Ok(_manager.GetAll());
        }

        // GET: api/Porudzbinas/5
        [ResponseType(typeof(Porudzbina))]
        public IHttpActionResult GetPorudzbina(string id)
        {
            Porudzbina porudzbina = _manager.GetById(id);
            if (porudzbina == null)
            {
                return NotFound();
            }

            return Ok(porudzbina);
        }

        // PUT: api/Porudzbinas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPorudzbina(string id, Porudzbina porudzbina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != porudzbina.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(porudzbina);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Porudzbinas
        [ResponseType(typeof(Porudzbina))]
        public IHttpActionResult PostPorudzbina(Porudzbina porudzbina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(porudzbina);
            return Ok(porudzbina);
        }

        // DELETE: api/Porudzbinas/5
        [ResponseType(typeof(Porudzbina))]
        public IHttpActionResult DeletePorudzbina(string id)
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

        private bool PorudzbinaExists(string id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
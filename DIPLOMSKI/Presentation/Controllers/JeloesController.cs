using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class JeloesController : ApiController
    {
        private IJeloManager _manager;

        private JeloesController()
        {
            _manager = new JeloManager();
        }

        // GET: api/Jeloes
        public IHttpActionResult GetJeloes(int pageIndex, int pageSize)
        {
            return Ok(new { jela = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        [HttpGet]
        public IHttpActionResult GetJeloes(int pageIndex, int pageSize, int type)
        {
            return Ok(new { jela = _manager.GetByType(pageIndex, pageSize, type), count = _manager.Count() });
        }

        // GET: api/Jeloes/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult GetJelo(string id)
        {
            Jelo jelo = _manager.GetById(id);
            if (jelo == null)
            {
                return NotFound();
            }

            return Ok(jelo);
        }

        // PUT: api/Jeloes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJelo(string id, Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jelo.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(jelo);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public bool AddDeleteSastojak(int sastojakId, string jeloId, string operation)
        {
            bool ret = false;

            switch (operation)
            {
                case "add":
                    ret = _manager.AddSastojak(sastojakId, jeloId);
                    break;
                case "delete":
                    ret = _manager.DeleteSastojak(sastojakId, jeloId);
                    break;
            }

            return ret;
        }

        // POST: api/Jeloes
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult PostJelo(Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(jelo);
            return CreatedAtRoute("DefaultApi", new { id = jelo.ID }, jelo);
        }

        // DELETE: api/Jeloes/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult DeleteJelo(string id)
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
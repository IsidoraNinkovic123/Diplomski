using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class HipermarketsController : ApiController
    {
        private IHipermarketManager _manager;

        private HipermarketsController()
        {
            _manager = new HipermarketManager();
        }

        // GET: api/Hipermarkets
        public IHttpActionResult GetHipermarkets(int pageIndex, int pageSize)
        {
            return Ok(new { hipermarketi = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        // GET: api/Hipermarkets/5
        [ResponseType(typeof(Hipermarket))]
        public IHttpActionResult GetHipermarket(int id)
        {
            Hipermarket hipermarket = _manager.GetById(id);
            if (hipermarket == null)
            {
                return NotFound();
            }

            return Ok(hipermarket);
        }

        // PUT: api/Hipermarkets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHipermarket(int id, Hipermarket hipermarket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hipermarket.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(hipermarket);

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
        public bool AddDeleteMenadzer(int hipId, int menId, string operation)
        {
            bool ret = false;

            switch (operation)
            {
                case "add":
                    ret = _manager.AddMenadzer(hipId, menId);
                    break;
                case "delete":
                    ret = _manager.DeleteMenadzer(hipId, menId);
                    break;
            }

            return ret;
        }

        // POST: api/Hipermarkets
        [ResponseType(typeof(Hipermarket))]
        public IHttpActionResult PostHipermarket(Hipermarket hipermarket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(hipermarket);
            return CreatedAtRoute("DefaultApi", new { id = hipermarket.ID }, hipermarket);
        }

        // DELETE: api/Hipermarkets/5
        [ResponseType(typeof(Hipermarket))]
        public IHttpActionResult DeleteHipermarket(int id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(new { hipermarketi = _manager.GetAll(1, 9), count = _manager.Count() });
            }
            else
            {
                return BadRequest();
            }
        }

        private bool HipermarketExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class MenadzersController : ApiController
    {
        private IMenadzerManager _manager;

        private MenadzersController()
        {
            _manager = new MenadzerManager();
        }

        // GET: api/Menadzers
        public IHttpActionResult GetMenadzers(int pageIndex, int pageSize)
        {
            return Ok(new { menadzeri = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        [HttpGet]
        public IHttpActionResult GetMenadzers()
        {
            return Ok(_manager.GetAll());
        }

        // GET: api/Menadzers/5
        [ResponseType(typeof(Menadzer))]
        public IHttpActionResult GetMenadzer(int id)
        {
            Menadzer menadzer = _manager.GetById(id);
            if (menadzer == null)
            {
                return NotFound();
            }

            return Ok(menadzer);
        }

        // PUT: api/Menadzers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenadzer(int id, Menadzer menadzer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menadzer.MBR)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(menadzer);

            if (ret)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Menadzers
        [ResponseType(typeof(Menadzer))]
        public IHttpActionResult PostMenadzer(Menadzer menadzer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_manager.Insert(menadzer))
                return CreatedAtRoute("DefaultApi", new { id = menadzer.MBR }, menadzer);
            else
                return BadRequest();
        }

        // DELETE: api/Menadzers/5
        [ResponseType(typeof(Menadzer))]
        public IHttpActionResult DeleteMenadzer(int id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(new { menadzeri = _manager.GetAll(1, 9), count = _manager.Count() });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public bool CheckPassword(string pass)
        {
            return _manager.CheckPassword(pass);
        }

        private bool MenadzerExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
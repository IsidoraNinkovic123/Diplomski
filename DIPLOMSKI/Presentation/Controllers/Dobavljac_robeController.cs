using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class Dobavljac_robeController : ApiController
    {
        private IDobavljacRobeManager _manager;

        private Dobavljac_robeController()
        {
            _manager = new DobavljacRobeManager();
        }

        // GET: api/Dobavljac_robe
        public IHttpActionResult GetDobavljac_robe(int pageIndex, int pageSize)
        {
            return Ok(new { dobavljaci = _manager.GetAll(pageIndex, pageSize), count = _manager.Count() });
        }

        // GET: api/Dobavljac_robe/5
        [ResponseType(typeof(Dobavljac_robe))]
        public IHttpActionResult GetDobavljac_robe(int id)
        {
            Dobavljac_robe dobavljac_robe = _manager.GetById(id);
            if (dobavljac_robe == null)
            {
                return NotFound();
            }

            return Ok(dobavljac_robe);
        }

        // PUT: api/Dobavljac_robe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDobavljac_robe(int id, Dobavljac_robe dobavljac_robe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dobavljac_robe.ID)
            {
                return BadRequest();
            }

            bool ret = _manager.Update(dobavljac_robe);

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
        public bool AddDeleteMenadzer(int dobId, int menId, string operation)
        {
            bool ret = false;

            switch (operation)
            {
                case "add":
                    ret = _manager.AddMenadzer(dobId, menId);
                    break;
                case "delete":
                    ret = _manager.DeleteMenadzer(dobId, menId);
                    break;
            }

            return ret;
        }

        // POST: api/Dobavljac_robe
        [ResponseType(typeof(Dobavljac_robe))]
        public IHttpActionResult PostDobavljac_robe(Dobavljac_robe dobavljac_robe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(dobavljac_robe);
            return CreatedAtRoute("DefaultApi", new { id = dobavljac_robe.ID }, dobavljac_robe);
        }

        // DELETE: api/Dobavljac_robe/5
        [ResponseType(typeof(Dobavljac_robe))]
        public IHttpActionResult DeleteDobavljac_robe(int id)
        {
            bool ret = _manager.Delete(id);

            if (ret)
            {
                return Ok(new { dobavljaci = _manager.GetAll(1, 9), count = _manager.Count() });
            }
            else
            {
                return BadRequest();
            }
        }

        private bool Dobavljac_robeExists(int id)
        {
            return _manager.GetById(id) != null;
        }
    }
}
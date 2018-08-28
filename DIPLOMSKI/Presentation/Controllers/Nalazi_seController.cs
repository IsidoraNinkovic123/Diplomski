using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;
using BLL.Managers;
using Common.Interfaces.Managers;

namespace Presentation.Controllers
{
    public class Nalazi_seController : ApiController
    {
        private INalaziSeManager _manager;

        private Nalazi_seController()
        {
            _manager = new NalaziSeManager();
        }

        // POST: api/Nalazi_se
        [ResponseType(typeof(Nalazi_se))]
        public IHttpActionResult PostNalazi_se(Nalazi_se nalazi_se)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manager.Insert(nalazi_se);
            return CreatedAtRoute("DefaultApi", new { }, nalazi_se);
        }

        /*public bool InRelation(string stavkaId)
        {
            return _manager.InRelation(stavkaId);
        }*/
    }
}
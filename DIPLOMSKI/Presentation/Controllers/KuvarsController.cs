using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Common.Database;

namespace Presentation.Controllers
{
    public class KuvarsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Kuvars
        public IQueryable<Kuvar> GetKuvars()
        {
            return db.Kuvars;
        }

        // GET: api/Kuvars/5
        [ResponseType(typeof(Kuvar))]
        public IHttpActionResult GetKuvar(string id)
        {
            Kuvar kuvar = db.Kuvars.Find(id);
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

            db.Entry(kuvar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KuvarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kuvars
        [ResponseType(typeof(Kuvar))]
        public IHttpActionResult PostKuvar(Kuvar kuvar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kuvars.Add(kuvar);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KuvarExists(kuvar.MBR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kuvar.MBR }, kuvar);
        }

        // DELETE: api/Kuvars/5
        [ResponseType(typeof(Kuvar))]
        public IHttpActionResult DeleteKuvar(string id)
        {
            Kuvar kuvar = db.Kuvars.Find(id);
            if (kuvar == null)
            {
                return NotFound();
            }

            db.Kuvars.Remove(kuvar);
            db.SaveChanges();

            return Ok(kuvar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KuvarExists(int id)
        {
            return db.Kuvars.Count(e => e.MBR == id) > 0;
        }
    }
}
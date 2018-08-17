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
    public class DostavljacsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Dostavljacs
        public IQueryable<Dostavljac> GetDostavljacs()
        {
            return db.Dostavljacs;
        }

        // GET: api/Dostavljacs/5
        [ResponseType(typeof(Dostavljac))]
        public IHttpActionResult GetDostavljac(string id)
        {
            Dostavljac dostavljac = db.Dostavljacs.Find(id);
            if (dostavljac == null)
            {
                return NotFound();
            }

            return Ok(dostavljac);
        }

        // PUT: api/Dostavljacs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDostavljac(int id, Dostavljac dostavljac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dostavljac.MBR)
            {
                return BadRequest();
            }

            db.Entry(dostavljac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DostavljacExists(id))
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

        // POST: api/Dostavljacs
        [ResponseType(typeof(Dostavljac))]
        public IHttpActionResult PostDostavljac(Dostavljac dostavljac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dostavljacs.Add(dostavljac);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DostavljacExists(dostavljac.MBR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dostavljac.MBR }, dostavljac);
        }

        // DELETE: api/Dostavljacs/5
        [ResponseType(typeof(Dostavljac))]
        public IHttpActionResult DeleteDostavljac(string id)
        {
            Dostavljac dostavljac = db.Dostavljacs.Find(id);
            if (dostavljac == null)
            {
                return NotFound();
            }

            db.Dostavljacs.Remove(dostavljac);
            db.SaveChanges();

            return Ok(dostavljac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DostavljacExists(int id)
        {
            return db.Dostavljacs.Count(e => e.MBR == id) > 0;
        }
    }
}
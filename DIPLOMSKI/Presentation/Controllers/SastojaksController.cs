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
    public class SastojaksController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Sastojaks
        public IQueryable<Sastojak> GetSastojaks()
        {
            return db.Sastojaks;
        }

        // GET: api/Sastojaks/5
        [ResponseType(typeof(Sastojak))]
        public IHttpActionResult GetSastojak(int id)
        {
            Sastojak sastojak = db.Sastojaks.Find(id);
            if (sastojak == null)
            {
                return NotFound();
            }

            return Ok(sastojak);
        }

        // PUT: api/Sastojaks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSastojak(int id, Sastojak sastojak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sastojak.ID)
            {
                return BadRequest();
            }

            db.Entry(sastojak).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SastojakExists(id))
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

        // POST: api/Sastojaks
        [ResponseType(typeof(Sastojak))]
        public IHttpActionResult PostSastojak(Sastojak sastojak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sastojaks.Add(sastojak);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SastojakExists(sastojak.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sastojak.ID }, sastojak);
        }

        // DELETE: api/Sastojaks/5
        [ResponseType(typeof(Sastojak))]
        public IHttpActionResult DeleteSastojak(int id)
        {
            Sastojak sastojak = db.Sastojaks.Find(id);
            if (sastojak == null)
            {
                return NotFound();
            }

            db.Sastojaks.Remove(sastojak);
            db.SaveChanges();

            return Ok(sastojak);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SastojakExists(int id)
        {
            return db.Sastojaks.Count(e => e.ID == id) > 0;
        }
    }
}
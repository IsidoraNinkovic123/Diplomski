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
    public class KonobarsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Konobars
        public IQueryable<Konobar> GetKonobars()
        {
            return db.Konobars;
        }

        // GET: api/Konobars/5
        [ResponseType(typeof(Konobar))]
        public IHttpActionResult GetKonobar(string id)
        {
            Konobar konobar = db.Konobars.Find(id);
            if (konobar == null)
            {
                return NotFound();
            }

            return Ok(konobar);
        }

        // PUT: api/Konobars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKonobar(int id, Konobar konobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != konobar.MBR)
            {
                return BadRequest();
            }

            db.Entry(konobar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonobarExists(id))
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

        // POST: api/Konobars
        [ResponseType(typeof(Konobar))]
        public IHttpActionResult PostKonobar(Konobar konobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Konobars.Add(konobar);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KonobarExists(konobar.MBR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = konobar.MBR }, konobar);
        }

        // DELETE: api/Konobars/5
        [ResponseType(typeof(Konobar))]
        public IHttpActionResult DeleteKonobar(string id)
        {
            Konobar konobar = db.Konobars.Find(id);
            if (konobar == null)
            {
                return NotFound();
            }

            db.Konobars.Remove(konobar);
            db.SaveChanges();

            return Ok(konobar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KonobarExists(int id)
        {
            return db.Konobars.Count(e => e.MBR == id) > 0;
        }
    }
}
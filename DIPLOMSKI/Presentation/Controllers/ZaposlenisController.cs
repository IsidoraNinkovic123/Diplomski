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
    public class ZaposlenisController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Zaposlenis
        public IQueryable<Zaposleni> GetZaposlenis()
        {
            return db.Zaposlenis;
        }

        // GET: api/Zaposlenis/5
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult GetZaposleni(string id)
        {
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return NotFound();
            }

            return Ok(zaposleni);
        }

        // PUT: api/Zaposlenis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZaposleni(string id, Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zaposleni.MBR)
            {
                return BadRequest();
            }

            db.Entry(zaposleni).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaposleniExists(id))
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

        // POST: api/Zaposlenis
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult PostZaposleni(Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zaposlenis.Add(zaposleni);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ZaposleniExists(zaposleni.MBR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zaposleni.MBR }, zaposleni);
        }

        // DELETE: api/Zaposlenis/5
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult DeleteZaposleni(string id)
        {
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return NotFound();
            }

            db.Zaposlenis.Remove(zaposleni);
            db.SaveChanges();

            return Ok(zaposleni);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZaposleniExists(string id)
        {
            return db.Zaposlenis.Count(e => e.MBR == id) > 0;
        }
    }
}
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
    public class Stavka_menijaController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Stavka_menija
        public IQueryable<Stavka_menija> GetStavka_menija()
        {
            return db.Stavka_menija;
        }

        // GET: api/Stavka_menija/5
        [ResponseType(typeof(Stavka_menija))]
        public IHttpActionResult GetStavka_menija(string id)
        {
            Stavka_menija stavka_menija = db.Stavka_menija.Find(id);
            if (stavka_menija == null)
            {
                return NotFound();
            }

            return Ok(stavka_menija);
        }

        // PUT: api/Stavka_menija/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStavka_menija(string id, Stavka_menija stavka_menija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavka_menija.ID)
            {
                return BadRequest();
            }

            db.Entry(stavka_menija).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stavka_menijaExists(id))
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

        // POST: api/Stavka_menija
        [ResponseType(typeof(Stavka_menija))]
        public IHttpActionResult PostStavka_menija(Stavka_menija stavka_menija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stavka_menija.Add(stavka_menija);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Stavka_menijaExists(stavka_menija.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stavka_menija.ID }, stavka_menija);
        }

        // DELETE: api/Stavka_menija/5
        [ResponseType(typeof(Stavka_menija))]
        public IHttpActionResult DeleteStavka_menija(string id)
        {
            Stavka_menija stavka_menija = db.Stavka_menija.Find(id);
            if (stavka_menija == null)
            {
                return NotFound();
            }

            db.Stavka_menija.Remove(stavka_menija);
            db.SaveChanges();

            return Ok(stavka_menija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Stavka_menijaExists(string id)
        {
            return db.Stavka_menija.Count(e => e.ID == id) > 0;
        }
    }
}
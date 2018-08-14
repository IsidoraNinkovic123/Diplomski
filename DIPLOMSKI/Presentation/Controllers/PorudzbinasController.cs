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
    public class PorudzbinasController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Porudzbinas
        public IQueryable<Porudzbina> GetPorudzbinas()
        {
            return db.Porudzbinas;
        }

        // GET: api/Porudzbinas/5
        [ResponseType(typeof(Porudzbina))]
        public IHttpActionResult GetPorudzbina(string id)
        {
            Porudzbina porudzbina = db.Porudzbinas.Find(id);
            if (porudzbina == null)
            {
                return NotFound();
            }

            return Ok(porudzbina);
        }

        // PUT: api/Porudzbinas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPorudzbina(string id, Porudzbina porudzbina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != porudzbina.ID)
            {
                return BadRequest();
            }

            db.Entry(porudzbina).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorudzbinaExists(id))
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

        // POST: api/Porudzbinas
        [ResponseType(typeof(Porudzbina))]
        public IHttpActionResult PostPorudzbina(Porudzbina porudzbina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Porudzbinas.Add(porudzbina);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PorudzbinaExists(porudzbina.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = porudzbina.ID }, porudzbina);
        }

        // DELETE: api/Porudzbinas/5
        [ResponseType(typeof(Porudzbina))]
        public IHttpActionResult DeletePorudzbina(string id)
        {
            Porudzbina porudzbina = db.Porudzbinas.Find(id);
            if (porudzbina == null)
            {
                return NotFound();
            }

            db.Porudzbinas.Remove(porudzbina);
            db.SaveChanges();

            return Ok(porudzbina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PorudzbinaExists(string id)
        {
            return db.Porudzbinas.Count(e => e.ID == id) > 0;
        }
    }
}
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
    public class JeloesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Jeloes
        public IQueryable<Jelo> GetJeloes()
        {
            return db.Jeloes;
        }

        // GET: api/Jeloes/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult GetJelo(string id)
        {
            Jelo jelo = db.Jeloes.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            return Ok(jelo);
        }

        // PUT: api/Jeloes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJelo(string id, Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jelo.ID)
            {
                return BadRequest();
            }

            db.Entry(jelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeloExists(id))
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

        // POST: api/Jeloes
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult PostJelo(Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jeloes.Add(jelo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JeloExists(jelo.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jelo.ID }, jelo);
        }

        // DELETE: api/Jeloes/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult DeleteJelo(string id)
        {
            Jelo jelo = db.Jeloes.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            db.Jeloes.Remove(jelo);
            db.SaveChanges();

            return Ok(jelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JeloExists(string id)
        {
            return db.Jeloes.Count(e => e.ID == id) > 0;
        }
    }
}
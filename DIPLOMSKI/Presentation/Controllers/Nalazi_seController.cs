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
    public class Nalazi_seController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Nalazi_se
        public IQueryable<Nalazi_se> GetNalazi_se()
        {
            return db.Nalazi_se;
        }

        // GET: api/Nalazi_se/5
        [ResponseType(typeof(Nalazi_se))]
        public IHttpActionResult GetNalazi_se(string id)
        {
            Nalazi_se nalazi_se = db.Nalazi_se.Find(id);
            if (nalazi_se == null)
            {
                return NotFound();
            }

            return Ok(nalazi_se);
        }

        // PUT: api/Nalazi_se/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNalazi_se(string id, Nalazi_se nalazi_se)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nalazi_se.Porudzbina_ID)
            {
                return BadRequest();
            }

            db.Entry(nalazi_se).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Nalazi_seExists(id))
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

        // POST: api/Nalazi_se
        [ResponseType(typeof(Nalazi_se))]
        public IHttpActionResult PostNalazi_se(Nalazi_se nalazi_se)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nalazi_se.Add(nalazi_se);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Nalazi_seExists(nalazi_se.Porudzbina_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nalazi_se.Porudzbina_ID }, nalazi_se);
        }

        // DELETE: api/Nalazi_se/5
        [ResponseType(typeof(Nalazi_se))]
        public IHttpActionResult DeleteNalazi_se(string id)
        {
            Nalazi_se nalazi_se = db.Nalazi_se.Find(id);
            if (nalazi_se == null)
            {
                return NotFound();
            }

            db.Nalazi_se.Remove(nalazi_se);
            db.SaveChanges();

            return Ok(nalazi_se);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Nalazi_seExists(string id)
        {
            return db.Nalazi_se.Count(e => e.Porudzbina_ID == id) > 0;
        }
    }
}
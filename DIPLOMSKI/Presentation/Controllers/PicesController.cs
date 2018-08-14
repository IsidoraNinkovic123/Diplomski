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
    public class PicesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Pices
        public IQueryable<Pice> GetPices()
        {
            return db.Pices;
        }

        // GET: api/Pices/5
        [ResponseType(typeof(Pice))]
        public IHttpActionResult GetPice(string id)
        {
            Pice pice = db.Pices.Find(id);
            if (pice == null)
            {
                return NotFound();
            }

            return Ok(pice);
        }

        // PUT: api/Pices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPice(string id, Pice pice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pice.ID)
            {
                return BadRequest();
            }

            db.Entry(pice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiceExists(id))
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

        // POST: api/Pices
        [ResponseType(typeof(Pice))]
        public IHttpActionResult PostPice(Pice pice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pices.Add(pice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PiceExists(pice.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pice.ID }, pice);
        }

        // DELETE: api/Pices/5
        [ResponseType(typeof(Pice))]
        public IHttpActionResult DeletePice(string id)
        {
            Pice pice = db.Pices.Find(id);
            if (pice == null)
            {
                return NotFound();
            }

            db.Pices.Remove(pice);
            db.SaveChanges();

            return Ok(pice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PiceExists(string id)
        {
            return db.Pices.Count(e => e.ID == id) > 0;
        }
    }
}
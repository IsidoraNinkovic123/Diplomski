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
    public class RestoransController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Restorans
        public IQueryable<Restoran> GetRestorans()
        {
            return db.Restorans;
        }

        // GET: api/Restorans/5
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult GetRestoran(int id)
        {
            Restoran restoran = db.Restorans.Find(id);
            if (restoran == null)
            {
                return NotFound();
            }

            return Ok(restoran);
        }

        // PUT: api/Restorans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestoran(int id, Restoran restoran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restoran.ID)
            {
                return BadRequest();
            }

            db.Entry(restoran).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestoranExists(id))
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

        // POST: api/Restorans
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult PostRestoran(Restoran restoran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restorans.Add(restoran);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restoran.ID }, restoran);
        }

        // DELETE: api/Restorans/5
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult DeleteRestoran(int id)
        {
            Restoran restoran = db.Restorans.Find(id);
            if (restoran == null)
            {
                return NotFound();
            }

            db.Restorans.Remove(restoran);
            db.SaveChanges();

            return Ok(restoran);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestoranExists(int id)
        {
            return db.Restorans.Count(e => e.ID == id) > 0;
        }
    }
}
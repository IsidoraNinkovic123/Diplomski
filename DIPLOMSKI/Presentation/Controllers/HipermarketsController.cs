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
    public class HipermarketsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Hipermarkets
        public IQueryable<Hipermarket> GetHipermarkets()
        {
            return db.Hipermarkets;
        }

        // GET: api/Hipermarkets/5
        [ResponseType(typeof(Hipermarket))]
        public IHttpActionResult GetHipermarket(int id)
        {
            Hipermarket hipermarket = db.Hipermarkets.Find(id);
            if (hipermarket == null)
            {
                return NotFound();
            }

            return Ok(hipermarket);
        }

        // PUT: api/Hipermarkets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHipermarket(int id, Hipermarket hipermarket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hipermarket.ID)
            {
                return BadRequest();
            }

            db.Entry(hipermarket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HipermarketExists(id))
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

        // POST: api/Hipermarkets
        [ResponseType(typeof(Hipermarket))]
        public IHttpActionResult PostHipermarket(Hipermarket hipermarket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hipermarkets.Add(hipermarket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hipermarket.ID }, hipermarket);
        }

        // DELETE: api/Hipermarkets/5
        [ResponseType(typeof(Hipermarket))]
        public IHttpActionResult DeleteHipermarket(int id)
        {
            Hipermarket hipermarket = db.Hipermarkets.Find(id);
            if (hipermarket == null)
            {
                return NotFound();
            }

            db.Hipermarkets.Remove(hipermarket);
            db.SaveChanges();

            return Ok(hipermarket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HipermarketExists(int id)
        {
            return db.Hipermarkets.Count(e => e.ID == id) > 0;
        }
    }
}
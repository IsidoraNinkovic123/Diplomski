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
    public class MenisController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Menis
        public IQueryable<Meni> GetMenis()
        {
            return db.Menis;
        }

        // GET: api/Menis/5
        [ResponseType(typeof(Meni))]
        public IHttpActionResult GetMeni(int id)
        {
            Meni meni = db.Menis.Find(id);
            if (meni == null)
            {
                return NotFound();
            }

            return Ok(meni);
        }

        // PUT: api/Menis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeni(int id, Meni meni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meni.ID)
            {
                return BadRequest();
            }

            db.Entry(meni).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeniExists(id))
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

        // POST: api/Menis
        [ResponseType(typeof(Meni))]
        public IHttpActionResult PostMeni(Meni meni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menis.Add(meni);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meni.ID }, meni);
        }

        // DELETE: api/Menis/5
        [ResponseType(typeof(Meni))]
        public IHttpActionResult DeleteMeni(int id)
        {
            Meni meni = db.Menis.Find(id);
            if (meni == null)
            {
                return NotFound();
            }

            db.Menis.Remove(meni);
            db.SaveChanges();

            return Ok(meni);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeniExists(int id)
        {
            return db.Menis.Count(e => e.ID == id) > 0;
        }
    }
}
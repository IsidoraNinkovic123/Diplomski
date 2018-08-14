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
    public class Dobavljac_robeController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Dobavljac_robe
        public IQueryable<Dobavljac_robe> GetDobavljac_robe()
        {
            return db.Dobavljac_robe;
        }

        // GET: api/Dobavljac_robe/5
        [ResponseType(typeof(Dobavljac_robe))]
        public IHttpActionResult GetDobavljac_robe(int id)
        {
            Dobavljac_robe dobavljac_robe = db.Dobavljac_robe.Find(id);
            if (dobavljac_robe == null)
            {
                return NotFound();
            }

            return Ok(dobavljac_robe);
        }

        // PUT: api/Dobavljac_robe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDobavljac_robe(int id, Dobavljac_robe dobavljac_robe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dobavljac_robe.ID)
            {
                return BadRequest();
            }

            db.Entry(dobavljac_robe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dobavljac_robeExists(id))
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

        // POST: api/Dobavljac_robe
        [ResponseType(typeof(Dobavljac_robe))]
        public IHttpActionResult PostDobavljac_robe(Dobavljac_robe dobavljac_robe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dobavljac_robe.Add(dobavljac_robe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dobavljac_robe.ID }, dobavljac_robe);
        }

        // DELETE: api/Dobavljac_robe/5
        [ResponseType(typeof(Dobavljac_robe))]
        public IHttpActionResult DeleteDobavljac_robe(int id)
        {
            Dobavljac_robe dobavljac_robe = db.Dobavljac_robe.Find(id);
            if (dobavljac_robe == null)
            {
                return NotFound();
            }

            db.Dobavljac_robe.Remove(dobavljac_robe);
            db.SaveChanges();

            return Ok(dobavljac_robe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Dobavljac_robeExists(int id)
        {
            return db.Dobavljac_robe.Count(e => e.ID == id) > 0;
        }
    }
}
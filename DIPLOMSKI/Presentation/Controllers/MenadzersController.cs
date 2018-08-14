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
    public class MenadzersController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Menadzers
        public IQueryable<Menadzer> GetMenadzers()
        {
            return db.Menadzers;
        }

        // GET: api/Menadzers/5
        [ResponseType(typeof(Menadzer))]
        public IHttpActionResult GetMenadzer(string id)
        {
            Menadzer menadzer = db.Menadzers.Find(id);
            if (menadzer == null)
            {
                return NotFound();
            }

            return Ok(menadzer);
        }

        // PUT: api/Menadzers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenadzer(string id, Menadzer menadzer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menadzer.MBR)
            {
                return BadRequest();
            }

            db.Entry(menadzer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenadzerExists(id))
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

        // POST: api/Menadzers
        [ResponseType(typeof(Menadzer))]
        public IHttpActionResult PostMenadzer(Menadzer menadzer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menadzers.Add(menadzer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MenadzerExists(menadzer.MBR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = menadzer.MBR }, menadzer);
        }

        // DELETE: api/Menadzers/5
        [ResponseType(typeof(Menadzer))]
        public IHttpActionResult DeleteMenadzer(string id)
        {
            Menadzer menadzer = db.Menadzers.Find(id);
            if (menadzer == null)
            {
                return NotFound();
            }

            db.Menadzers.Remove(menadzer);
            db.SaveChanges();

            return Ok(menadzer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenadzerExists(string id)
        {
            return db.Menadzers.Count(e => e.MBR == id) > 0;
        }
    }
}
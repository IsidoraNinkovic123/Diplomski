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
using Common.Interfaces.Managers;
using BLL.Managers;

namespace Presentation.Controllers
{
    public class DostavasController : ApiController
    {
        private IDostavaManager _manager;

        public DostavasController()
        {
            _manager = new DostavaManager();
        }

        //// GET: api/Dostavas
        //public IQueryable<Dostava> GetDostavas()
        //{
        //    return _manager.GetAll();
        //}

        //// GET: api/Dostavas/5
        //[ResponseType(typeof(Dostava))]
        //public IHttpActionResult GetDostava(string id)
        //{
        //    Dostava dostava = db.Dostavas.Find(id);
        //    if (dostava == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dostava);
        //}

        //// PUT: api/Dostavas/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDostava(string id, Dostava dostava)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != dostava.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(dostava).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DostavaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Dostavas
        //[ResponseType(typeof(Dostava))]
        //public IHttpActionResult PostDostava(Dostava dostava)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Dostavas.Add(dostava);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DostavaExists(dostava.ID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = dostava.ID }, dostava);
        //}

        //// DELETE: api/Dostavas/5
        //[ResponseType(typeof(Dostava))]
        //public IHttpActionResult DeleteDostava(string id)
        //{
        //    Dostava dostava = db.Dostavas.Find(id);
        //    if (dostava == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Dostavas.Remove(dostava);
        //    db.SaveChanges();

        //    return Ok(dostava);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool DostavaExists(string id)
        //{
        //    return db.Dostavas.Count(e => e.ID == id) > 0;
        //}
    }
}
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
using ReverseQuestWeb.Models;

namespace ReverseQuestWeb.Controllers.RefTables
{
    [RoutePrefix("refapi/v1")]
    public class refSearchWindowController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refSearchWindow
        public IQueryable<ref_search_window> GetRefSearchWindow()
        {
            return db.ref_search_window;
        }

        // GET: api/refSearchWindow/5
        [ResponseType(typeof(ref_search_window))]
        public IHttpActionResult GetRefSearchWindow(int id)
        {
            ref_search_window ref_search_window = db.ref_search_window.Find(id);
            if (ref_search_window == null)
            {
                return NotFound();
            }

            return Ok(ref_search_window);
        }

        // PUT: api/refSearchWindow/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefSearchWindow(int id, ref_search_window ref_search_window)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_search_window.search_window_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_search_window).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_search_windowExists(id))
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

        // POST: api/refSearchWindow
        [ResponseType(typeof(ref_search_window))]
        public IHttpActionResult PostRefSearchWindow(ref_search_window ref_search_window)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_search_window.Add(ref_search_window);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_search_windowExists(ref_search_window.search_window_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_search_window.search_window_skey }, ref_search_window);
        }

        // DELETE: api/refSearchWindow/5
        [ResponseType(typeof(ref_search_window))]
        public IHttpActionResult DeleteRefSearchWindow(int id)
        {
            ref_search_window ref_search_window = db.ref_search_window.Find(id);
            if (ref_search_window == null)
            {
                return NotFound();
            }

            db.ref_search_window.Remove(ref_search_window);
            db.SaveChanges();

            return Ok(ref_search_window);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_search_windowExists(int id)
        {
            return db.ref_search_window.Count(e => e.search_window_skey == id) > 0;
        }
    }
}
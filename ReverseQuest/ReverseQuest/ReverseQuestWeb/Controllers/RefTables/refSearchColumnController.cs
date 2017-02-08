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
    public class refSearchColumnController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refSearchColumn
        public IQueryable<ref_search_column> GetRefSearchColumn()
        {
            return db.ref_search_column;
        }

        // GET: api/refSearchColumn/5
        [ResponseType(typeof(ref_search_column))]
        public IHttpActionResult GetRefSearchColumn(int id)
        {
            ref_search_column ref_search_column = db.ref_search_column.Find(id);
            if (ref_search_column == null)
            {
                return NotFound();
            }

            return Ok(ref_search_column);
        }

        // GET: api/GetRefSearchColumnBySearchWindowSkey/5
        [ResponseType(typeof(List<ref_search_column>))]
        public IHttpActionResult GetRefSearchColumnBySearchWindowSkey(int SearchWindowSkey)
        {
            List<ref_search_column> ref_search_columns = db.ref_search_column.Where(a => a.search_window_skey == SearchWindowSkey).ToList();

            if (ref_search_columns == null)
            {
                return NotFound();
            }

            return Ok(ref_search_columns);
        }

        // PUT: api/refSearchColumn/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefSearchColumn(int id, ref_search_column ref_search_column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_search_column.search_column_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_search_column).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_search_columnExists(id))
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

        // POST: api/refSearchColumn
        [ResponseType(typeof(ref_search_column))]
        public IHttpActionResult PostRefSearchColumn(ref_search_column ref_search_column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_search_column.Add(ref_search_column);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_search_column.search_column_skey }, ref_search_column);
        }

        // DELETE: api/refSearchColumn/5
        [ResponseType(typeof(ref_search_column))]
        public IHttpActionResult DeleteRefSearchColumn(int id)
        {
            ref_search_column ref_search_column = db.ref_search_column.Find(id);
            if (ref_search_column == null)
            {
                return NotFound();
            }

            db.ref_search_column.Remove(ref_search_column);
            db.SaveChanges();

            return Ok(ref_search_column);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_search_columnExists(int id)
        {
            return db.ref_search_column.Count(e => e.search_column_skey == id) > 0;
        }
    }
}
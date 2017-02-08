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
    public class refTransactionColumnController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTransactionColumn
        public IQueryable<ref_transaction_column> GetRefTransactionColumn()
        {
            return db.ref_transaction_column;
        }

        // GET: api/refTransactionColumn/5
        [ResponseType(typeof(ref_transaction_column))]
        public IHttpActionResult GetRefTransactionColumn(string id)
        {
            ref_transaction_column ref_transaction_column = db.ref_transaction_column.Find(id);
            if (ref_transaction_column == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_column);
        }

        // GET: api/GetRefTransactionColumnActive/
        [ResponseType(typeof(List<ref_transaction_column>))]
        public IHttpActionResult GetRefTransactionColumnActive()
        {
            List<ref_transaction_column> ref_transaction_columns = db.ref_transaction_column.Where(a => a.status_skey == 1).ToList();

            if (ref_transaction_columns == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_columns);
        }

        // PUT: api/refTransactionColumn/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTransactionColumn(string id, ref_transaction_column ref_transaction_column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_transaction_column.transaction_column)
            {
                return BadRequest();
            }

            db.Entry(ref_transaction_column).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_transaction_columnExists(id))
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

        // POST: api/refTransactionColumn
        [ResponseType(typeof(ref_transaction_column))]
        public IHttpActionResult PostRefTransactionColumn(ref_transaction_column ref_transaction_column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_transaction_column.Add(ref_transaction_column);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_transaction_columnExists(ref_transaction_column.transaction_column))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_transaction_column.transaction_column }, ref_transaction_column);
        }

        // DELETE: api/refTransactionColumn/5
        [ResponseType(typeof(ref_transaction_column))]
        public IHttpActionResult DeleteRefTransactionColumn(string id)
        {
            ref_transaction_column ref_transaction_column = db.ref_transaction_column.Find(id);
            if (ref_transaction_column == null)
            {
                return NotFound();
            }

            db.ref_transaction_column.Remove(ref_transaction_column);
            db.SaveChanges();

            return Ok(ref_transaction_column);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_transaction_columnExists(string id)
        {
            return db.ref_transaction_column.Count(e => e.transaction_column == id) > 0;
        }
    }
}
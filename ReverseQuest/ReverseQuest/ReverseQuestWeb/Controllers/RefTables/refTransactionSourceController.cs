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
    public class refTransactionSourceController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTransactionSource
        public IQueryable<ref_transaction_source> GetRefTransactionSource()
        {
            return db.ref_transaction_source;
        }

        // GET: api/refTransactionSource/5
        [ResponseType(typeof(ref_transaction_source))]
        public IHttpActionResult GetRefTransactionSource(string id)
        {
            ref_transaction_source ref_transaction_source = db.ref_transaction_source.Find(id);
            if (ref_transaction_source == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_source);
        }

        // GET: api/GetRefTransactionSourceActive/
        [ResponseType(typeof(List<ref_transaction_source>))]
        public IHttpActionResult GetRefTransactionSourceActive()
        {
            List<ref_transaction_source> ref_transaction_sources = db.ref_transaction_source.Where(a => a.status_skey == 1).ToList();

            if (ref_transaction_sources == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_sources);
        }

        // PUT: api/refTransactionSource/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTransactionSource(string id, ref_transaction_source ref_transaction_source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_transaction_source.transaction_source)
            {
                return BadRequest();
            }

            db.Entry(ref_transaction_source).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_transaction_sourceExists(id))
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

        // POST: api/refTransactionSource
        [ResponseType(typeof(ref_transaction_source))]
        public IHttpActionResult PostRefTransactionSource(ref_transaction_source ref_transaction_source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_transaction_source.Add(ref_transaction_source);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_transaction_sourceExists(ref_transaction_source.transaction_source))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_transaction_source.transaction_source }, ref_transaction_source);
        }

        // DELETE: api/refTransactionSource/5
        [ResponseType(typeof(ref_transaction_source))]
        public IHttpActionResult DeleteRefTransactionSource(string id)
        {
            ref_transaction_source ref_transaction_source = db.ref_transaction_source.Find(id);
            if (ref_transaction_source == null)
            {
                return NotFound();
            }

            db.ref_transaction_source.Remove(ref_transaction_source);
            db.SaveChanges();

            return Ok(ref_transaction_source);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_transaction_sourceExists(string id)
        {
            return db.ref_transaction_source.Count(e => e.transaction_source == id) > 0;
        }
    }
}
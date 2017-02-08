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
    public class refTransactionOriginController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTransactionOrigin
        public IQueryable<ref_transaction_origin> GetRefTransactionOrigin()
        {
            return db.ref_transaction_origin;
        }

        // GET: api/refTransactionOrigin/5
        [ResponseType(typeof(ref_transaction_origin))]
        public IHttpActionResult GetRefTransactionOrigin(string id)
        {
            ref_transaction_origin ref_transaction_origin = db.ref_transaction_origin.Find(id);
            if (ref_transaction_origin == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_origin);
        }

        // GET: api/GetRefTransactionOriginActive/
        [ResponseType(typeof(List<ref_transaction_origin>))]
        public IHttpActionResult GetRefTransactionOriginActive()
        {
            List<ref_transaction_origin> ref_transaction_origins = db.ref_transaction_origin.Where(a => a.status_skey == 1).ToList();

            if (ref_transaction_origins == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_origins);
        }

        // PUT: api/refTransactionOrigin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTransactionOrigin(string id, ref_transaction_origin ref_transaction_origin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_transaction_origin.transaction_origin)
            {
                return BadRequest();
            }

            db.Entry(ref_transaction_origin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_transaction_originExists(id))
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

        // POST: api/refTransactionOrigin
        [ResponseType(typeof(ref_transaction_origin))]
        public IHttpActionResult PostRefTransactionOrigin(ref_transaction_origin ref_transaction_origin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_transaction_origin.Add(ref_transaction_origin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_transaction_originExists(ref_transaction_origin.transaction_origin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_transaction_origin.transaction_origin }, ref_transaction_origin);
        }

        // DELETE: api/refTransactionOrigin/5
        [ResponseType(typeof(ref_transaction_origin))]
        public IHttpActionResult DeleteRefTransactionOrigin(string id)
        {
            ref_transaction_origin ref_transaction_origin = db.ref_transaction_origin.Find(id);
            if (ref_transaction_origin == null)
            {
                return NotFound();
            }

            db.ref_transaction_origin.Remove(ref_transaction_origin);
            db.SaveChanges();

            return Ok(ref_transaction_origin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_transaction_originExists(string id)
        {
            return db.ref_transaction_origin.Count(e => e.transaction_origin == id) > 0;
        }
    }
}
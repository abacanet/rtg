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
    public class refTransactionAdjustmentReasonController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTransactionAdjustmentReason
        public IQueryable<ref_transaction_adjustment_reason> GetRefTransactionAdjustmentReason()
        {
            return db.ref_transaction_adjustment_reason;
        }

        // GET: api/refTransactionAdjustmentReason/5
        [ResponseType(typeof(ref_transaction_adjustment_reason))]
        public IHttpActionResult GetRefTransactionAdjustmentReason(int id)
        {
            ref_transaction_adjustment_reason ref_transaction_adjustment_reason = db.ref_transaction_adjustment_reason.Find(id);
            if (ref_transaction_adjustment_reason == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_adjustment_reason);
        }



        // PUT: api/refTransactionAdjustmentReason/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTransactionAdjustmentReason(int id, ref_transaction_adjustment_reason ref_transaction_adjustment_reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_transaction_adjustment_reason.transaction_adjustment_reason_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_transaction_adjustment_reason).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_transaction_adjustment_reasonExists(id))
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

        // POST: api/refTransactionAdjustmentReason
        [ResponseType(typeof(ref_transaction_adjustment_reason))]
        public IHttpActionResult PostRefTransactionAdjustmentReason(ref_transaction_adjustment_reason ref_transaction_adjustment_reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_transaction_adjustment_reason.Add(ref_transaction_adjustment_reason);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_transaction_adjustment_reasonExists(ref_transaction_adjustment_reason.transaction_adjustment_reason_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_transaction_adjustment_reason.transaction_adjustment_reason_skey }, ref_transaction_adjustment_reason);
        }

        // DELETE: api/refTransactionAdjustmentReason/5
        [ResponseType(typeof(ref_transaction_adjustment_reason))]
        public IHttpActionResult DeleteRefTransactionAdjustmentReason(int id)
        {
            ref_transaction_adjustment_reason ref_transaction_adjustment_reason = db.ref_transaction_adjustment_reason.Find(id);
            if (ref_transaction_adjustment_reason == null)
            {
                return NotFound();
            }

            db.ref_transaction_adjustment_reason.Remove(ref_transaction_adjustment_reason);
            db.SaveChanges();

            return Ok(ref_transaction_adjustment_reason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_transaction_adjustment_reasonExists(int id)
        {
            return db.ref_transaction_adjustment_reason.Count(e => e.transaction_adjustment_reason_skey == id) > 0;
        }
    }
}
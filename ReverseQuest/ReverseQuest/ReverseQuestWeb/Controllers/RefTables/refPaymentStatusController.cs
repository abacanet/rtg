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
    public class refPaymentStatusController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refPaymentStatus
        public IQueryable<ref_payment_status> GetRefPaymentStatus()
        {
            return db.ref_payment_status;
        }

        // GET: api/refPaymentStatus/5
        [ResponseType(typeof(ref_payment_status))]
        public IHttpActionResult GetRefPaymentStatus(int id)
        {
            ref_payment_status ref_payment_status = db.ref_payment_status.Find(id);
            if (ref_payment_status == null)
            {
                return NotFound();
            }

            return Ok(ref_payment_status);
        }

        // GET: api/GetRefPaymentStatusActive/
        [ResponseType(typeof(List<ref_payment_status>))]
        public IHttpActionResult GetRefPaymentStatusActive()
        {
            List<ref_payment_status> ref_payment_statuses = db.ref_payment_status.Where(a => a.status_skey == 1).ToList();

            if (ref_payment_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_payment_statuses);
        }

        // PUT: api/refPaymentStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefPaymentStatus(int id, ref_payment_status ref_payment_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_payment_status.payment_status_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_payment_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_payment_statusExists(id))
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

        // POST: api/refPaymentStatus
        [ResponseType(typeof(ref_payment_status))]
        public IHttpActionResult PostRefPaymentStatus(ref_payment_status ref_payment_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_payment_status.Add(ref_payment_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_payment_statusExists(ref_payment_status.payment_status_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_payment_status.payment_status_skey }, ref_payment_status);
        }

        // DELETE: api/refPaymentStatus/5
        [ResponseType(typeof(ref_payment_status))]
        public IHttpActionResult DeleteRefPaymentStatus(int id)
        {
            ref_payment_status ref_payment_status = db.ref_payment_status.Find(id);
            if (ref_payment_status == null)
            {
                return NotFound();
            }

            db.ref_payment_status.Remove(ref_payment_status);
            db.SaveChanges();

            return Ok(ref_payment_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_payment_statusExists(int id)
        {
            return db.ref_payment_status.Count(e => e.payment_status_skey == id) > 0;
        }
    }
}
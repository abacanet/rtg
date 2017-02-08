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
    public class refPaymentPlanStatusController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refPaymentPlanStatus
        public IQueryable<ref_payment_plan_status> GetRefPaymentPlanStatus()
        {
            return db.ref_payment_plan_status;
        }

        // GET: api/refPaymentPlanStatus/5
        [ResponseType(typeof(ref_payment_plan_status))]
        public IHttpActionResult GetRefPaymentPlanStatus(int id)
        {
            ref_payment_plan_status ref_payment_plan_status = db.ref_payment_plan_status.Find(id);
            if (ref_payment_plan_status == null)
            {
                return NotFound();
            }

            return Ok(ref_payment_plan_status);
        }

        // GET: api/GetRefPaymentPlanStatusActive/
        [ResponseType(typeof(List<ref_payment_plan_status>))]
        public IHttpActionResult GetRefPaymentPlanStatusActive()
        {
            List<ref_payment_plan_status> ref_payment_plan_statuses = db.ref_payment_plan_status.Where(a => a.status_skey == 1).ToList();

            if (ref_payment_plan_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_payment_plan_statuses);
        }

        // PUT: api/refPaymentPlanStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefPaymentPlanStatus(int id, ref_payment_plan_status ref_payment_plan_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_payment_plan_status.payment_plan_status_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_payment_plan_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_payment_plan_statusExists(id))
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

        // POST: api/refPaymentPlanStatus
        [ResponseType(typeof(ref_payment_plan_status))]
        public IHttpActionResult PostRefPaymentPlanStatus(ref_payment_plan_status ref_payment_plan_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_payment_plan_status.Add(ref_payment_plan_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_payment_plan_statusExists(ref_payment_plan_status.payment_plan_status_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_payment_plan_status.payment_plan_status_skey }, ref_payment_plan_status);
        }

        // DELETE: api/refPaymentPlanStatus/5
        [ResponseType(typeof(ref_payment_plan_status))]
        public IHttpActionResult DeleteRefPaymentPlanStatus(int id)
        {
            ref_payment_plan_status ref_payment_plan_status = db.ref_payment_plan_status.Find(id);
            if (ref_payment_plan_status == null)
            {
                return NotFound();
            }

            db.ref_payment_plan_status.Remove(ref_payment_plan_status);
            db.SaveChanges();

            return Ok(ref_payment_plan_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_payment_plan_statusExists(int id)
        {
            return db.ref_payment_plan_status.Count(e => e.payment_plan_status_skey == id) > 0;
        }
    }
}
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
    public class refPaymentPlanTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refPaymentPlanType
        [Route("api/rpp/refPaymentPlanType", Name = "refPaymentPlanType")]
        public IQueryable<ref_payment_plan_type> GetRefPaymentPlanType()
        {
            return db.ref_payment_plan_type;
        }

        // GET: api/refPaymentPlanType/5
        [ResponseType(typeof(ref_payment_plan_type))]
        public IHttpActionResult GetRefPaymentPlanType(int id)
        {
            ref_payment_plan_type ref_payment_plan_type = db.ref_payment_plan_type.Find(id);
            if (ref_payment_plan_type == null)
            {
                return NotFound();
            }

            return Ok(ref_payment_plan_type);
        }

        // GET: api/GetRefPaymentPlanTypeActive/
        [ResponseType(typeof(List<ref_payment_plan_type>))]
        [Route("PaymentPlanTypeActive")]
        public IHttpActionResult GetRefPaymentPlanTypeActive()
        {
            List<ref_payment_plan_type> ref_payment_plan_types = db.ref_payment_plan_type.Where(a => a.status_skey == 1).ToList();

            if (ref_payment_plan_types == null)
            {
                return NotFound();
            }

            return Ok(ref_payment_plan_types);
        }

        // PUT: api/refPaymentPlanType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefPaymentPlanType(int id, ref_payment_plan_type ref_payment_plan_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_payment_plan_type.payment_plan_type)
            {
                return BadRequest();
            }

            db.Entry(ref_payment_plan_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_payment_plan_typeExists(id))
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

        // POST: api/refPaymentPlanType
        [ResponseType(typeof(ref_payment_plan_type))]
        public IHttpActionResult PostRefPaymentPlanType(ref_payment_plan_type ref_payment_plan_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_payment_plan_type.Add(ref_payment_plan_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_payment_plan_typeExists(ref_payment_plan_type.payment_plan_type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_payment_plan_type.payment_plan_type }, ref_payment_plan_type);
        }

        // DELETE: api/refPaymentPlanType/5
        [ResponseType(typeof(ref_payment_plan_type))]
        public IHttpActionResult DeleteRefPaymentPlanType(int id)
        {
            ref_payment_plan_type ref_payment_plan_type = db.ref_payment_plan_type.Find(id);
            if (ref_payment_plan_type == null)
            {
                return NotFound();
            }

            db.ref_payment_plan_type.Remove(ref_payment_plan_type);
            db.SaveChanges();

            return Ok(ref_payment_plan_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_payment_plan_typeExists(int id)
        {
            return db.ref_payment_plan_type.Count(e => e.payment_plan_type == id) > 0;
        }
    }
}
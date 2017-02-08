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
    public class refProductPaymentPlanTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refProductPaymentPlanType
        public IQueryable<ref_product_payment_plan_type> GetRefProductPaymentPlanType()
        {
            return db.ref_product_payment_plan_type;
        }

        // GET: api/refProductPaymentPlanType/5
        [ResponseType(typeof(ref_product_payment_plan_type))]
        public IHttpActionResult GetRefProductPaymentPlanType(int id)
        {
            ref_product_payment_plan_type ref_product_payment_plan_type = db.ref_product_payment_plan_type.Find(id);
            if (ref_product_payment_plan_type == null)
            {
                return NotFound();
            }

            return Ok(ref_product_payment_plan_type);
        }

        // GET: api/GetRefProductPaymentPlanTypeActive/
        [ResponseType(typeof(List<ref_product_payment_plan_type>))]
        public IHttpActionResult GetRefProductPaymentPlanTypeActive()
        {
            List<ref_product_payment_plan_type> ref_product_payment_plan_types = db.ref_product_payment_plan_type.Where(a => a.status_skey == 1).ToList();

            if (ref_product_payment_plan_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_payment_plan_types);
        }

        // GET: api/GetRefProductPaymentPlanTypeByProductTypeSkey/5
        [ResponseType(typeof(List<ref_product_payment_plan_type>))]
        public IHttpActionResult GetRefProductPaymentPlanTypeByProductTypeSkey(int ProductTypeSkey)
        {
            List<ref_product_payment_plan_type> ref_product_payment_plan_types = db.ref_product_payment_plan_type.Where(a => a.product_type_skey == ProductTypeSkey).ToList();

            if (ref_product_payment_plan_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_payment_plan_types);
        }

        // GET: api/GetRefProductPaymentPlanTypeByPaymentPlanType/5
        [ResponseType(typeof(List<ref_product_payment_plan_type>))]
        public IHttpActionResult GetRefProductPaymentPlanTypeByPaymentPlanType(int PaymentPlanType)
        {
            List<ref_product_payment_plan_type> ref_product_payment_plan_types = db.ref_product_payment_plan_type.Where(a => a.payment_plan_type == PaymentPlanType).ToList();

            if (ref_product_payment_plan_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_payment_plan_types);
        }

        // PUT: api/refProductPaymentPlanType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefProductPaymentPlanType(int id, ref_product_payment_plan_type ref_product_payment_plan_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_product_payment_plan_type.product_payment_plan_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_product_payment_plan_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_product_payment_plan_typeExists(id))
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

        // POST: api/refProductPaymentPlanType
        [ResponseType(typeof(ref_product_payment_plan_type))]
        public IHttpActionResult PostRefProductPaymentPlanType(ref_product_payment_plan_type ref_product_payment_plan_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_product_payment_plan_type.Add(ref_product_payment_plan_type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_product_payment_plan_type.product_payment_plan_type_skey }, ref_product_payment_plan_type);
        }

        // DELETE: api/refProductPaymentPlanType/5
        [ResponseType(typeof(ref_product_payment_plan_type))]
        public IHttpActionResult DeleteRefProductPaymentPlanType(int id)
        {
            ref_product_payment_plan_type ref_product_payment_plan_type = db.ref_product_payment_plan_type.Find(id);
            if (ref_product_payment_plan_type == null)
            {
                return NotFound();
            }

            db.ref_product_payment_plan_type.Remove(ref_product_payment_plan_type);
            db.SaveChanges();

            return Ok(ref_product_payment_plan_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_product_payment_plan_typeExists(int id)
        {
            return db.ref_product_payment_plan_type.Count(e => e.product_payment_plan_type_skey == id) > 0;
        }
    }
}
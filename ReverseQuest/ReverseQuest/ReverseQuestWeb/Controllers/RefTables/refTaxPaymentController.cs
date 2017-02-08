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
    public class refTaxPaymentController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTaxPayment
        public IQueryable<ref_tax_payment> GetRefTaxPayment()
        {
            return db.ref_tax_payment;
        }

        // GET: api/refTaxPayment/5
        [ResponseType(typeof(ref_tax_payment))]
        public IHttpActionResult GetRefTaxPayment(int id)
        {
            ref_tax_payment ref_tax_payment = db.ref_tax_payment.Find(id);
            if (ref_tax_payment == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_payment);
        }

        // GET: api/GetRefTaxNoteCode/
        [ResponseType(typeof(List<ref_tax_payment>))]
        public IHttpActionResult GetRefTaxPaymentActive()
        {
            List<ref_tax_payment> ref_tax_payments = db.ref_tax_payment.Where(a => a.status_skey == 1).ToList();

            if (ref_tax_payments == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_payments);
        }

        // GET: api/GetRefTaxPaymentByTaxPaymentCode/5
        [ResponseType(typeof(List<ref_tax_payment>))]
        public IHttpActionResult GetRefTaxPaymentByTaxPaymentCode(string TaxPaymentCode)
        {
            List<ref_tax_payment> ref_tax_payments = db.ref_tax_payment.Where(a => a.tax_payment_code == TaxPaymentCode).ToList();

            if (ref_tax_payments == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_payments);
        }

        // PUT: api/refTaxPayment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTaxPayment(int id, ref_tax_payment ref_tax_payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_tax_payment.tax_payment_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_tax_payment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_tax_paymentExists(id))
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

        // POST: api/refTaxPayment
        [ResponseType(typeof(ref_tax_payment))]
        public IHttpActionResult PostRefTaxPayment(ref_tax_payment ref_tax_payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_tax_payment.Add(ref_tax_payment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_tax_paymentExists(ref_tax_payment.tax_payment_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_tax_payment.tax_payment_skey }, ref_tax_payment);
        }

        // DELETE: api/refTaxPayment/5
        [ResponseType(typeof(ref_tax_payment))]
        public IHttpActionResult DeleteRefTaxPayment(int id)
        {
            ref_tax_payment ref_tax_payment = db.ref_tax_payment.Find(id);
            if (ref_tax_payment == null)
            {
                return NotFound();
            }

            db.ref_tax_payment.Remove(ref_tax_payment);
            db.SaveChanges();

            return Ok(ref_tax_payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_tax_paymentExists(int id)
        {
            return db.ref_tax_payment.Count(e => e.tax_payment_skey == id) > 0;
        }
    }
}
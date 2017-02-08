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
    public class refInvestorDisbursementTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refInvestorDisbursementType
        public IQueryable<ref_investor_disbursement_type> GetRefInvestorDisbursementType()
        {
            return db.ref_investor_disbursement_type;
        }

        // GET: api/refInvestorDisbursementType/5
        [ResponseType(typeof(ref_investor_disbursement_type))]
        public IHttpActionResult GetRefInvestorDisbursementType(int id)
        {
            ref_investor_disbursement_type ref_investor_disbursement_type = db.ref_investor_disbursement_type.Find(id);
            if (ref_investor_disbursement_type == null)
            {
                return NotFound();
            }

            return Ok(ref_investor_disbursement_type);
        }

        // GET: api/GetRefInvestorDisbursementTypeByInvestorSkey/5
        [ResponseType(typeof(List<ref_investor_disbursement_type>))]
        public IHttpActionResult GetRefInvestorDisbursementTypeByInvestorSkey(int InvestorSkey)
        {
            List<ref_investor_disbursement_type> ref_investor_disbursement_types = db.ref_investor_disbursement_type.Where(a => a.investor_skey == InvestorSkey).ToList();

            if (ref_investor_disbursement_types == null)
            {
                return NotFound();
            }

            return Ok(ref_investor_disbursement_types);
        }

        // PUT: api/refInvestorDisbursementType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefInvestorDisbursementType(int id, ref_investor_disbursement_type ref_investor_disbursement_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_investor_disbursement_type.investor_disbursement_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_investor_disbursement_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_investor_disbursement_typeExists(id))
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

        // POST: api/refInvestorDisbursementType
        [ResponseType(typeof(ref_investor_disbursement_type))]
        public IHttpActionResult PostRefInvestorDisbursementType(ref_investor_disbursement_type ref_investor_disbursement_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_investor_disbursement_type.Add(ref_investor_disbursement_type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_investor_disbursement_type.investor_disbursement_type_skey }, ref_investor_disbursement_type);
        }

        // DELETE: api/refInvestorDisbursementType/5
        [ResponseType(typeof(ref_investor_disbursement_type))]
        public IHttpActionResult DeleteRefInvestorDisbursementType(int id)
        {
            ref_investor_disbursement_type ref_investor_disbursement_type = db.ref_investor_disbursement_type.Find(id);
            if (ref_investor_disbursement_type == null)
            {
                return NotFound();
            }

            db.ref_investor_disbursement_type.Remove(ref_investor_disbursement_type);
            db.SaveChanges();

            return Ok(ref_investor_disbursement_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_investor_disbursement_typeExists(int id)
        {
            return db.ref_investor_disbursement_type.Count(e => e.investor_disbursement_type_skey == id) > 0;
        }
    }
}
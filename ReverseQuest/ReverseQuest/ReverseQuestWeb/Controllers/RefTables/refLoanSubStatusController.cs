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
    public class refLoanSubStatusController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refLoanSubStatus
        [Route("api/lss/refLoanSubStatus", Name = "refLoanSubStatus")]
        public IHttpActionResult GetRefLoanSubStatus()
        {
            return Ok(db.ref_loan_sub_status.Join(
                            db.ref_loan_status, lss => lss.loan_status_code, ls => ls.loan_status_code,
                            (lss, ls) => new { lss, ls })
                            .Select(ss => new
                            {
                                loan_sub_status_description = ss.lss.loan_sub_status_description,
                                loan_sub_status_code = ss.lss.loan_sub_status_code,
                                loan_status_description = ss.ls.loan_status_description
                            })
                .ToList());
        }

        // GET: api/refLoanSubStatus
        [Route("api/ls/refLoanStatus", Name = "refLoanStatus")]
        public IHttpActionResult GetRefLoanStatus()
        {
            return Ok(db.ref_loan_status
                .ToList());
        }

        // GET: api/refLoanSubStatus/5
        [ResponseType(typeof(ref_loan_sub_status))]
        public IHttpActionResult GetRefLoanSubStatus(string id)
        {
            ref_loan_sub_status ref_loan_sub_status = db.ref_loan_sub_status.Find(id);
            if (ref_loan_sub_status == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_sub_status);
        }

        // GET: api/GetRefLoanSubStatusActive/
        [ResponseType(typeof(List<ref_loan_sub_status>))]
        [Route("LoanSubStatusActive")]
        public IHttpActionResult GetRefLoanSubStatusActive()
        {
            List<ref_loan_sub_status> ref_loan_sub_statuses = db.ref_loan_sub_status.Where(a => a.status_skey == 1).ToList();

            if (ref_loan_sub_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_sub_statuses);
        }

        //// GET: api/GetRefLoanSubStatusByLoanSubStatusCategory/5
        //[ResponseType(typeof(List<ref_loan_sub_status>))]
        //public IHttpActionResult GetRefLoanSubStatusByLoanSubStatusCategory(int loanSubStatusCategory)
        //{
        //    List<ref_loan_sub_status> ref_loan_sub_statuses = db.ref_loan_sub_status.Where(a => a.loan_sub_status_category_skey == loanSubStatusCategory).ToList();

        //    if (ref_loan_sub_statuses == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ref_loan_sub_statuses);
        //}

        // PUT: api/refLoanSubStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLoanSubStatus(string id, ref_loan_sub_status ref_loan_sub_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_loan_sub_status.loan_sub_status_code)
            {
                return BadRequest();
            }

            db.Entry(ref_loan_sub_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_loan_sub_statusExists(id))
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

        // POST: api/refLoanSubStatus
        [ResponseType(typeof(ref_loan_sub_status))]
        public IHttpActionResult PostRefLoanSubStatus(ref_loan_sub_status ref_loan_sub_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_loan_sub_status.Add(ref_loan_sub_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_loan_sub_statusExists(ref_loan_sub_status.loan_sub_status_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_loan_sub_status.loan_sub_status_code }, ref_loan_sub_status);
        }

        // DELETE: api/refLoanSubStatus/5
        [ResponseType(typeof(ref_loan_sub_status))]
        public IHttpActionResult DeleteRefLoanSubStatus(string id)
        {
            ref_loan_sub_status ref_loan_sub_status = db.ref_loan_sub_status.Find(id);
            if (ref_loan_sub_status == null)
            {
                return NotFound();
            }

            db.ref_loan_sub_status.Remove(ref_loan_sub_status);
            db.SaveChanges();

            return Ok(ref_loan_sub_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_loan_sub_statusExists(string id)
        {
            return db.ref_loan_sub_status.Count(e => e.loan_sub_status_code == id) > 0;
        }
    }
}
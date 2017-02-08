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
    public class refInvestorController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refInvestor
        public IQueryable<ref_investor> GetRefInvestor()
        {
            return db.ref_investor;
        }

        // GET: api/refInvestor/5
        [ResponseType(typeof(ref_investor))]
        public IHttpActionResult GetRefInvestor(int id)
        {
            ref_investor ref_investor = db.ref_investor.Find(id);
            if (ref_investor == null)
            {
                return NotFound();
            }

            return Ok(ref_investor);
        }

        // GET: api/GetRefInvestorActive/
        [Route("InvestorActive")]
       // [ResponseType(typeof(List<ref_investor>))]
        public IHttpActionResult GetRefInvestorActive()
        {
            var ref_investors = db.ref_investor.Where(a => a.status_skey == 1)
                .Select(s => 
                    new {
                        investor_skey = s.investor_skey,
                        investor_name = s.investor_name

                    })
                    .ToList();

            if (ref_investors == null)
            {
                return NotFound();
            }

            return Ok(ref_investors);
        }

        // GET: api/GetRefInvestorByLoanServicerSkey/5
        [ResponseType(typeof(List<ref_investor>))]
        public IHttpActionResult GetRefInvestorByLoanServicerSkey(int loanServicerSkey)
        {
            List<ref_investor> ref_investors = db.ref_investor.Where(a => a.loan_servicer_skey == loanServicerSkey).ToList();

            if (ref_investors == null)
            {
                return NotFound();
            }

            return Ok(ref_investors);
        }

        // PUT: api/refInvestor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefInvestor(int id, ref_investor ref_investor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_investor.investor_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_investor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_investorExists(id))
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

        // POST: api/refInvestor
        [ResponseType(typeof(ref_investor))]
        public IHttpActionResult PostRefInvestor(ref_investor ref_investor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_investor.Add(ref_investor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_investorExists(ref_investor.investor_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_investor.investor_skey }, ref_investor);
        }

        // DELETE: api/refInvestor/5
        [ResponseType(typeof(ref_investor))]
        public IHttpActionResult DeleteRefInvestor(int id)
        {
            ref_investor ref_investor = db.ref_investor.Find(id);
            if (ref_investor == null)
            {
                return NotFound();
            }

            db.ref_investor.Remove(ref_investor);
            db.SaveChanges();

            return Ok(ref_investor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_investorExists(int id)
        {
            return db.ref_investor.Count(e => e.investor_skey == id) > 0;
        }
    }
}
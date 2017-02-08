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
    public class refLoanPoolController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refLoanPool
        public IQueryable<ref_loan_pool> GetRefLoanPool()
        {
            return db.ref_loan_pool;
        }

        // GET: api/refLoanPool/5
        [ResponseType(typeof(ref_loan_pool))]
        public IHttpActionResult GetRefLoanPool(int id)
        {
            ref_loan_pool ref_loan_pool = db.ref_loan_pool.Find(id);
            if (ref_loan_pool == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_pool);
        }

        // GET: api/GetRefLoanPoolActive/
        [Route("LoanPoolActive")]
        [ResponseType(typeof(List<ref_loan_pool>))]
        public IHttpActionResult GetRefLoanPoolActive()
        {
            List<ref_loan_pool> ref_loan_pools = db.ref_loan_pool.Where(a => a.status_skey == 1).ToList();

            if (ref_loan_pools == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_pools);
        }

        // GET: api/GetRefLoanPoolByInvestorSkey/5
        [ResponseType(typeof(List<ref_loan_pool>))]
        public IHttpActionResult GetRefLoanPoolByInvestorSkey(int investorSkey)
        {
            List<ref_loan_pool> ref_loan_pools = db.ref_loan_pool.Where(a => a.investor_skey == investorSkey).ToList();

            if (ref_loan_pools == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_pools);
        }

        // PUT: api/refLoanPool/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLoanPool(int id, ref_loan_pool ref_loan_pool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_loan_pool.loan_pool_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_loan_pool).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_loan_poolExists(id))
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

        // POST: api/refLoanPool
        [ResponseType(typeof(ref_loan_pool))]
        public IHttpActionResult PostRefLoanPool(ref_loan_pool ref_loan_pool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_loan_pool.Add(ref_loan_pool);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_loan_poolExists(ref_loan_pool.loan_pool_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_loan_pool.loan_pool_skey }, ref_loan_pool);
        }

        // DELETE: api/refLoanPool/5
        [ResponseType(typeof(ref_loan_pool))]
        public IHttpActionResult DeleteRefLoanPool(int id)
        {
            ref_loan_pool ref_loan_pool = db.ref_loan_pool.Find(id);
            if (ref_loan_pool == null)
            {
                return NotFound();
            }

            db.ref_loan_pool.Remove(ref_loan_pool);
            db.SaveChanges();

            return Ok(ref_loan_pool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_loan_poolExists(int id)
        {
            return db.ref_loan_pool.Count(e => e.loan_pool_skey == id) > 0;
        }
    }
}
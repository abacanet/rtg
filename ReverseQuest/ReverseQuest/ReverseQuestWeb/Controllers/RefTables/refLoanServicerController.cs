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

namespace ReverseQuestWeb.Controllers
{
    [RoutePrefix("refapi/v1")]
    public class refLoanServicerController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refLoanServicer
        public IQueryable<ref_loan_servicer> GetRefLoanServicer()
        {
            return db.ref_loan_servicer;
        }

        // GET: api/refLoanServicer/5
        [ResponseType(typeof(ref_loan_servicer))]
        public IHttpActionResult GetRefLoanServicer(int id)
        {
            ref_loan_servicer ref_loan_servicer = db.ref_loan_servicer.Find(id);
            if (ref_loan_servicer == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_servicer);
        }
        [Route("LoanServicerActive")]
        // GET: api/GetRefLoanServicerActive/
        [ResponseType(typeof(List<ref_loan_servicer>))]
        public IHttpActionResult GetRefLoanServicerActive()
        {
            var ref_loan_servicers = db.ref_loan_servicer.Where(a => a.status_skey == 1).Select(s => new
            {
                loan_servicer_skey = s.loan_servicer_skey,
                servicer_name = s.servicer_name
            }
            ).ToList();

            if (ref_loan_servicers == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_servicers);
        }

        // GET: api/GetRefLoanServicerByClientSkey/5
        [Route("LoanServicerActiveByClient")]
        [ResponseType(typeof(List<ref_loan_servicer>))]
        public IHttpActionResult GetRefLoanServicerByClientSkey(int clientSkey)
        {
            List<ref_loan_servicer> ref_loan_servicers = db.ref_loan_servicer.Where(a => a.client_skey == clientSkey && a.status_skey == 1).ToList();

            if (ref_loan_servicers == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_servicers);
        }

        // PUT: api/refLoanServicer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLoanServicer(int id, ref_loan_servicer ref_loan_servicer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_loan_servicer.loan_servicer_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_loan_servicer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_loan_servicerExists(id))
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

        // POST: api/refLoanServicer
        [ResponseType(typeof(ref_loan_servicer))]
        public IHttpActionResult PostRefLoanServicer(ref_loan_servicer ref_loan_servicer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_loan_servicer.Add(ref_loan_servicer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_loan_servicerExists(ref_loan_servicer.loan_servicer_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_loan_servicer.loan_servicer_skey }, ref_loan_servicer);
        }

        // DELETE: api/refLoanServicer/5
        [ResponseType(typeof(ref_loan_servicer))]
        public IHttpActionResult DeleteRefLoanServicer(int id)
        {
            ref_loan_servicer ref_loan_servicer = db.ref_loan_servicer.Find(id);
            if (ref_loan_servicer == null)
            {
                return NotFound();
            }

            db.ref_loan_servicer.Remove(ref_loan_servicer);
            db.SaveChanges();

            return Ok(ref_loan_servicer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_loan_servicerExists(int id)
        {
            return db.ref_loan_servicer.Count(e => e.loan_servicer_skey == id) > 0;
        }
    }
}
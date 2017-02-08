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
    public class refTransactionCodeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTransactionCode
        public IQueryable<ref_transaction_code> GetRefTransactionCode()
        {
            return db.ref_transaction_code;
        }

        // GET: api/refTransactionCode/5
        [ResponseType(typeof(ref_transaction_code))]
        public IHttpActionResult GetRefTransactionCode(string id)
        {
            ref_transaction_code ref_transaction_code = db.ref_transaction_code.Find(id);
            if (ref_transaction_code == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_code);
        }

        // GET: api/GetRefTransactionCodeActive/
        [ResponseType(typeof(List<ref_transaction_code>))]
        public IHttpActionResult GetRefTransactionCodeActive()
        {
            List<ref_transaction_code> ref_transaction_codes = db.ref_transaction_code.Where(a => a.status_skey == 1).ToList();

            if (ref_transaction_codes == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_codes);
        }

        // GET: api/GetRefTransactionCodeByTransactionType/5
        [ResponseType(typeof(List<ref_transaction_code>))]
        public IHttpActionResult GetRefTransactionCodeByTransactionType(string TransactionType)
        {
            List<ref_transaction_code> ref_transaction_codes = db.ref_transaction_code.Where(a => a.transaction_type == TransactionType).ToList();

            if (ref_transaction_codes == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_codes);
        }

        // GET: api/GetRefTransactionCodeByTransactionCategorySkey/5
        [ResponseType(typeof(List<ref_transaction_code>))]
        public IHttpActionResult GetRefTransactionCodeByTransactionCategorySkey(int TransactionCategorySkey)
        {
            List<ref_transaction_code> ref_transaction_codes = db.ref_transaction_code.Where(a => a.transaction_category_skey == TransactionCategorySkey).ToList();

            if (ref_transaction_codes == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_codes);
        }

        // PUT: api/refTransactionCode/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTransactionCode(string id, ref_transaction_code ref_transaction_code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_transaction_code.transaction_code)
            {
                return BadRequest();
            }

            db.Entry(ref_transaction_code).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_transaction_codeExists(id))
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

        // POST: api/refTransactionCode
        [ResponseType(typeof(ref_transaction_code))]
        public IHttpActionResult PostRefTransactionCode(ref_transaction_code ref_transaction_code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_transaction_code.Add(ref_transaction_code);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_transaction_codeExists(ref_transaction_code.transaction_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_transaction_code.transaction_code }, ref_transaction_code);
        }

        // DELETE: api/refTransactionCode/5
        [ResponseType(typeof(ref_transaction_code))]
        public IHttpActionResult DeleteRefTransactionCode(string id)
        {
            ref_transaction_code ref_transaction_code = db.ref_transaction_code.Find(id);
            if (ref_transaction_code == null)
            {
                return NotFound();
            }

            db.ref_transaction_code.Remove(ref_transaction_code);
            db.SaveChanges();

            return Ok(ref_transaction_code);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_transaction_codeExists(string id)
        {
            return db.ref_transaction_code.Count(e => e.transaction_code == id) > 0;
        }
    }
}
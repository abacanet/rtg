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
    public class refHmbsTransactionCodeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refHmbsTransactionCode
        public IQueryable<ref_hmbs_transaction_code> GetRefHmbsTransactionCode()
        {
            return db.ref_hmbs_transaction_code;
        }

        // GET: api/refHmbsTransactionCode/5
        [ResponseType(typeof(ref_hmbs_transaction_code))]
        public IHttpActionResult GetRefHmbsTransactionCode(string id)
        {
            ref_hmbs_transaction_code ref_hmbs_transaction_code = db.ref_hmbs_transaction_code.Find(id);
            if (ref_hmbs_transaction_code == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_transaction_code);
        }

        // GET: api/refHmbsTransactionCodeActive/
        [ResponseType(typeof(List<ref_hmbs_transaction_code>))]
        public IHttpActionResult GetRefHmbsTransactionCodeActive()
        {
            List<ref_hmbs_transaction_code> ref_hmbs_transaction_codes = db.ref_hmbs_transaction_code.Where(a => a.status_skey == 1).ToList();

            if (ref_hmbs_transaction_codes == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_transaction_codes);
        }

        // GET: api/refHmbsTransactionCodeByHmbsTransactionCategorySkey/5
        [ResponseType(typeof(List<ref_hmbs_transaction_code>))]
        public IHttpActionResult GetRefHmbsTransactionCodeByHmbsTransactionCategorySkey(int hmbsTransactionCategorySkey)
        {
            List<ref_hmbs_transaction_code> ref_hmbs_transaction_codes = db.ref_hmbs_transaction_code.Where(a => a.hmbs_transaction_category_skey == hmbsTransactionCategorySkey).ToList();

            if (ref_hmbs_transaction_codes == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_transaction_codes);
        }

        // PUT: api/refHmbsTransactionCode/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefHmbsTransactionCode(string id, ref_hmbs_transaction_code ref_hmbs_transaction_code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_hmbs_transaction_code.hmbs_transaction_code)
            {
                return BadRequest();
            }

            db.Entry(ref_hmbs_transaction_code).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_hmbs_transaction_codeExists(id))
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

        // POST: api/refHmbsTransactionCode
        [ResponseType(typeof(ref_hmbs_transaction_code))]
        public IHttpActionResult PostRefHmbsTransactionCode(ref_hmbs_transaction_code ref_hmbs_transaction_code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_hmbs_transaction_code.Add(ref_hmbs_transaction_code);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_hmbs_transaction_codeExists(ref_hmbs_transaction_code.hmbs_transaction_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_hmbs_transaction_code.hmbs_transaction_code }, ref_hmbs_transaction_code);
        }

        // DELETE: api/refHmbsTransactionCode/5
        [ResponseType(typeof(ref_hmbs_transaction_code))]
        public IHttpActionResult DeleteRefHmbsTransactionCode(string id)
        {
            ref_hmbs_transaction_code ref_hmbs_transaction_code = db.ref_hmbs_transaction_code.Find(id);
            if (ref_hmbs_transaction_code == null)
            {
                return NotFound();
            }

            db.ref_hmbs_transaction_code.Remove(ref_hmbs_transaction_code);
            db.SaveChanges();

            return Ok(ref_hmbs_transaction_code);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_hmbs_transaction_codeExists(string id)
        {
            return db.ref_hmbs_transaction_code.Count(e => e.hmbs_transaction_code == id) > 0;
        }
    }
}
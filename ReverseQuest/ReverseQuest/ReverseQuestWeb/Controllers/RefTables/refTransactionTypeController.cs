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
    public class refTransactionTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTransactionType
        public IQueryable<ref_transaction_type> GetRefTransactionType()
        {
            return db.ref_transaction_type;
        }

        // GET: api/refTransactionType/5
        [ResponseType(typeof(ref_transaction_type))]
        public IHttpActionResult GetRefTransactionType(string id)
        {
            ref_transaction_type ref_transaction_type = db.ref_transaction_type.Find(id);
            if (ref_transaction_type == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_type);
        }

        // GET: api/GetRefTransactionTypeActive/
        [ResponseType(typeof(List<ref_transaction_type>))]
        public IHttpActionResult GetRefTransactionTypeActive()
        {
            List<ref_transaction_type> ref_transaction_types = db.ref_transaction_type.Where(a => a.status_skey == 1).ToList();

            if (ref_transaction_types == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_types);
        }

        // PUT: api/refTransactionType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTransactionType(string id, ref_transaction_type ref_transaction_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_transaction_type.transaction_type)
            {
                return BadRequest();
            }

            db.Entry(ref_transaction_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_transaction_typeExists(id))
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

        // POST: api/refTransactionType
        [ResponseType(typeof(ref_transaction_type))]
        public IHttpActionResult PostRefTransactionType(ref_transaction_type ref_transaction_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_transaction_type.Add(ref_transaction_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_transaction_typeExists(ref_transaction_type.transaction_type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_transaction_type.transaction_type }, ref_transaction_type);
        }

        // DELETE: api/refTransactionType/5
        [ResponseType(typeof(ref_transaction_type))]
        public IHttpActionResult DeleteRefTransactionType(string id)
        {
            ref_transaction_type ref_transaction_type = db.ref_transaction_type.Find(id);
            if (ref_transaction_type == null)
            {
                return NotFound();
            }

            db.ref_transaction_type.Remove(ref_transaction_type);
            db.SaveChanges();

            return Ok(ref_transaction_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_transaction_typeExists(string id)
        {
            return db.ref_transaction_type.Count(e => e.transaction_type == id) > 0;
        }
    }
}
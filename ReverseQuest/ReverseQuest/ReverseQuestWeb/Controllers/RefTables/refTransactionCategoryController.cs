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
    public class refTransactionCategoryController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTransactionCategory
        public IQueryable<ref_transaction_category> GeRefTransactionCategory()
        {
            return db.ref_transaction_category;
        }

        // GET: api/refTransactionCategory/5
        [ResponseType(typeof(ref_transaction_category))]
        public IHttpActionResult GeRefTransactionCategory(int id)
        {
            ref_transaction_category ref_transaction_category = db.ref_transaction_category.Find(id);
            if (ref_transaction_category == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_category);
        }

        // GET: api/GeRefTransactionCategoryActive/
        [ResponseType(typeof(List<ref_transaction_category>))]
        public IHttpActionResult GeRefTransactionCategoryActive()
        {
            List<ref_transaction_category> ref_transaction_categories = db.ref_transaction_category.Where(a => a.status_skey == 1).ToList();

            if (ref_transaction_categories == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_categories);
        }

        // GET: api/GeRefTransactionCategoryByTransactionType/5
        [ResponseType(typeof(List<ref_transaction_category>))]
        public IHttpActionResult GeRefTransactionCategoryByTransactionType(string TransactionType)
        {
            List<ref_transaction_category> ref_transaction_categories = db.ref_transaction_category.Where(a => a.transaction_type == TransactionType).ToList();

            if (ref_transaction_categories == null)
            {
                return NotFound();
            }

            return Ok(ref_transaction_categories);
        }

        // PUT: api/refTransactionCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTransactionCategory(int id, ref_transaction_category ref_transaction_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_transaction_category.transaction_category_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_transaction_category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_transaction_categoryExists(id))
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

        // POST: api/refTransactionCategory
        [ResponseType(typeof(ref_transaction_category))]
        public IHttpActionResult PostRefTransactionCategory(ref_transaction_category ref_transaction_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_transaction_category.Add(ref_transaction_category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_transaction_categoryExists(ref_transaction_category.transaction_category_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_transaction_category.transaction_category_skey }, ref_transaction_category);
        }

        // DELETE: api/refTransactionCategory/5
        [ResponseType(typeof(ref_transaction_category))]
        public IHttpActionResult DeleteRefTransactionCategory(int id)
        {
            ref_transaction_category ref_transaction_category = db.ref_transaction_category.Find(id);
            if (ref_transaction_category == null)
            {
                return NotFound();
            }

            db.ref_transaction_category.Remove(ref_transaction_category);
            db.SaveChanges();

            return Ok(ref_transaction_category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_transaction_categoryExists(int id)
        {
            return db.ref_transaction_category.Count(e => e.transaction_category_skey == id) > 0;
        }
    }
}
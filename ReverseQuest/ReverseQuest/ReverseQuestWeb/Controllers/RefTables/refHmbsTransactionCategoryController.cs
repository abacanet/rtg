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
    public class refHmbsTransactionCategoryController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refHmbsTransactionCategory
        public IQueryable<ref_hmbs_transaction_category> GetRefHmbsTransactionCategory()
        {
            return db.ref_hmbs_transaction_category;
        }

        // GET: api/refHmbsTransactionCategory/5
        [ResponseType(typeof(ref_hmbs_transaction_category))]
        public IHttpActionResult GetRefHmbsTransactionCategory(int id)
        {
            ref_hmbs_transaction_category ref_hmbs_transaction_category = db.ref_hmbs_transaction_category.Find(id);
            if (ref_hmbs_transaction_category == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_transaction_category);
        }

        // GET: api/refHmbsTransactionCategoryActive/
        [ResponseType(typeof(List<ref_hmbs_transaction_category>))]
        public IHttpActionResult GetRefHmbsTransactionCategoryActive()
        {
            List<ref_hmbs_transaction_category> ref_hmbs_transaction_categories = db.ref_hmbs_transaction_category.Where(a => a.status_skey == 1).ToList();

            if (ref_hmbs_transaction_categories == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_transaction_categories);
        }

        // PUT: api/refHmbsTransactionCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefHmbsTransactionCategory(int id, ref_hmbs_transaction_category ref_hmbs_transaction_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_hmbs_transaction_category.hmbs_transaction_category_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_hmbs_transaction_category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_hmbs_transaction_categoryExists(id))
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

        // POST: api/refHmbsTransactionCategory
        [ResponseType(typeof(ref_hmbs_transaction_category))]
        public IHttpActionResult PostRefHmbsTransactionCategory(ref_hmbs_transaction_category ref_hmbs_transaction_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_hmbs_transaction_category.Add(ref_hmbs_transaction_category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_hmbs_transaction_categoryExists(ref_hmbs_transaction_category.hmbs_transaction_category_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_hmbs_transaction_category.hmbs_transaction_category_skey }, ref_hmbs_transaction_category);
        }

        // DELETE: api/refHmbsTransactionCategory/5
        [ResponseType(typeof(ref_hmbs_transaction_category))]
        public IHttpActionResult DeleteRefHmbsTransactionCategory(int id)
        {
            ref_hmbs_transaction_category ref_hmbs_transaction_category = db.ref_hmbs_transaction_category.Find(id);
            if (ref_hmbs_transaction_category == null)
            {
                return NotFound();
            }

            db.ref_hmbs_transaction_category.Remove(ref_hmbs_transaction_category);
            db.SaveChanges();

            return Ok(ref_hmbs_transaction_category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_hmbs_transaction_categoryExists(int id)
        {
            return db.ref_hmbs_transaction_category.Count(e => e.hmbs_transaction_category_skey == id) > 0;
        }
    }
}
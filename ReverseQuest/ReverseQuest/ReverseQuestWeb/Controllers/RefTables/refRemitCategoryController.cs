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
    public class refRemitCategoryController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refRemitCategory
        public IQueryable<ref_remit_category> GetRefRemitCategory()
        {
            return db.ref_remit_category;
        }

        // GET: api/refRemitCategory/5
        [ResponseType(typeof(ref_remit_category))]
        public IHttpActionResult GetRefRemitCategory(int id)
        {
            ref_remit_category ref_remit_category = db.ref_remit_category.Find(id);
            if (ref_remit_category == null)
            {
                return NotFound();
            }

            return Ok(ref_remit_category);
        }

        // GET: api/GetRefRemitCategoryActive/
        [ResponseType(typeof(List<ref_remit_category>))]
        public IHttpActionResult GetRefRemitCategoryActive()
        {
            List<ref_remit_category> ref_remit_categories = db.ref_remit_category.Where(a => a.status_skey == 1).ToList();

            if (ref_remit_categories == null)
            {
                return NotFound();
            }

            return Ok(ref_remit_categories);
        }

        // PUT: api/refRemitCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefRemitCategory(int id, ref_remit_category ref_remit_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_remit_category.remit_category_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_remit_category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_remit_categoryExists(id))
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

        // POST: api/refRemitCategory
        [ResponseType(typeof(ref_remit_category))]
        public IHttpActionResult PostRefRemitCategory(ref_remit_category ref_remit_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_remit_category.Add(ref_remit_category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_remit_categoryExists(ref_remit_category.remit_category_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_remit_category.remit_category_skey }, ref_remit_category);
        }

        // DELETE: api/refRemitCategory/5
        [ResponseType(typeof(ref_remit_category))]
        public IHttpActionResult DeleteRefRemitCategory(int id)
        {
            ref_remit_category ref_remit_category = db.ref_remit_category.Find(id);
            if (ref_remit_category == null)
            {
                return NotFound();
            }

            db.ref_remit_category.Remove(ref_remit_category);
            db.SaveChanges();

            return Ok(ref_remit_category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_remit_categoryExists(int id)
        {
            return db.ref_remit_category.Count(e => e.remit_category_skey == id) > 0;
        }
    }
}
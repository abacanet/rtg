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
    public class refProductTypeCategoryController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refProductTypeCategory
        public IQueryable<ref_product_type_category> GetRefProductTypeCategory()
        {
            return db.ref_product_type_category;
        }

        // GET: api/refProductTypeCategory/5
        [ResponseType(typeof(ref_product_type_category))]
        public IHttpActionResult GetRefProductTypeCategory(int id)
        {
            ref_product_type_category ref_product_type_category = db.ref_product_type_category.Find(id);
            if (ref_product_type_category == null)
            {
                return NotFound();
            }

            return Ok(ref_product_type_category);
        }

        // GET: api/GetRefProductTypeCategoryActive/
        [ResponseType(typeof(List<ref_product_type_category>))]
        public IHttpActionResult GetRefProductTypeCategoryActive()
        {
            List<ref_product_type_category> ref_product_type_categories = db.ref_product_type_category.Where(a => a.status_skey == 1).ToList();

            if (ref_product_type_categories == null)
            {
                return NotFound();
            }

            return Ok(ref_product_type_categories);
        }

        // PUT: api/refProductTypeCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefProductTypeCategory(int id, ref_product_type_category ref_product_type_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_product_type_category.product_type_category_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_product_type_category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_product_type_categoryExists(id))
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

        // POST: api/refProductTypeCategory
        [ResponseType(typeof(ref_product_type_category))]
        public IHttpActionResult PostRefProductTypeCategory(ref_product_type_category ref_product_type_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_product_type_category.Add(ref_product_type_category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_product_type_categoryExists(ref_product_type_category.product_type_category_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_product_type_category.product_type_category_skey }, ref_product_type_category);
        }

        // DELETE: api/refProductTypeCategory/5
        [ResponseType(typeof(ref_product_type_category))]
        public IHttpActionResult DeleteRefProductTypeCategory(int id)
        {
            ref_product_type_category ref_product_type_category = db.ref_product_type_category.Find(id);
            if (ref_product_type_category == null)
            {
                return NotFound();
            }

            db.ref_product_type_category.Remove(ref_product_type_category);
            db.SaveChanges();

            return Ok(ref_product_type_category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_product_type_categoryExists(int id)
        {
            return db.ref_product_type_category.Count(e => e.product_type_category_skey == id) > 0;
        }
    }
}
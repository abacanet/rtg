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
    public class refPropertyTypeCategoryController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refPropertyTypeCategory
        public IQueryable<ref_property_type_category> GetRefPropertyTypeCategory()
        {
            return db.ref_property_type_category;
        }

        // GET: api/refPropertyTypeCategory/5
        [ResponseType(typeof(ref_property_type_category))]
        public IHttpActionResult GetRefPropertyTypeCategory(int id)
        {
            ref_property_type_category ref_property_type_category = db.ref_property_type_category.Find(id);
            if (ref_property_type_category == null)
            {
                return NotFound();
            }

            return Ok(ref_property_type_category);
        }

        // GET: api/GetRefPropertyTypeCategoryActive/
        [Route("PropertyTypeCategoryActive")]
        [ResponseType(typeof(List<ref_property_type_category>))]
        public IHttpActionResult GetRefPropertyTypeCategoryActive()
        {
            List<ref_property_type_category> ref_property_type_categories = db.ref_property_type_category.Where(a => a.status_skey == 1).ToList();

            if (ref_property_type_categories == null)
            {
                return NotFound();
            }

            return Ok(ref_property_type_categories);
        }

        // PUT: api/refPropertyTypeCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefPropertyTypeCategory(int id, ref_property_type_category ref_property_type_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_property_type_category.property_type_category_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_property_type_category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_property_type_categoryExists(id))
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

        // POST: api/refPropertyTypeCategory
        [ResponseType(typeof(ref_property_type_category))]
        public IHttpActionResult PostRefPropertyTypeCategory(ref_property_type_category ref_property_type_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_property_type_category.Add(ref_property_type_category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_property_type_categoryExists(ref_property_type_category.property_type_category_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_property_type_category.property_type_category_skey }, ref_property_type_category);
        }

        // DELETE: api/refPropertyTypeCategory/5
        [ResponseType(typeof(ref_property_type_category))]
        public IHttpActionResult DeleteRefPropertyTypeCategory(int id)
        {
            ref_property_type_category ref_property_type_category = db.ref_property_type_category.Find(id);
            if (ref_property_type_category == null)
            {
                return NotFound();
            }

            db.ref_property_type_category.Remove(ref_property_type_category);
            db.SaveChanges();

            return Ok(ref_property_type_category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_property_type_categoryExists(int id)
        {
            return db.ref_property_type_category.Count(e => e.property_type_category_skey == id) > 0;
        }
    }
}
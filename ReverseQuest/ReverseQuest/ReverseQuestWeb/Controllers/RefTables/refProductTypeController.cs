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
    public class refProductTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refProductType
        public IQueryable<ref_product_type> GetRefProductType()
        {
            return db.ref_product_type;
        }

        // GET: api/refProductType/5
        [ResponseType(typeof(ref_product_type))]
        public IHttpActionResult GetRefProductType(int id)
        {
            ref_product_type ref_product_type = db.ref_product_type.Find(id);
            if (ref_product_type == null)
            {
                return NotFound();
            }

            return Ok(ref_product_type);
        }

        // GET: api/GetRefProductPaymentPlanTypeActive/
        [ResponseType(typeof(List<ref_product_type>))]
        [Route("ProductTypeActive")]
        public IHttpActionResult GetRefProductTypeActive()
        {
            List<ref_product_type> ref_product_types = db.ref_product_type.Where(a => a.status_skey == 1).ToList();

            if (ref_product_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_types);
        }

        // GET: api/GetRefProductPaymentPlanTypeByProductTypeCategorySkey/5
        [ResponseType(typeof(List<ref_product_type>))]
        public IHttpActionResult GetRefProductPaymentPlanTypeByProductTypeCategorySkey(int ProductTypeCategorySkey)
        {
            List<ref_product_type> ref_product_types = db.ref_product_type.Where(a => a.product_type_category_skey == ProductTypeCategorySkey).ToList();

            if (ref_product_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_types);
        }

        // PUT: api/refProductType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefProductType(int id, ref_product_type ref_product_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_product_type.product_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_product_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_product_typeExists(id))
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

        // POST: api/refProductType
        [ResponseType(typeof(ref_product_type))]
        public IHttpActionResult PostRefProductType(ref_product_type ref_product_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_product_type.Add(ref_product_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_product_typeExists(ref_product_type.product_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_product_type.product_type_skey }, ref_product_type);
        }

        // DELETE: api/refProductType/5
        [ResponseType(typeof(ref_product_type))]
        public IHttpActionResult DeleteRefProductType(int id)
        {
            ref_product_type ref_product_type = db.ref_product_type.Find(id);
            if (ref_product_type == null)
            {
                return NotFound();
            }

            db.ref_product_type.Remove(ref_product_type);
            db.SaveChanges();

            return Ok(ref_product_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_product_typeExists(int id)
        {
            return db.ref_product_type.Count(e => e.product_type_skey == id) > 0;
        }
    }
}
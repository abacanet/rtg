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
    public class refVendorTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refVendorType
        public IQueryable<ref_vendor_type> GetRefVendorType()
        {
            return db.ref_vendor_type;
        }

        // GET: api/refVendorType/5
        [ResponseType(typeof(ref_vendor_type))]
        public IHttpActionResult GetRefVendorType(int id)
        {
            ref_vendor_type ref_vendor_type = db.ref_vendor_type.Find(id);
            if (ref_vendor_type == null)
            {
                return NotFound();
            }

            return Ok(ref_vendor_type);
        }

        // GET: api/GetRefVendorTypeActive/
        [ResponseType(typeof(List<ref_vendor_type>))]
        public IHttpActionResult GetRefVendorTypeActive()
        {
            List<ref_vendor_type> ref_vendor_types = db.ref_vendor_type.Where(a => a.status_skey == 1).ToList();

            if (ref_vendor_types == null)
            {
                return NotFound();
            }

            return Ok(ref_vendor_types);
        }

        // PUT: api/refVendorType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefVendorType(int id, ref_vendor_type ref_vendor_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_vendor_type.vendor_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_vendor_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_vendor_typeExists(id))
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

        // POST: api/refVendorType
        [ResponseType(typeof(ref_vendor_type))]
        public IHttpActionResult PostRefVendorType(ref_vendor_type ref_vendor_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_vendor_type.Add(ref_vendor_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_vendor_typeExists(ref_vendor_type.vendor_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_vendor_type.vendor_type_skey }, ref_vendor_type);
        }

        // DELETE: api/refVendorType/5
        [ResponseType(typeof(ref_vendor_type))]
        public IHttpActionResult DeleteRefVendorType(int id)
        {
            ref_vendor_type ref_vendor_type = db.ref_vendor_type.Find(id);
            if (ref_vendor_type == null)
            {
                return NotFound();
            }

            db.ref_vendor_type.Remove(ref_vendor_type);
            db.SaveChanges();

            return Ok(ref_vendor_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_vendor_typeExists(int id)
        {
            return db.ref_vendor_type.Count(e => e.vendor_type_skey == id) > 0;
        }
    }
}
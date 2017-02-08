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
    public class refVendorController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refVendor
        public IQueryable<ref_vendor> GetRefVendor()
        {
            return db.ref_vendor;
        }

        // GET: api/refVendor/5
        [ResponseType(typeof(ref_vendor))]
        public IHttpActionResult GetRefVendor(int id)
        {
            ref_vendor ref_vendor = db.ref_vendor.Find(id);
            if (ref_vendor == null)
            {
                return NotFound();
            }

            return Ok(ref_vendor);
        }

        // GET: api/GetRefVendorActive/
        [ResponseType(typeof(List<ref_vendor>))]
        public IHttpActionResult GetRefVendorActive()
        {
            List<ref_vendor> ref_vendors = db.ref_vendor.Where(a => a.status_skey == 1).ToList();

            if (ref_vendors == null)
            {
                return NotFound();
            }

            return Ok(ref_vendors);
        }

        // GET: api/GetRefVendorByClientSkey/5
        [ResponseType(typeof(List<ref_vendor>))]
        public IHttpActionResult GetRefVendorByClientSkey(int ClientSkey)
        {
            List<ref_vendor> ref_vendors = db.ref_vendor.Where(a => a.client_skey == ClientSkey).ToList();

            if (ref_vendors == null)
            {
                return NotFound();
            }

            return Ok(ref_vendors);
        }

        // GET: api/GetRefVendorByVendorTypeSkey/5
        [ResponseType(typeof(List<ref_vendor>))]
        public IHttpActionResult GetRefVendorByVendorTypeSkey(int VendorTypeSkey)
        {
            List<ref_vendor> ref_vendors = db.ref_vendor.Where(a => a.vendor_type_skey == VendorTypeSkey).ToList();

            if (ref_vendors == null)
            {
                return NotFound();
            }

            return Ok(ref_vendors);
        }

        // GET: api/GetRefVendorByStateCode/5
        [ResponseType(typeof(List<ref_vendor>))]
        public IHttpActionResult GetRefVendorByStateCode(string StateCode)
        {
            List<ref_vendor> ref_vendors = db.ref_vendor.Where(a => a.state_code == StateCode).ToList();

            if (ref_vendors == null)
            {
                return NotFound();
            }

            return Ok(ref_vendors);
        }

        // PUT: api/refVendor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefVendor(int id, ref_vendor ref_vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_vendor.vendor_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_vendor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_vendorExists(id))
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

        // POST: api/refVendor
        [ResponseType(typeof(ref_vendor))]
        public IHttpActionResult PostRefVendor(ref_vendor ref_vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_vendor.Add(ref_vendor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_vendor.vendor_skey }, ref_vendor);
        }

        // DELETE: api/refVendor/5
        [ResponseType(typeof(ref_vendor))]
        public IHttpActionResult DeleteRefVendor(int id)
        {
            ref_vendor ref_vendor = db.ref_vendor.Find(id);
            if (ref_vendor == null)
            {
                return NotFound();
            }

            db.ref_vendor.Remove(ref_vendor);
            db.SaveChanges();

            return Ok(ref_vendor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_vendorExists(int id)
        {
            return db.ref_vendor.Count(e => e.vendor_skey == id) > 0;
        }
    }
}
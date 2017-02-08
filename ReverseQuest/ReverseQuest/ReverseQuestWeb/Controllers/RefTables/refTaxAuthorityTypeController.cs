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
    public class refTaxAuthorityTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTaxAuthorityType
        public IQueryable<ref_tax_authority_type> GetRefTaxAuthorityType()
        {
            return db.ref_tax_authority_type;
        }

        // GET: api/refTaxAuthorityType/5
        [ResponseType(typeof(ref_tax_authority_type))]
        public IHttpActionResult GetRefTaxAuthorityType(int id)
        {
            ref_tax_authority_type ref_tax_authority_type = db.ref_tax_authority_type.Find(id);
            if (ref_tax_authority_type == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_authority_type);
        }

        // GET: api/GetRefTaxAuthorityTypeActive/
        [ResponseType(typeof(List<ref_tax_authority_type>))]
        public IHttpActionResult GetRefTaxAuthorityTypeActive()
        {
            List<ref_tax_authority_type> ref_tax_authority_types = db.ref_tax_authority_type.Where(a => a.status_skey == 1).ToList();

            if (ref_tax_authority_types == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_authority_types);
        }

        // GET: api/GetRefTaxAuthorityTypeByTaxAuthorityTypeCode/5
        [ResponseType(typeof(List<ref_tax_authority_type>))]
        public IHttpActionResult GetRefTaxAuthorityTypeByTaxAuthorityTypeCode(string TaxAuthorityTypeCode)
        {
            List<ref_tax_authority_type> ref_tax_authority_types = db.ref_tax_authority_type.Where(a => a.tax_authority_type_code == TaxAuthorityTypeCode).ToList();

            if (ref_tax_authority_types == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_authority_types);
        }

        // PUT: api/refTaxAuthorityType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTaxAuthorityType(int id, ref_tax_authority_type ref_tax_authority_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_tax_authority_type.tax_authority_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_tax_authority_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_tax_authority_typeExists(id))
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

        // POST: api/refTaxAuthorityType
        [ResponseType(typeof(ref_tax_authority_type))]
        public IHttpActionResult PostRefTaxAuthorityType(ref_tax_authority_type ref_tax_authority_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_tax_authority_type.Add(ref_tax_authority_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_tax_authority_typeExists(ref_tax_authority_type.tax_authority_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_tax_authority_type.tax_authority_type_skey }, ref_tax_authority_type);
        }

        // DELETE: api/refTaxAuthorityType/5
        [ResponseType(typeof(ref_tax_authority_type))]
        public IHttpActionResult DeleteRefTaxAuthorityType(int id)
        {
            ref_tax_authority_type ref_tax_authority_type = db.ref_tax_authority_type.Find(id);
            if (ref_tax_authority_type == null)
            {
                return NotFound();
            }

            db.ref_tax_authority_type.Remove(ref_tax_authority_type);
            db.SaveChanges();

            return Ok(ref_tax_authority_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_tax_authority_typeExists(int id)
        {
            return db.ref_tax_authority_type.Count(e => e.tax_authority_type_skey == id) > 0;
        }
    }
}
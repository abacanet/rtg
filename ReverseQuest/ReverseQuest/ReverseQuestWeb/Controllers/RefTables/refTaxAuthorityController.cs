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
    public class refTaxAuthorityController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTaxAuthority
        public IQueryable<ref_tax_authority> GetRefTaxAuthority()
        {
            return db.ref_tax_authority;
        }

        // GET: api/refTaxAuthority/5
        [ResponseType(typeof(ref_tax_authority))]
        public IHttpActionResult GetRefTaxAuthority(int id)
        {
            ref_tax_authority ref_tax_authority = db.ref_tax_authority.Find(id);
            if (ref_tax_authority == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_authority);
        }

        // GET: api/GetRefTaxAuthorityActive/
        [ResponseType(typeof(List<ref_tax_authority>))]
        public IHttpActionResult GetRefTaxAuthorityActive()
        {
            List<ref_tax_authority> ref_tax_authorities = db.ref_tax_authority.Where(a => a.status_skey == 1).ToList();

            if (ref_tax_authorities == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_authorities);
        }

        // GET: api/GetRefTaxAuthorityByStateCode/5
        [ResponseType(typeof(List<ref_tax_authority>))]
        public IHttpActionResult GetRefTaxAuthorityByStateCode(string StateCode)
        {
            List<ref_tax_authority> ref_tax_authorities = db.ref_tax_authority.Where(a => a.state_code == StateCode).ToList();

            if (ref_tax_authorities == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_authorities);
        }

        // PUT: api/refTaxAuthority/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTaxAuthority(int id, ref_tax_authority ref_tax_authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_tax_authority.tax_authority_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_tax_authority).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_tax_authorityExists(id))
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

        // POST: api/refTaxAuthority
        [ResponseType(typeof(ref_tax_authority))]
        public IHttpActionResult PostRefTaxAuthority(ref_tax_authority ref_tax_authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_tax_authority.Add(ref_tax_authority);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_tax_authorityExists(ref_tax_authority.tax_authority_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_tax_authority.tax_authority_skey }, ref_tax_authority);
        }

        // DELETE: api/refTaxAuthority/5
        [ResponseType(typeof(ref_tax_authority))]
        public IHttpActionResult DeleteRefTaxAuthority(int id)
        {
            ref_tax_authority ref_tax_authority = db.ref_tax_authority.Find(id);
            if (ref_tax_authority == null)
            {
                return NotFound();
            }

            db.ref_tax_authority.Remove(ref_tax_authority);
            db.SaveChanges();

            return Ok(ref_tax_authority);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_tax_authorityExists(int id)
        {
            return db.ref_tax_authority.Count(e => e.tax_authority_skey == id) > 0;
        }
    }
}
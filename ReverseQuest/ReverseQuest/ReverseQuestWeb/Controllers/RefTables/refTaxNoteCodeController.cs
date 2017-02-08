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
    public class refTaxNoteCodeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refTaxNoteCode
        public IQueryable<ref_tax_note_code> GetRefTaxNoteCode()
        {
            return db.ref_tax_note_code;
        }

        // GET: api/refTaxNoteCode/5
        [ResponseType(typeof(ref_tax_note_code))]
        public IHttpActionResult GetRefTaxNoteCode(string id)
        {
            ref_tax_note_code ref_tax_note_code = db.ref_tax_note_code.Find(id);
            if (ref_tax_note_code == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_note_code);
        }

        // GET: api/GetRefTaxNoteCodeActive/
        [ResponseType(typeof(List<ref_tax_note_code>))]
        public IHttpActionResult GetRefTaxNoteCodeActive()
        {
            List<ref_tax_note_code> ref_tax_note_codes = db.ref_tax_note_code.Where(a => a.status_skey == 1).ToList();

            if (ref_tax_note_codes == null)
            {
                return NotFound();
            }

            return Ok(ref_tax_note_codes);
        }

        // PUT: api/refTaxNoteCode/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefTaxNoteCode(string id, ref_tax_note_code ref_tax_note_code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_tax_note_code.tax_note_code)
            {
                return BadRequest();
            }

            db.Entry(ref_tax_note_code).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_tax_note_codeExists(id))
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

        // POST: api/refTaxNoteCode
        [ResponseType(typeof(ref_tax_note_code))]
        public IHttpActionResult PostRefTaxNoteCode(ref_tax_note_code ref_tax_note_code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_tax_note_code.Add(ref_tax_note_code);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_tax_note_codeExists(ref_tax_note_code.tax_note_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_tax_note_code.tax_note_code }, ref_tax_note_code);
        }

        // DELETE: api/refTaxNoteCode/5
        [ResponseType(typeof(ref_tax_note_code))]
        public IHttpActionResult DeleteRefTaxNoteCode(string id)
        {
            ref_tax_note_code ref_tax_note_code = db.ref_tax_note_code.Find(id);
            if (ref_tax_note_code == null)
            {
                return NotFound();
            }

            db.ref_tax_note_code.Remove(ref_tax_note_code);
            db.SaveChanges();

            return Ok(ref_tax_note_code);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_tax_note_codeExists(string id)
        {
            return db.ref_tax_note_code.Count(e => e.tax_note_code == id) > 0;
        }
    }
}
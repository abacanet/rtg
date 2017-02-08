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
    public class refNoteTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refNoteType
        public IQueryable<ref_note_type> GetRefNoteType()
        {
            return db.ref_note_type;
        }

        // GET: api/refNoteType/5
        [ResponseType(typeof(ref_note_type))]
        public IHttpActionResult GetRefNoteType(int id)
        {
            ref_note_type ref_note_type = db.ref_note_type.Find(id);
            if (ref_note_type == null)
            {
                return NotFound();
            }

            return Ok(ref_note_type);
        }

        // GET: api/GetRefNoteTypeActive/
        [ResponseType(typeof(List<ref_note_type>))]
        [Route("NoteTypeActive")]
        public IHttpActionResult GetRefNoteTypeActive()
        {
            List<ref_note_type> ref_note_types = db.ref_note_type.Where(a => a.status_skey == 1).ToList();

            if (ref_note_types == null)
            {
                return NotFound();
            }

            return Ok(ref_note_types);
        }

        // PUT: api/refNoteType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefNoteType(int id, ref_note_type ref_note_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_note_type.note_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_note_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_note_typeExists(id))
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

        // POST: api/refNoteType
        [ResponseType(typeof(ref_note_type))]
        public IHttpActionResult PostRefNoteType(ref_note_type ref_note_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_note_type.Add(ref_note_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_note_typeExists(ref_note_type.note_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_note_type.note_type_skey }, ref_note_type);
        }

        // DELETE: api/refNoteType/5
        [ResponseType(typeof(ref_note_type))]
        public IHttpActionResult DeleteRefNoteType(int id)
        {
            ref_note_type ref_note_type = db.ref_note_type.Find(id);
            if (ref_note_type == null)
            {
                return NotFound();
            }

            db.ref_note_type.Remove(ref_note_type);
            db.SaveChanges();

            return Ok(ref_note_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_note_typeExists(int id)
        {
            return db.ref_note_type.Count(e => e.note_type_skey == id) > 0;
        }
    }
}
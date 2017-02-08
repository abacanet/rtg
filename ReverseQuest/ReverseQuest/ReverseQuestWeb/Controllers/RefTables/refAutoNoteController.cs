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

    public class refAutoNoteController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refAutoNote
        public IQueryable<ref_auto_note> GetRefAutoNote()
        {
            return db.ref_auto_note;
        }

        // GET: api/refAutoNote/5
        [ResponseType(typeof(ref_auto_note))]
        public IHttpActionResult GetRefAutoNote(int id)
        {
            ref_auto_note ref_auto_note = db.ref_auto_note.Find(id);
            if (ref_auto_note == null)
            {
                return NotFound();
            }

            return Ok(ref_auto_note);
        }

        // GET: api/refAutoNoteActive/
        [ResponseType(typeof(List<ref_auto_note>))]
        public IHttpActionResult GetRefAutoNoteActive()
        {
            List<ref_auto_note> ref_auto_notes = db.ref_auto_note.Where(a => a.status_skey == 1).ToList();

            if (ref_auto_notes == null)
            {
                return NotFound();
            }

            return Ok(ref_auto_notes);
        }

        // GET: api/refAutoNoteByNoteType/5
        [ResponseType(typeof(List<ref_auto_note>))]
        public IHttpActionResult GetRefAutoNoteByNoteType(int skey)
        {
            List<ref_auto_note> ref_auto_notes = db.ref_auto_note.Where(a => a.note_type_skey == skey).ToList();

            if (ref_auto_notes == null)
            {
                return NotFound();
            }

            return Ok(ref_auto_notes);
        }

        // PUT: api/refAutoNote/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefAutoNote(int id, ref_auto_note ref_auto_note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_auto_note.auto_note_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_auto_note).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_auto_noteExists(id))
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

        // POST: api/refAutoNote
        [ResponseType(typeof(ref_auto_note))]
        public IHttpActionResult PostRefAutoNote(ref_auto_note ref_auto_note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_auto_note.Add(ref_auto_note);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_auto_noteExists(ref_auto_note.auto_note_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_auto_note.auto_note_skey }, ref_auto_note);
        }

        // DELETE: api/refAutoNote/5
        [ResponseType(typeof(ref_auto_note))]
        public IHttpActionResult DeleteRefAutoNote(int id)
        {
            ref_auto_note ref_auto_note = db.ref_auto_note.Find(id);
            if (ref_auto_note == null)
            {
                return NotFound();
            }

            db.ref_auto_note.Remove(ref_auto_note);
            db.SaveChanges();

            return Ok(ref_auto_note);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_auto_noteExists(int id)
        {
            return db.ref_auto_note.Count(e => e.auto_note_skey == id) > 0;
        }
    }
}
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
    public class refLogMessageTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refLogMessageType
        public IQueryable<ref_log_message_type> GetRefLogMessageType()
        {
            return db.ref_log_message_type;
        }

        // GET: api/refLogMessageType/5
        [ResponseType(typeof(ref_log_message_type))]
        public IHttpActionResult GetRefLogMessageType(int id)
        {
            ref_log_message_type ref_log_message_type = db.ref_log_message_type.Find(id);
            if (ref_log_message_type == null)
            {
                return NotFound();
            }

            return Ok(ref_log_message_type);
        }

        // GET: api/GetRefLogMessageTypeActive/
        [ResponseType(typeof(List<ref_log_message_type>))]
        public IHttpActionResult GetRefLogMessageTypeActive()
        {
            List<ref_log_message_type> ref_log_message_types = db.ref_log_message_type.Where(a => a.status_skey == 1).ToList();

            if (ref_log_message_types == null)
            {
                return NotFound();
            }

            return Ok(ref_log_message_types);
        }

        // PUT: api/refLogMessageType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLogMessageType(int id, ref_log_message_type ref_log_message_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_log_message_type.log_message_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_log_message_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_log_message_typeExists(id))
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

        // POST: api/refLogMessageType
        [ResponseType(typeof(ref_log_message_type))]
        public IHttpActionResult PostRefLogMessageType(ref_log_message_type ref_log_message_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_log_message_type.Add(ref_log_message_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_log_message_typeExists(ref_log_message_type.log_message_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_log_message_type.log_message_type_skey }, ref_log_message_type);
        }

        // DELETE: api/refLogMessageType/5
        [ResponseType(typeof(ref_log_message_type))]
        public IHttpActionResult DeleteRefLogMessageType(int id)
        {
            ref_log_message_type ref_log_message_type = db.ref_log_message_type.Find(id);
            if (ref_log_message_type == null)
            {
                return NotFound();
            }

            db.ref_log_message_type.Remove(ref_log_message_type);
            db.SaveChanges();

            return Ok(ref_log_message_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_log_message_typeExists(int id)
        {
            return db.ref_log_message_type.Count(e => e.log_message_type_skey == id) > 0;
        }
    }
}
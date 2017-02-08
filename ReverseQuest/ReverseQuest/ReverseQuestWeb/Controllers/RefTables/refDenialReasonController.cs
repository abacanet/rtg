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

    public class refDenialReasonController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refDenialReason
        public IQueryable<ref_denial_reason> GetRefDenialReason()
        {
            return db.ref_denial_reason;
        }

        // GET: api/refDenialReason/5
        [ResponseType(typeof(ref_denial_reason))]
        public IHttpActionResult GetRefDenialReason(int id)
        {
            ref_denial_reason ref_denial_reason = db.ref_denial_reason.Find(id);
            if (ref_denial_reason == null)
            {
                return NotFound();
            }

            return Ok(ref_denial_reason);
        }

        // GET: api/refDenialReasonActive/
        [ResponseType(typeof(List<ref_denial_reason>))]
        public IHttpActionResult GetRefDenialReasonActive()
        {
            List<ref_denial_reason> ref_denial_reasons = db.ref_denial_reason.Where(a => a.status_skey == 1).ToList();

            if (ref_denial_reasons == null)
            {
                return NotFound();
            }

            return Ok(ref_denial_reasons);
        }

        // GET: api/refDenialReasonByServicingTypeSkey/5
        [ResponseType(typeof(List<ref_denial_reason>))]
        public IHttpActionResult GetRefDenialReasonByServicingTypeSkey(int servicingTypeSkey)
        {
            List<ref_denial_reason> ref_denial_reasons = db.ref_denial_reason.Where(a => a.servicing_type_skey == servicingTypeSkey).ToList();

            if (ref_denial_reasons == null)
            {
                return NotFound();
            }

            return Ok(ref_denial_reasons);
        }

        // PUT: api/refDenialReason/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefDenialReason(int id, ref_denial_reason ref_denial_reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_denial_reason.denial_reason_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_denial_reason).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_denial_reasonExists(id))
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

        // POST: api/refDenialReason
        [ResponseType(typeof(ref_denial_reason))]
        public IHttpActionResult PostRefDenialReason(ref_denial_reason ref_denial_reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_denial_reason.Add(ref_denial_reason);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_denial_reasonExists(ref_denial_reason.denial_reason_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_denial_reason.denial_reason_skey }, ref_denial_reason);
        }

        // DELETE: api/refDenialReason/5
        [ResponseType(typeof(ref_denial_reason))]
        public IHttpActionResult DeleteRefDenialReason(int id)
        {
            ref_denial_reason ref_denial_reason = db.ref_denial_reason.Find(id);
            if (ref_denial_reason == null)
            {
                return NotFound();
            }

            db.ref_denial_reason.Remove(ref_denial_reason);
            db.SaveChanges();

            return Ok(ref_denial_reason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_denial_reasonExists(int id)
        {
            return db.ref_denial_reason.Count(e => e.denial_reason_skey == id) > 0;
        }
    }
}
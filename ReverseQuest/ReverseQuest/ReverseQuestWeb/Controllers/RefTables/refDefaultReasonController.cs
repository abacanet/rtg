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

    public class refDefaultReasonController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refDefaultReason
        public IQueryable<ref_default_reason> GetRefDefaultReason()
        {
            return db.ref_default_reason;
        }

        // GET: api/refDefaultReason/5
        [ResponseType(typeof(ref_default_reason))]
        public IHttpActionResult GetRefDefaultReason(int id)
        {
            ref_default_reason ref_default_reason = db.ref_default_reason.Find(id);
            if (ref_default_reason == null)
            {
                return NotFound();
            }

            return Ok(ref_default_reason);
        }

        // GET: api/refDefaultReasonActive/
        [ResponseType(typeof(List<ref_default_reason>))]
        public IHttpActionResult GetRefDefaultReasonActive()
        {
            List<ref_default_reason> ref_default_reasons = db.ref_default_reason.Where(a => a.status_skey == 1).ToList();

            if (ref_default_reasons == null)
            {
                return NotFound();
            }

            return Ok(ref_default_reasons);
        }

        // GET: api/refDefaultReasonByServicingTypeSkey/5
        //[ResponseType(typeof(List<ref_default_reason>))]
        //public IHttpActionResult GetRefDefaultReasonByServicingTypeSkey(int servicingTypeSkey)
        //{
        //    List<ref_default_reason> ref_default_reasons = db.ref_default_reason.Where(a => a.servicing_type_skey == servicingTypeSkey).ToList();

        //    if (ref_default_reasons == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ref_default_reasons);
        //}

        //// GET: api/refDefaultReasonByloanSubStatusCode/
        //[ResponseType(typeof(List<ref_default_reason>))]
        //public IHttpActionResult GetRefDefaultReasonByloanSubStatusCode(string loanStatusSkey)
        //{
        //    List<ref_default_reason> ref_default_reasons = db.ref_default_reason.Where(a => a.status_skey == loanStatusSkey).ToList();

        //    if (ref_default_reasons == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ref_default_reasons);
        //}

        // PUT: api/refDefaultReason/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefDefaultReason(int id, ref_default_reason ref_default_reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_default_reason.default_reason_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_default_reason).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_default_reasonExists(id))
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

        // POST: api/refDefaultReason
        [ResponseType(typeof(ref_default_reason))]
        public IHttpActionResult PostRefDefaultReason(ref_default_reason ref_default_reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_default_reason.Add(ref_default_reason);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_default_reasonExists(ref_default_reason.default_reason_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_default_reason.default_reason_skey }, ref_default_reason);
        }

        // DELETE: api/refDefaultReason/5
        [ResponseType(typeof(ref_default_reason))]
        public IHttpActionResult DeleteRefDefaultReason(int id)
        {
            ref_default_reason ref_default_reason = db.ref_default_reason.Find(id);
            if (ref_default_reason == null)
            {
                return NotFound();
            }

            db.ref_default_reason.Remove(ref_default_reason);
            db.SaveChanges();

            return Ok(ref_default_reason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_default_reasonExists(int id)
        {
            return db.ref_default_reason.Count(e => e.default_reason_skey == id) > 0;
        }
    }
}
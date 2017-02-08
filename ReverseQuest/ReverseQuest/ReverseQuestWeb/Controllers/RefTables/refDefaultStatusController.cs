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

    public class refDefaultStatusController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refDefaultStatus
        public IQueryable<ref_default_status> GetRefDefaultStatus()
        {
            return db.ref_default_status;
        }

        // GET: api/refDefaultStatus/5
        [ResponseType(typeof(ref_default_status))]
        public IHttpActionResult GetRefDefaultStatus(int id)
        {
            ref_default_status ref_default_status = db.ref_default_status.Find(id);
            if (ref_default_status == null)
            {
                return NotFound();
            }

            return Ok(ref_default_status);
        }

        // GET: api/refDefaultStatusActive/
        [ResponseType(typeof(List<ref_default_status>))]
        public IHttpActionResult GetRefDefaultStatusActive()
        {
            List<ref_default_status> ref_default_statuses = db.ref_default_status.Where(a => a.status_skey == 1).ToList();

            if (ref_default_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_default_statuses);
        }

        // GET: api/refDefaultStatusByServicingTypeSkey/5
        [ResponseType(typeof(List<ref_default_status>))]
        public IHttpActionResult GetRefDefaultStatusByServicingTypeSkey(int servicingTypeSkey)
        {
            List<ref_default_status> ref_default_statuses = db.ref_default_status.Where(a => a.servicing_type_skey == servicingTypeSkey).ToList();

            if (ref_default_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_default_statuses);
        }

        // PUT: api/refDefaultStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefDefaultStatus(int id, ref_default_status ref_default_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_default_status.default_status_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_default_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_default_statusExists(id))
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

        // POST: api/refDefaultStatus
        [ResponseType(typeof(ref_default_status))]
        public IHttpActionResult PostRefDefaultStatus(ref_default_status ref_default_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_default_status.Add(ref_default_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_default_statusExists(ref_default_status.default_status_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_default_status.default_status_skey }, ref_default_status);
        }

        // DELETE: api/refDefaultStatus/5
        [ResponseType(typeof(ref_default_status))]
        public IHttpActionResult DeleteRefDefaultStatus(int id)
        {
            ref_default_status ref_default_status = db.ref_default_status.Find(id);
            if (ref_default_status == null)
            {
                return NotFound();
            }

            db.ref_default_status.Remove(ref_default_status);
            db.SaveChanges();

            return Ok(ref_default_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_default_statusExists(int id)
        {
            return db.ref_default_status.Count(e => e.default_status_skey == id) > 0;
        }
    }
}
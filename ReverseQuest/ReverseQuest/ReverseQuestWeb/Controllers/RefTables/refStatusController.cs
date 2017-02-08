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
    public class refStatusController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refStatus
        public IQueryable<ref_status> GetRefStatus()
        {
            return db.ref_status;
        }

        // GET: api/refStatus/5
        [ResponseType(typeof(ref_status))]
        public IHttpActionResult GetRefStatus(int id)
        {
            ref_status ref_status = db.ref_status.Find(id);
            if (ref_status == null)
            {
                return NotFound();
            }

            return Ok(ref_status);
        }

        // GET: api/GetRefStatusActive/
        [ResponseType(typeof(List<ref_status>))]
        [Route("StatusActive")]
        public IHttpActionResult GetRefStatusActive()
        {
            List<ref_status> ref_statuses = db.ref_status.Where(a => a.status_skey == 1).ToList();

            if (ref_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_statuses);
        }

        // PUT: api/refStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefStatus(int id, ref_status ref_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_status.status_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_statusExists(id))
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

        // POST: api/refStatus
        [ResponseType(typeof(ref_status))]
        public IHttpActionResult PostRefStatus(ref_status ref_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_status.Add(ref_status);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_status.status_skey }, ref_status);
        }

        // DELETE: api/refStatus/5
        [ResponseType(typeof(ref_status))]
        public IHttpActionResult DeleteRefStatus(int id)
        {
            ref_status ref_status = db.ref_status.Find(id);
            if (ref_status == null)
            {
                return NotFound();
            }

            db.ref_status.Remove(ref_status);
            db.SaveChanges();

            return Ok(ref_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_statusExists(int id)
        {
            return db.ref_status.Count(e => e.status_skey == id) > 0;
        }
    }
}
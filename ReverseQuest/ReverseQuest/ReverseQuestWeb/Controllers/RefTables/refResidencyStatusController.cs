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
    public class refResidencyStatusController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refResidencyStatus
        public IQueryable<ref_residency_status> GetRefResidencyStatus()
        {
            return db.ref_residency_status;
        }

        // GET: api/refResidencyStatus/5
        [ResponseType(typeof(ref_residency_status))]
        public IHttpActionResult GetRefResidencyStatus(int id)
        {
            ref_residency_status ref_residency_status = db.ref_residency_status.Find(id);
            if (ref_residency_status == null)
            {
                return NotFound();
            }

            return Ok(ref_residency_status);
        }

        // GET: api/GetRefResidencyStatusActive/
        [Route("ResidencyStatusActive")]
        [ResponseType(typeof(List<ref_residency_status>))]
        public IHttpActionResult GetRefResidencyStatusActive()
        {
            List<ref_residency_status> ref_residency_statuses = db.ref_residency_status.Where(a => a.status_skey == 1).ToList();

            if (ref_residency_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_residency_statuses);
        }

        // PUT: api/refResidencyStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefResidencyStatus(int id, ref_residency_status ref_residency_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_residency_status.residency_status_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_residency_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_residency_statusExists(id))
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

        // POST: api/refResidencyStatus
        [ResponseType(typeof(ref_residency_status))]
        public IHttpActionResult PostRefResidencyStatus(ref_residency_status ref_residency_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_residency_status.Add(ref_residency_status);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_residency_status.residency_status_skey }, ref_residency_status);
        }

        // DELETE: api/refResidencyStatus/5
        [ResponseType(typeof(ref_residency_status))]
        public IHttpActionResult DeleteRefResidencyStatus(int id)
        {
            ref_residency_status ref_residency_status = db.ref_residency_status.Find(id);
            if (ref_residency_status == null)
            {
                return NotFound();
            }

            db.ref_residency_status.Remove(ref_residency_status);
            db.SaveChanges();

            return Ok(ref_residency_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_residency_statusExists(int id)
        {
            return db.ref_residency_status.Count(e => e.residency_status_skey == id) > 0;
        }
    }
}
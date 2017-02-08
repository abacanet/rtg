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
    public class refMaritalStatusController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refMaritalStatus
        public IQueryable<ref_marital_status> GetRefMaritalStatus()
        {
            return db.ref_marital_status;
        }

        // GET: api/refMaritalStatus/5
        [ResponseType(typeof(ref_marital_status))]
        public IHttpActionResult GetRefMaritalStatus(int id)
        {
            ref_marital_status ref_marital_status = db.ref_marital_status.Find(id);
            if (ref_marital_status == null)
            {
                return NotFound();
            }

            return Ok(ref_marital_status);
        }

        // GET: api/GeRefMaritalStatusActive/
        [Route("MaritalStatusActive")]
        [ResponseType(typeof(List<ref_marital_status>))]
        public IHttpActionResult GetRefMaritalStatusActive()
        {
            List<ref_marital_status> ref_marital_statuses = db.ref_marital_status.Where(a => a.status_skey == 1).ToList();

            if (ref_marital_statuses == null)
            {
                return NotFound();
            }

            return Ok(ref_marital_statuses);
        }

        // PUT: api/refMaritalStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefMaritalStatus(int id, ref_marital_status ref_marital_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_marital_status.marital_status_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_marital_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_marital_statusExists(id))
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

        // POST: api/refMaritalStatus
        [ResponseType(typeof(ref_marital_status))]
        public IHttpActionResult PostRefMaritalStatus(ref_marital_status ref_marital_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_marital_status.Add(ref_marital_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_marital_statusExists(ref_marital_status.marital_status_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_marital_status.marital_status_skey }, ref_marital_status);
        }

        // DELETE: api/refMaritalStatus/5
        [ResponseType(typeof(ref_marital_status))]
        public IHttpActionResult DeleteRefMaritalStatus(int id)
        {
            ref_marital_status ref_marital_status = db.ref_marital_status.Find(id);
            if (ref_marital_status == null)
            {
                return NotFound();
            }

            db.ref_marital_status.Remove(ref_marital_status);
            db.SaveChanges();

            return Ok(ref_marital_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_marital_statusExists(int id)
        {
            return db.ref_marital_status.Count(e => e.marital_status_skey == id) > 0;
        }
    }
}
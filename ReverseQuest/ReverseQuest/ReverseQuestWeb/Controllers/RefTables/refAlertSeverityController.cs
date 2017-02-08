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

    public class refAlertSeverityController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refAlertSeverity
        public IQueryable<ref_alert_severity> GetRefAlertSeverity()
        {
            return db.ref_alert_severity;
        }

        // GET: api/refAlertSeverity/5
        [ResponseType(typeof(ref_alert_severity))]
        public IHttpActionResult GetRefAlertSeverity(int id)
        {
            ref_alert_severity ref_alert_severity = db.ref_alert_severity.Find(id);
            if (ref_alert_severity == null)
            {
                return NotFound();
            }

            return Ok(ref_alert_severity);
        }

        // GET: api/refAlertSeverityActive/
        [ResponseType(typeof(List<ref_alert_severity>))]
        public IHttpActionResult GetRefAlertSeverityActive()
        {
            List<ref_alert_severity> ref_alert_severities = db.ref_alert_severity.Where(a => a.status_skey == 1).ToList();

            if (ref_alert_severities == null)
            {
                return NotFound();
            }

            return Ok(ref_alert_severities);
        }

        // PUT: api/refAlertSeverity/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefAlertSeverity(int id, ref_alert_severity ref_alert_severity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_alert_severity.alert_severity_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_alert_severity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_alert_severityExists(id))
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

        // POST: api/refAlertSeverity
        [ResponseType(typeof(ref_alert_severity))]
        public IHttpActionResult PostRefAlertSeverity(ref_alert_severity ref_alert_severity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_alert_severity.Add(ref_alert_severity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_alert_severityExists(ref_alert_severity.alert_severity_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_alert_severity.alert_severity_skey }, ref_alert_severity);
        }

        // DELETE: api/refAlertSeverity/5
        [ResponseType(typeof(ref_alert_severity))]
        public IHttpActionResult DeleteRefAlertSeverity(int id)
        {
            ref_alert_severity ref_alert_severity = db.ref_alert_severity.Find(id);
            if (ref_alert_severity == null)
            {
                return NotFound();
            }

            db.ref_alert_severity.Remove(ref_alert_severity);
            db.SaveChanges();

            return Ok(ref_alert_severity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_alert_severityExists(int id)
        {
            return db.ref_alert_severity.Count(e => e.alert_severity_skey == id) > 0;
        }
    }
}
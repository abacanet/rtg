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
    public class refReportingPeriodController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refReportingPeriod
        public IQueryable<ref_reporting_period> GetRefReportingPeriod()
        {
            return db.ref_reporting_period;
        }

        // GET: api/refReportingPeriod/5
        [ResponseType(typeof(ref_reporting_period))]
        public IHttpActionResult GetRefReportingPeriod(int id)
        {
            ref_reporting_period ref_reporting_period = db.ref_reporting_period.Find(id);
            if (ref_reporting_period == null)
            {
                return NotFound();
            }

            return Ok(ref_reporting_period);
        }

        // GET: api/GetRefReportingPeriodActive/
        [ResponseType(typeof(List<ref_reporting_period>))]
        public IHttpActionResult GetRefReportingPeriodActive()
        {
            List<ref_reporting_period> ref_reporting_periods = db.ref_reporting_period.Where(a => a.status_skey == 1).ToList();

            if (ref_reporting_periods == null)
            {
                return NotFound();
            }

            return Ok(ref_reporting_periods);
        }

        // PUT: api/refReportingPeriod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefReportingPeriod(int id, ref_reporting_period ref_reporting_period)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_reporting_period.reporting_period_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_reporting_period).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_reporting_periodExists(id))
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

        // POST: api/refReportingPeriod
        [ResponseType(typeof(ref_reporting_period))]
        public IHttpActionResult PostRefReportingPeriod(ref_reporting_period ref_reporting_period)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_reporting_period.Add(ref_reporting_period);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_reporting_period.reporting_period_skey }, ref_reporting_period);
        }

        // DELETE: api/refReportingPeriod/5
        [ResponseType(typeof(ref_reporting_period))]
        public IHttpActionResult DeleteRefReportingPeriod(int id)
        {
            ref_reporting_period ref_reporting_period = db.ref_reporting_period.Find(id);
            if (ref_reporting_period == null)
            {
                return NotFound();
            }

            db.ref_reporting_period.Remove(ref_reporting_period);
            db.SaveChanges();

            return Ok(ref_reporting_period);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_reporting_periodExists(int id)
        {
            return db.ref_reporting_period.Count(e => e.reporting_period_skey == id) > 0;
        }
    }
}
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

    public class refBusinessDayController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refBusinessDay
        public IQueryable<ref_business_day> GetRefBusinessDay()
        {
            return db.ref_business_day;
        }

        // GET: api/refBusinessDay/5
        [ResponseType(typeof(ref_business_day))]
        public IHttpActionResult GetRefBusinessDay(int id)
        {
            ref_business_day ref_business_day = db.ref_business_day.Find(id);
            if (ref_business_day == null)
            {
                return NotFound();
            }

            return Ok(ref_business_day);
        }

        // GET: api/refRefBusinessDayActive/
        [ResponseType(typeof(List<ref_business_day>))]
        public IHttpActionResult GetRefBusinessDayActive()
        {
            List<ref_business_day> ref_business_days = db.ref_business_day.Where(a => a.status_skey == 1).ToList();

            if (ref_business_days == null)
            {
                return NotFound();
            }

            return Ok(ref_business_days);
        }

        // PUT: api/refBusinessDay/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefBusinessDay(int id, ref_business_day ref_business_day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_business_day.business_day_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_business_day).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_business_dayExists(id))
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

        // POST: api/refBusinessDay
        [ResponseType(typeof(ref_business_day))]
        public IHttpActionResult PostRefBusinessDay(ref_business_day ref_business_day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_business_day.Add(ref_business_day);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_business_day.business_day_skey }, ref_business_day);
        }

        // DELETE: api/refBusinessDay/5
        [ResponseType(typeof(ref_business_day))]
        public IHttpActionResult DeleteRefBusinessDay(int id)
        {
            ref_business_day ref_business_day = db.ref_business_day.Find(id);
            if (ref_business_day == null)
            {
                return NotFound();
            }

            db.ref_business_day.Remove(ref_business_day);
            db.SaveChanges();

            return Ok(ref_business_day);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_business_dayExists(int id)
        {
            return db.ref_business_day.Count(e => e.business_day_skey == id) > 0;
        }
    }
}
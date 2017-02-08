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

namespace ReverseQuestWeb.Controllers
{
    [RoutePrefix("refapi/v1")]

    public class refCountyClerkController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refCountyClerk
        public IQueryable<ref_county_clerk> GetRefCountyClerk()
        {
            return db.ref_county_clerk;
        }

        // GET: api/refCountyClerk/5
        [ResponseType(typeof(ref_county_clerk))]
        public IHttpActionResult GetRefCountyClerk(int id)
        {
            ref_county_clerk ref_county_clerk = db.ref_county_clerk.Find(id);
            if (ref_county_clerk == null)
            {
                return NotFound();
            }

            return Ok(ref_county_clerk);
        }

        // GET: api/refCountyClerkActive/
        [ResponseType(typeof(List<ref_county_clerk>))]
        public IHttpActionResult GetRefCountyClerkActive()
        {
            List<ref_county_clerk> ref_county_clerks = db.ref_county_clerk.Where(a => a.status_skey == 1).ToList();

            if (ref_county_clerks == null)
            {
                return NotFound();
            }

            return Ok(ref_county_clerks);
        }

        // PUT: api/refCountyClerk/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefCountyClerk(int id, ref_county_clerk ref_county_clerk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_county_clerk.county_clerk_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_county_clerk).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_county_clerkExists(id))
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

        // POST: api/refCountyClerk
        [ResponseType(typeof(ref_county_clerk))]
        public IHttpActionResult PostRefCountyClerk(ref_county_clerk ref_county_clerk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_county_clerk.Add(ref_county_clerk);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_county_clerkExists(ref_county_clerk.county_clerk_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_county_clerk.county_clerk_skey }, ref_county_clerk);
        }

        // DELETE: api/refCountyClerk/5
        [ResponseType(typeof(ref_county_clerk))]
        public IHttpActionResult DeleteRefCountyClerk(int id)
        {
            ref_county_clerk ref_county_clerk = db.ref_county_clerk.Find(id);
            if (ref_county_clerk == null)
            {
                return NotFound();
            }

            db.ref_county_clerk.Remove(ref_county_clerk);
            db.SaveChanges();

            return Ok(ref_county_clerk);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_county_clerkExists(int id)
        {
            return db.ref_county_clerk.Count(e => e.county_clerk_skey == id) > 0;
        }
    }
}
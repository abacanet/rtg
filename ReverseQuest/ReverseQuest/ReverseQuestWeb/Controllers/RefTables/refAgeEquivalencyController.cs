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
    public class refAgeEquivalencyController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refAgeEquivalency
        [Route("AgeEquivalency")]
        public IHttpActionResult GetRefAgeEquivalency()
        {
            return Json(db.ref_age_equivalency);
        }

        // GET: api/refAgeEquivalency/5
           
        [ResponseType(typeof(ref_age_equivalency))]
        public IHttpActionResult GetRefAgeEquivalency(int id)
        {
            ref_age_equivalency ref_age_equivalency = db.ref_age_equivalency.Find(id);
            if (ref_age_equivalency == null)
            {
                return NotFound();
            }

            return Ok(ref_age_equivalency);
        }

        // GET: api/refAgeEquivalencyActive/
        [ResponseType(typeof(List<ref_age_equivalency>))]
        public IHttpActionResult GetRefAgeEquivalencyActive()
        {
            List<ref_age_equivalency> ref_age_equivalencies = db.ref_age_equivalency.Where(a => a.status_skey == 1).ToList();

            if (ref_age_equivalencies == null)
            {
                return NotFound();
            }

            return Ok(ref_age_equivalencies);
        }

        // GET: api/refAgeEquivalencyByProductType/
        [ResponseType(typeof(List<ref_age_equivalency>))]
        public IHttpActionResult GetRefAgeEquivalencyByProductType(int skey)
        {
            List<ref_age_equivalency> ref_age_equivalencies = db.ref_age_equivalency.Where(a => a.product_type_skey == skey).ToList();

            if (ref_age_equivalencies == null)
            {
                return NotFound();
            }

            return Ok(ref_age_equivalencies);
        }

        // GET: api/refAgeEquivalencyByLookupKey/
        [ResponseType(typeof(List<ref_age_equivalency>))]
        public IHttpActionResult GetRefAgeEquivalencyByLookupKey(int key)
        {
            List<ref_age_equivalency> ref_age_equivalencies = db.ref_age_equivalency.Where(a => a.lookup_key == key).ToList();

            if (ref_age_equivalencies == null)
            {
                return NotFound();
            }

            return Ok(ref_age_equivalencies);
        }

        // PUT: api/refAgeEquivalency/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefAgeEquivalency(int id, ref_age_equivalency ref_age_equivalency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_age_equivalency.age_equivalency_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_age_equivalency).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_age_equivalencyExists(id))
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

        // POST: api/refAgeEquivalency
        [ResponseType(typeof(ref_age_equivalency))]
        public IHttpActionResult PostRefAgeEquivalency(ref_age_equivalency ref_age_equivalency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_age_equivalency.Add(ref_age_equivalency);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_age_equivalency.age_equivalency_skey }, ref_age_equivalency);
        }

        // DELETE: api/refAgeEquivalency/5
        [ResponseType(typeof(ref_age_equivalency))]
        public IHttpActionResult DeleteRefAgeEquivalency(int id)
        {
            ref_age_equivalency ref_age_equivalency = db.ref_age_equivalency.Find(id);
            if (ref_age_equivalency == null)
            {
                return NotFound();
            }

            db.ref_age_equivalency.Remove(ref_age_equivalency);
            db.SaveChanges();

            return Ok(ref_age_equivalency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_age_equivalencyExists(int id)
        {
            return db.ref_age_equivalency.Count(e => e.age_equivalency_skey == id) > 0;
        }
    }
}
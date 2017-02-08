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
    public class refLanguagePreferenceController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refLanguagePreference
        public IQueryable<ref_language_preference> GetRefLanguagePreference()
        {
            return db.ref_language_preference;
        }

        // GET: api/refLanguagePreference/5
        [ResponseType(typeof(ref_language_preference))]
        public IHttpActionResult GetRefLanguagePreference(int id)
        {
            ref_language_preference ref_language_preference = db.ref_language_preference.Find(id);
            if (ref_language_preference == null)
            {
                return NotFound();
            }

            return Ok(ref_language_preference);
        }

        // GET: api/GetRefLanguagePreferenceActive/
        [Route("LanguagePreferenceActive")]
        [ResponseType(typeof(List<ref_language_preference>))]
        public IHttpActionResult GetRefLanguagePreferenceActive()
        {
            List<ref_language_preference> ref_language_preferences = db.ref_language_preference.Where(a => a.status_skey == 1).ToList();

            if (ref_language_preferences == null)
            {
                return NotFound();
            }

            return Ok(ref_language_preferences);
        }

        // PUT: api/refLanguagePreference/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLanguagePreference(int id, ref_language_preference ref_language_preference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_language_preference.language_preference_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_language_preference).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_language_preferenceExists(id))
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

        // POST: api/refLanguagePreference
        [ResponseType(typeof(ref_language_preference))]
        public IHttpActionResult PostRefLanguagePreference(ref_language_preference ref_language_preference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_language_preference.Add(ref_language_preference);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_language_preferenceExists(ref_language_preference.language_preference_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_language_preference.language_preference_skey }, ref_language_preference);
        }

        // DELETE: api/refLanguagePreference/5
        [ResponseType(typeof(ref_language_preference))]
        public IHttpActionResult DeleteRefLanguagePreference(int id)
        {
            ref_language_preference ref_language_preference = db.ref_language_preference.Find(id);
            if (ref_language_preference == null)
            {
                return NotFound();
            }

            db.ref_language_preference.Remove(ref_language_preference);
            db.SaveChanges();

            return Ok(ref_language_preference);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_language_preferenceExists(int id)
        {
            return db.ref_language_preference.Count(e => e.language_preference_skey == id) > 0;
        }
    }
}
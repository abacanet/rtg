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

    public class refFloodZoneController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refFloodZone
        public IQueryable<ref_flood_zone> GetRefFloodZone()
        {
            return db.ref_flood_zone;
        }

        // GET: api/refFloodZone/5
        [ResponseType(typeof(ref_flood_zone))]
        public IHttpActionResult GetRefFloodZone(int id)
        {
            ref_flood_zone ref_flood_zone = db.ref_flood_zone.Find(id);
            if (ref_flood_zone == null)
            {
                return NotFound();
            }

            return Ok(ref_flood_zone);
        }

        // GET: api/refFloodZoneActive/
        [ResponseType(typeof(List<ref_flood_zone>))]
        public IHttpActionResult GetRefFloodZoneActive()
        {
            List<ref_flood_zone> ref_flood_zones = db.ref_flood_zone.Where(a => a.status_skey == 1).ToList();

            if (ref_flood_zones == null)
            {
                return NotFound();
            }

            return Ok(ref_flood_zones);
        }

        // PUT: api/refFloodZone/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefFloodZone(int id, ref_flood_zone ref_flood_zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_flood_zone.flood_zone_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_flood_zone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_flood_zoneExists(id))
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

        // POST: api/refFloodZone
        [ResponseType(typeof(ref_flood_zone))]
        public IHttpActionResult PostRefFloodZone(ref_flood_zone ref_flood_zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_flood_zone.Add(ref_flood_zone);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_flood_zoneExists(ref_flood_zone.flood_zone_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_flood_zone.flood_zone_skey }, ref_flood_zone);
        }

        // DELETE: api/refFloodZone/5
        [ResponseType(typeof(ref_flood_zone))]
        public IHttpActionResult DeleteRefFloodZone(int id)
        {
            ref_flood_zone ref_flood_zone = db.ref_flood_zone.Find(id);
            if (ref_flood_zone == null)
            {
                return NotFound();
            }

            db.ref_flood_zone.Remove(ref_flood_zone);
            db.SaveChanges();

            return Ok(ref_flood_zone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_flood_zoneExists(int id)
        {
            return db.ref_flood_zone.Count(e => e.flood_zone_skey == id) > 0;
        }
    }
}
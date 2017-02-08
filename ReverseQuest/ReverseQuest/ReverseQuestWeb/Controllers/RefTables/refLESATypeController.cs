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
    public class refLESATypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/ref_LESAType
        public IQueryable<ref_LESA_type> GetRefLESAType()
        {
            return db.ref_LESA_type;
        }

        // GET: api/ref_LESAType/5
        [ResponseType(typeof(ref_LESA_type))]
        public IHttpActionResult GetRefLESAType(int id)
        {
            ref_LESA_type ref_LESA_type = db.ref_LESA_type.Find(id);
            if (ref_LESA_type == null)
            {
                return NotFound();
            }

            return Ok(ref_LESA_type);
        }

        // GET: api/GetreLESATypeActive/
        [ResponseType(typeof(List<ref_LESA_type>))]
        public IHttpActionResult GetRefLESATypeActive()
        {
            List<ref_LESA_type> ref_LESA_types = db.ref_LESA_type.Where(a => a.status_skey == 1).ToList();

            if (ref_LESA_types == null)
            {
                return NotFound();
            }

            return Ok(ref_LESA_types);
        }

        // PUT: api/ref_LESAType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLESAType(int id, ref_LESA_type ref_LESA_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_LESA_type.LESA_type)
            {
                return BadRequest();
            }

            db.Entry(ref_LESA_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_LESA_typeExists(id))
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

        // POST: api/ref_LESAType
        [ResponseType(typeof(ref_LESA_type))]
        public IHttpActionResult PostRefLESAType(ref_LESA_type ref_LESA_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_LESA_type.Add(ref_LESA_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_LESA_typeExists(ref_LESA_type.LESA_type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_LESA_type.LESA_type }, ref_LESA_type);
        }

        // DELETE: api/ref_LESAType/5
        [ResponseType(typeof(ref_LESA_type))]
        public IHttpActionResult DeleteRefLESAType(int id)
        {
            ref_LESA_type ref_LESA_type = db.ref_LESA_type.Find(id);
            if (ref_LESA_type == null)
            {
                return NotFound();
            }

            db.ref_LESA_type.Remove(ref_LESA_type);
            db.SaveChanges();

            return Ok(ref_LESA_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_LESA_typeExists(int id)
        {
            return db.ref_LESA_type.Count(e => e.LESA_type == id) > 0;
        }
    }
}
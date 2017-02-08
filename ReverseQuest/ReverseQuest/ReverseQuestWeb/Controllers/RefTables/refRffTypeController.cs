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
    public class refRffTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refRffType
        public IQueryable<ref_rff_type> GetRefRffType()
        {
            return db.ref_rff_type;
        }

        // GET: api/refRffType/5
        [ResponseType(typeof(ref_rff_type))]
        public IHttpActionResult GetRefRffType(string id)
        {
            ref_rff_type ref_rff_type = db.ref_rff_type.Find(id);
            if (ref_rff_type == null)
            {
                return NotFound();
            }

            return Ok(ref_rff_type);
        }

        // GET: api/GetRefRffTypeActive/
        [ResponseType(typeof(List<ref_rff_type>))]
        public IHttpActionResult GetRefRffTypeActive()
        {
            List<ref_rff_type> ref_rff_types = db.ref_rff_type.Where(a => a.status_skey == 1).ToList();

            if (ref_rff_types == null)
            {
                return NotFound();
            }

            return Ok(ref_rff_types);
        }

        // PUT: api/refRffType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefRffType(string id, ref_rff_type ref_rff_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_rff_type.rff_type)
            {
                return BadRequest();
            }

            db.Entry(ref_rff_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_rff_typeExists(id))
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

        // POST: api/refRffType
        [ResponseType(typeof(ref_rff_type))]
        public IHttpActionResult PostRefRffType(ref_rff_type ref_rff_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_rff_type.Add(ref_rff_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_rff_typeExists(ref_rff_type.rff_type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_rff_type.rff_type }, ref_rff_type);
        }

        // DELETE: api/refRffType/5
        [ResponseType(typeof(ref_rff_type))]
        public IHttpActionResult DeleteRefRffType(string id)
        {
            ref_rff_type ref_rff_type = db.ref_rff_type.Find(id);
            if (ref_rff_type == null)
            {
                return NotFound();
            }

            db.ref_rff_type.Remove(ref_rff_type);
            db.SaveChanges();

            return Ok(ref_rff_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_rff_typeExists(string id)
        {
            return db.ref_rff_type.Count(e => e.rff_type == id) > 0;
        }
    }
}
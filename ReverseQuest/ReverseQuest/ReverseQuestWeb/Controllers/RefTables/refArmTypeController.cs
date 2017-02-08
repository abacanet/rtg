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

    public class refArmTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refArmType
        public IQueryable<ref_arm_type> GetRefArmType()
        {
            return db.ref_arm_type;
        }

        // GET: api/refArmType/5
        [ResponseType(typeof(ref_arm_type))]
        public IHttpActionResult GetRefArmType(string id)
        {
            ref_arm_type ref_arm_type = db.ref_arm_type.Find(id);
            if (ref_arm_type == null)
            {
                return NotFound();
            }

            return Ok(ref_arm_type);
        }

        // GET: api/refArmTypeActive/
        [ResponseType(typeof(List<ref_arm_type>))]
        public IHttpActionResult GetRefArmTypeActive()
        {
            List<ref_arm_type> ref_arm_types = db.ref_arm_type.Where(a => a.status_skey == 1).ToList();

            if (ref_arm_types == null)
            {
                return NotFound();
            }

            return Ok(ref_arm_types);
        }

        // PUT: api/refArmType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefArmType(string id, ref_arm_type ref_arm_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_arm_type.arm_type)
            {
                return BadRequest();
            }

            db.Entry(ref_arm_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_arm_typeExists(id))
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

        // POST: api/refArmType
        [ResponseType(typeof(ref_arm_type))]
        public IHttpActionResult PostRefArmType(ref_arm_type ref_arm_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_arm_type.Add(ref_arm_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_arm_typeExists(ref_arm_type.arm_type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_arm_type.arm_type }, ref_arm_type);
        }

        // DELETE: api/refArmType/5
        [ResponseType(typeof(ref_arm_type))]
        public IHttpActionResult DeleteRefArmType(string id)
        {
            ref_arm_type ref_arm_type = db.ref_arm_type.Find(id);
            if (ref_arm_type == null)
            {
                return NotFound();
            }

            db.ref_arm_type.Remove(ref_arm_type);
            db.SaveChanges();

            return Ok(ref_arm_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_arm_typeExists(string id)
        {
            return db.ref_arm_type.Count(e => e.arm_type == id) > 0;
        }
    }
}
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
    public class refPropertyValueTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refPropertyValueType
        public IQueryable<ref_property_value_type> GetRefPropertyValueType()
        {
            return db.ref_property_value_type;
        }

        // GET: api/refPropertyValueType/5
        [ResponseType(typeof(ref_property_value_type))]
        public IHttpActionResult GetRefPropertyValueType(int id)
        {
            ref_property_value_type ref_property_value_type = db.ref_property_value_type.Find(id);
            if (ref_property_value_type == null)
            {
                return NotFound();
            }

            return Ok(ref_property_value_type);
        }

        // GET: api/GetRefPropertyValueTypeActive/
        [ResponseType(typeof(List<ref_property_value_type>))]
        [Route("PropertyValueTypeActive")]
        public IHttpActionResult GetRefPropertyValueTypeActive()
        {
            List<ref_property_value_type> ref_property_value_types = db.ref_property_value_type.Where(a => a.status_skey == 1).ToList();

            if (ref_property_value_types == null)
            {
                return NotFound();
            }

            return Ok(ref_property_value_types);
        }

        // PUT: api/refPropertyValueType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefPropertyValueType(int id, ref_property_value_type ref_property_value_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_property_value_type.property_value_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_property_value_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_property_value_typeExists(id))
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

        // POST: api/refPropertyValueType
        [ResponseType(typeof(ref_property_value_type))]
        public IHttpActionResult PostRefPropertyValueType(ref_property_value_type ref_property_value_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_property_value_type.Add(ref_property_value_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_property_value_typeExists(ref_property_value_type.property_value_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_property_value_type.property_value_type_skey }, ref_property_value_type);
        }

        // DELETE: api/refPropertyValueType/5
        [ResponseType(typeof(ref_property_value_type))]
        public IHttpActionResult DeleteRefPropertyValueType(int id)
        {
            ref_property_value_type ref_property_value_type = db.ref_property_value_type.Find(id);
            if (ref_property_value_type == null)
            {
                return NotFound();
            }

            db.ref_property_value_type.Remove(ref_property_value_type);
            db.SaveChanges();

            return Ok(ref_property_value_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_property_value_typeExists(int id)
        {
            return db.ref_property_value_type.Count(e => e.property_value_type_skey == id) > 0;
        }
    }
}
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
    public class refPropertyValueSubTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refPropertyValueSubType
        public IQueryable<ref_property_value_sub_type> GetRefPropertyValueSubType()
        {
            return db.ref_property_value_sub_type;
        }

        // GET: api/refPropertyValueSubType/5
        [ResponseType(typeof(ref_property_value_sub_type))]
        public IHttpActionResult GetRefPropertyValueSubType(int id)
        {
            ref_property_value_sub_type ref_property_value_sub_type = db.ref_property_value_sub_type.Find(id);
            if (ref_property_value_sub_type == null)
            {
                return NotFound();
            }

            return Ok(ref_property_value_sub_type);
        }

        // GET: api/GetRefPropertyValueSubTypeActive/
        [ResponseType(typeof(List<ref_property_value_sub_type>))]
        [Route("PropertyValueSubTypeActive")]
        public IHttpActionResult GetRefPropertyValueSubTypeActive()
        {
            List<ref_property_value_sub_type> ref_property_value_sub_types = db.ref_property_value_sub_type.Where(a => a.status_skey == 1).ToList();

            if (ref_property_value_sub_types == null)
            {
                return NotFound();
            }

            return Ok(ref_property_value_sub_types);
        }

        // PUT: api/refPropertyValueSubType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefPropertyValueSubType(int id, ref_property_value_sub_type ref_property_value_sub_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_property_value_sub_type.property_value_sub_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_property_value_sub_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_property_value_sub_typeExists(id))
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

        // POST: api/refPropertyValueSubType
        [ResponseType(typeof(ref_property_value_sub_type))]
        public IHttpActionResult PostRefPropertyValueSubType(ref_property_value_sub_type ref_property_value_sub_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_property_value_sub_type.Add(ref_property_value_sub_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_property_value_sub_typeExists(ref_property_value_sub_type.property_value_sub_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_property_value_sub_type.property_value_sub_type_skey }, ref_property_value_sub_type);
        }

        // DELETE: api/refPropertyValueSubType/5
        [ResponseType(typeof(ref_property_value_sub_type))]
        public IHttpActionResult DeleteRefPropertyValueSubType(int id)
        {
            ref_property_value_sub_type ref_property_value_sub_type = db.ref_property_value_sub_type.Find(id);
            if (ref_property_value_sub_type == null)
            {
                return NotFound();
            }

            db.ref_property_value_sub_type.Remove(ref_property_value_sub_type);
            db.SaveChanges();

            return Ok(ref_property_value_sub_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_property_value_sub_typeExists(int id)
        {
            return db.ref_property_value_sub_type.Count(e => e.property_value_sub_type_skey == id) > 0;
        }
    }
}
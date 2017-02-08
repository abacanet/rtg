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
    public class refPropertyTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refPropertyType
        public IQueryable<ref_property_type> GetRefPropertyType()
        {
            return db.ref_property_type;
        }

        // GET: api/refPropertyType/5
        [ResponseType(typeof(ref_property_type))]
        public IHttpActionResult GetRefPropertyType(int id)
        {
            ref_property_type ref_property_type = db.ref_property_type.Find(id);
            if (ref_property_type == null)
            {
                return NotFound();
            }

            return Ok(ref_property_type);
        }

        // GET: api/GetRefPropertyTypeActive/
        [ResponseType(typeof(List<ref_property_type>))]
        public IHttpActionResult GetRefPropertyTypeActive()
        {
            List<ref_property_type> ref_property_types = db.ref_property_type.Where(a => a.status_skey == 1).ToList();

            if (ref_property_types == null)
            {
                return NotFound();
            }

            return Ok(ref_property_types);
        }

        // GET: api/GetRefPropertyTypeByPropertyTypeCategorySkey/5
        [ResponseType(typeof(List<ref_property_type>))]
        public IHttpActionResult GetRefPropertyTypeByPropertyTypeCategorySkey(int PropertyTypeCategorySkey)
        {
            List<ref_property_type> ref_property_types = db.ref_property_type.Where(a => a.property_type_category_skey == PropertyTypeCategorySkey).ToList();

            if (ref_property_types == null)
            {
                return NotFound();
            }

            return Ok(ref_property_types);
        }

        // GET: api/GetRefPropertyTypeByHmbsPropertyType/5
        [ResponseType(typeof(List<ref_property_type>))]
        public IHttpActionResult GetRefPropertyTypeByHmbsPropertyType(string HmbsPropertyType)
        {
            List<ref_property_type> ref_property_types = db.ref_property_type.Where(a => a.hmbs_property_type == HmbsPropertyType).ToList();

            if (ref_property_types == null)
            {
                return NotFound();
            }

            return Ok(ref_property_types);
        }

        // PUT: api/refPropertyType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefPropertyType(int id, ref_property_type ref_property_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_property_type.property_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_property_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_property_typeExists(id))
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

        // POST: api/refPropertyType
        [ResponseType(typeof(ref_property_type))]
        public IHttpActionResult PostRefPropertyType(ref_property_type ref_property_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_property_type.Add(ref_property_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_property_typeExists(ref_property_type.property_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_property_type.property_type_skey }, ref_property_type);
        }

        // DELETE: api/refPropertyType/5
        [ResponseType(typeof(ref_property_type))]
        public IHttpActionResult DeleteRefPropertyType(int id)
        {
            ref_property_type ref_property_type = db.ref_property_type.Find(id);
            if (ref_property_type == null)
            {
                return NotFound();
            }

            db.ref_property_type.Remove(ref_property_type);
            db.SaveChanges();

            return Ok(ref_property_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_property_typeExists(int id)
        {
            return db.ref_property_type.Count(e => e.property_type_skey == id) > 0;
        }
    }
}
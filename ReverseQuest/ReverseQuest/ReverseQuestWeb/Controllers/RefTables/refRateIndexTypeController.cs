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
    public class refRateIndexTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refRateIndexType
        public IQueryable<ref_rate_index_type> GetRefRateIndexType()
        {
            return db.ref_rate_index_type;
        }

        // GET: api/refRateIndexType/5
        [ResponseType(typeof(ref_rate_index_type))]
        public IHttpActionResult GetRefRateIndexType(int id)
        {
            ref_rate_index_type ref_rate_index_type = db.ref_rate_index_type.Find(id);
            if (ref_rate_index_type == null)
            {
                return NotFound();
            }

            return Ok(ref_rate_index_type);
        }

        // GET: api/GetRefRateIndexTypeActive/
        [ResponseType(typeof(List<ref_rate_index_type>))]
        public IHttpActionResult GetRefPropertyTypeActive()
        {
            List<ref_rate_index_type> ref_rate_index_types = db.ref_rate_index_type.Where(a => a.status_skey == 1).ToList();

            if (ref_rate_index_types == null)
            {
                return NotFound();
            }

            return Ok(ref_rate_index_types);
        }

        // GET: api/GetRefRateIndexTypeByIndexType/5
        [ResponseType(typeof(List<ref_rate_index_type>))]
        public IHttpActionResult GetRefRateIndexTypeByIndexType(string IndexType)
        {
            List<ref_rate_index_type> ref_rate_index_types = db.ref_rate_index_type.Where(a => a.index_type == IndexType).ToList();

            if (ref_rate_index_types == null)
            {
                return NotFound();
            }

            return Ok(ref_rate_index_types);
        }

        // PUT: api/refRateIndexType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefRateIndexType(int id, ref_rate_index_type ref_rate_index_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_rate_index_type.rate_index_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_rate_index_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_rate_index_typeExists(id))
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

        // POST: api/refRateIndexType
        [ResponseType(typeof(ref_rate_index_type))]
        public IHttpActionResult PostRefRateIndexType(ref_rate_index_type ref_rate_index_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_rate_index_type.Add(ref_rate_index_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_rate_index_typeExists(ref_rate_index_type.rate_index_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_rate_index_type.rate_index_type_skey }, ref_rate_index_type);
        }

        // DELETE: api/refRateIndexType/5
        [ResponseType(typeof(ref_rate_index_type))]
        public IHttpActionResult DeleteRefRateIndexType(int id)
        {
            ref_rate_index_type ref_rate_index_type = db.ref_rate_index_type.Find(id);
            if (ref_rate_index_type == null)
            {
                return NotFound();
            }

            db.ref_rate_index_type.Remove(ref_rate_index_type);
            db.SaveChanges();

            return Ok(ref_rate_index_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_rate_index_typeExists(int id)
        {
            return db.ref_rate_index_type.Count(e => e.rate_index_type_skey == id) > 0;
        }
    }
}
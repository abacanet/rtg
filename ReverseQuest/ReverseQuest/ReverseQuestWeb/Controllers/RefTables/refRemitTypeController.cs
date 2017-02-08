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
    public class refRemitTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refRemitType
        public IQueryable<ref_remit_type> GetRefRemitType()
        {
            return db.ref_remit_type;
        }

        // GET: api/refRemitType/5
        [ResponseType(typeof(ref_remit_type))]
        public IHttpActionResult GetRefRemitType(int id)
        {
            ref_remit_type ref_remit_type = db.ref_remit_type.Find(id);
            if (ref_remit_type == null)
            {
                return NotFound();
            }

            return Ok(ref_remit_type);
        }

        // GET: api/GetRefRemitTypeActive/
        [ResponseType(typeof(List<ref_remit_type>))]
        public IHttpActionResult GetRefRemitTypeActive()
        {
            List<ref_remit_type> ref_remit_types = db.ref_remit_type.Where(a => a.status_skey == 1).ToList();

            if (ref_remit_types == null)
            {
                return NotFound();
            }

            return Ok(ref_remit_types);
        }

        // GET: api/GetRefRemitTypeByRemitCategorySkey/5
        [ResponseType(typeof(List<ref_remit_type>))]
        public IHttpActionResult GetRefRemitTypeByRemitCategorySkey(int RemitCategorySkey)
        {
            List<ref_remit_type> ref_remit_types = db.ref_remit_type.Where(a => a.remit_category_skey == RemitCategorySkey).ToList();

            if (ref_remit_types == null)
            {
                return NotFound();
            }

            return Ok(ref_remit_types);
        }

        // PUT: api/refRemitType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefRemitType(int id, ref_remit_type ref_remit_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_remit_type.remit_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_remit_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_remit_typeExists(id))
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

        // POST: api/refRemitType
        [ResponseType(typeof(ref_remit_type))]
        public IHttpActionResult PostRefRemitType(ref_remit_type ref_remit_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_remit_type.Add(ref_remit_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_remit_typeExists(ref_remit_type.remit_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_remit_type.remit_type_skey }, ref_remit_type);
        }

        // DELETE: api/refRemitType/5
        [ResponseType(typeof(ref_remit_type))]
        public IHttpActionResult DeleteRefRemitType(int id)
        {
            ref_remit_type ref_remit_type = db.ref_remit_type.Find(id);
            if (ref_remit_type == null)
            {
                return NotFound();
            }

            db.ref_remit_type.Remove(ref_remit_type);
            db.SaveChanges();

            return Ok(ref_remit_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_remit_typeExists(int id)
        {
            return db.ref_remit_type.Count(e => e.remit_type_skey == id) > 0;
        }
    }
}
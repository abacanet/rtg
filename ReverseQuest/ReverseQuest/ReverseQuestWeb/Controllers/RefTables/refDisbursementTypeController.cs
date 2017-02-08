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

    public class refDisbursementTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refDisbursementType
        public IQueryable<ref_disbursement_type> GetRefDisbursementType()
        {
            return db.ref_disbursement_type;
        }

        // GET: api/refDisbursementType/5
        [ResponseType(typeof(ref_disbursement_type))]
        public IHttpActionResult GetRefDisbursementType(int id)
        {
            ref_disbursement_type ref_disbursement_type = db.ref_disbursement_type.Find(id);
            if (ref_disbursement_type == null)
            {
                return NotFound();
            }

            return Ok(ref_disbursement_type);
        }

        // GET: api/refDisbursementTypeActive/
        [ResponseType(typeof(List<ref_disbursement_type>))]
        public IHttpActionResult GetRefDisbursementTypeActive()
        {
            List<ref_disbursement_type> ref_disbursement_types = db.ref_disbursement_type.Where(a => a.status_skey == 1).ToList();

            if (ref_disbursement_types == null)
            {
                return NotFound();
            }

            return Ok(ref_disbursement_types);
        }

        // PUT: api/refDisbursementType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefDisbursementType(int id, ref_disbursement_type ref_disbursement_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_disbursement_type.disbursement_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_disbursement_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_disbursement_typeExists(id))
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

        // POST: api/refDisbursementType
        [ResponseType(typeof(ref_disbursement_type))]
        public IHttpActionResult PostRefDisbursementType(ref_disbursement_type ref_disbursement_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_disbursement_type.Add(ref_disbursement_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_disbursement_typeExists(ref_disbursement_type.disbursement_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_disbursement_type.disbursement_type_skey }, ref_disbursement_type);
        }

        // DELETE: api/refDisbursementType/5
        [ResponseType(typeof(ref_disbursement_type))]
        public IHttpActionResult DeleteRefDisbursementType(int id)
        {
            ref_disbursement_type ref_disbursement_type = db.ref_disbursement_type.Find(id);
            if (ref_disbursement_type == null)
            {
                return NotFound();
            }

            db.ref_disbursement_type.Remove(ref_disbursement_type);
            db.SaveChanges();

            return Ok(ref_disbursement_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_disbursement_typeExists(int id)
        {
            return db.ref_disbursement_type.Count(e => e.disbursement_type_skey == id) > 0;
        }
    }
}
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

    public class refDisbursementPayeeTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refDisbursementPayeeType
        public IQueryable<ref_disbursement_payee_type> GetRefDisbursementPayeeType()
        {
            return db.ref_disbursement_payee_type;
        }

        // GET: api/refDisbursementPayeeType/5
        [ResponseType(typeof(ref_disbursement_payee_type))]
        public IHttpActionResult GetRefDisbursementPayeeType(int id)
        {
            ref_disbursement_payee_type ref_disbursement_payee_type = db.ref_disbursement_payee_type.Find(id);
            if (ref_disbursement_payee_type == null)
            {
                return NotFound();
            }

            return Ok(ref_disbursement_payee_type);
        }

        // GET: api/refDisbursementPayeeTypeActive/
        [ResponseType(typeof(List<ref_disbursement_payee_type>))]
        public IHttpActionResult GetRefDisbursementPayeeTypeActive()
        {
            List<ref_disbursement_payee_type> ref_disbursement_payee_types = db.ref_disbursement_payee_type.Where(a => a.status_skey == 1).ToList();

            if (ref_disbursement_payee_types == null)
            {
                return NotFound();
            }

            return Ok(ref_disbursement_payee_types);
        }

        // PUT: api/refDisbursementPayeeType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefDisbursementPayeeType(int id, ref_disbursement_payee_type ref_disbursement_payee_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_disbursement_payee_type.payee_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_disbursement_payee_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_disbursement_payee_typeExists(id))
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

        // POST: api/refDisbursementPayeeType
        [ResponseType(typeof(ref_disbursement_payee_type))]
        public IHttpActionResult PostRefDisbursementPayeeType(ref_disbursement_payee_type ref_disbursement_payee_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_disbursement_payee_type.Add(ref_disbursement_payee_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_disbursement_payee_typeExists(ref_disbursement_payee_type.payee_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_disbursement_payee_type.payee_type_skey }, ref_disbursement_payee_type);
        }

        // DELETE: api/refDisbursementPayeeType/5
        [ResponseType(typeof(ref_disbursement_payee_type))]
        public IHttpActionResult DeleteRefDisbursementPayeeType(int id)
        {
            ref_disbursement_payee_type ref_disbursement_payee_type = db.ref_disbursement_payee_type.Find(id);
            if (ref_disbursement_payee_type == null)
            {
                return NotFound();
            }

            db.ref_disbursement_payee_type.Remove(ref_disbursement_payee_type);
            db.SaveChanges();

            return Ok(ref_disbursement_payee_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_disbursement_payee_typeExists(int id)
        {
            return db.ref_disbursement_payee_type.Count(e => e.payee_type_skey == id) > 0;
        }
    }
}
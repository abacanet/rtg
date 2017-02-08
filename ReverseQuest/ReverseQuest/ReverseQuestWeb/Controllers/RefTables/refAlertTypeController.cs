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

    public class refAlertTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refAlertType
        public IQueryable<ref_alert_type> GetRefAlertType()
        {
            return db.ref_alert_type;
        }

        // GET: api/refAlertType/5
        [ResponseType(typeof(ref_alert_type))]
        public IHttpActionResult GetRefAlertType(int id)
        {
            ref_alert_type ref_alert_type = db.ref_alert_type.Find(id);
            if (ref_alert_type == null)
            {
                return NotFound();
            }

            return Ok(ref_alert_type);
        }

        // GET: api/refAlertTypeActive/
        [ResponseType(typeof(List<ref_alert_type>))]
        [Route("AlertTypeActive")]

        public IHttpActionResult GetRefAlertTypeActive()
        {
            List<ref_alert_type> ref_alert_types = db.ref_alert_type.Where(a => a.status_skey == 1).ToList();

            if (ref_alert_types == null)
            {
                return NotFound();
            }

            return Ok(ref_alert_types);
        }

        // GET: api/refAlertTypeWithSeverity/5
        [ResponseType(typeof(List<ref_alert_type>))]
        public IHttpActionResult GetRefAlertTypeWithSeverity(int skey)
        {
            List<ref_alert_type> ref_alert_types = db.ref_alert_type.Where(a => a.alert_severity_skey == skey).ToList();

            if (ref_alert_types == null)
            {
                return NotFound();
            }

            return Ok(ref_alert_types);
        }

        // GET: api/GetRefAlertTypeWithLoanServicer/5
        [ResponseType(typeof(List<ref_alert_type>))]
        public IHttpActionResult GetRefAlertTypeWithClient(int skey)
        {
            List<ref_alert_type> ref_alert_types = db.ref_alert_type.Where(a => a.client_skey == skey).ToList();

            if (ref_alert_types == null)
            {
                return NotFound();
            }

            return Ok(ref_alert_types);
        }

        // PUT: api/refAlertType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefAlertType(int id, ref_alert_type ref_alert_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_alert_type.alert_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_alert_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_alert_typeExists(id))
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

        // POST: api/refAlertType
        [ResponseType(typeof(ref_alert_type))]
        public IHttpActionResult PostRefAlertType(ref_alert_type ref_alert_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_alert_type.Add(ref_alert_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_alert_typeExists(ref_alert_type.alert_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_alert_type.alert_type_skey }, ref_alert_type);
        }

        // DELETE: api/refAlertType/5
        [ResponseType(typeof(ref_alert_type))]
        public IHttpActionResult DeletRefAlertType(int id)
        {
            ref_alert_type ref_alert_type = db.ref_alert_type.Find(id);
            if (ref_alert_type == null)
            {
                return NotFound();
            }

            db.ref_alert_type.Remove(ref_alert_type);
            db.SaveChanges();

            return Ok(ref_alert_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_alert_typeExists(int id)
        {
            return db.ref_alert_type.Count(e => e.alert_type_skey == id) > 0;
        }
    }
}
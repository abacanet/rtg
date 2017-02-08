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
    public class refHmbsCustodianController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refHmbsCustodian
        public IQueryable<ref_hmbs_custodian> GetRefHmbsCustodian()
        {
            return db.ref_hmbs_custodian;
        }

        // GET: api/refHmbsCustodian/5
        [ResponseType(typeof(ref_hmbs_custodian))]
        public IHttpActionResult GetRefHmbsCustodian(int id)
        {
            ref_hmbs_custodian ref_hmbs_custodian = db.ref_hmbs_custodian.Find(id);
            if (ref_hmbs_custodian == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_custodian);
        }

        // GET: api/refHmbsCustodianActive/
        [ResponseType(typeof(List<ref_hmbs_custodian>))]
        public IHttpActionResult GetRefHmbsCustodianActive()
        {
            List<ref_hmbs_custodian> ref_hmbs_custodians = db.ref_hmbs_custodian.Where(a => a.status_skey == 1).ToList();

            if (ref_hmbs_custodians == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_custodians);
        }

        // GET: api/refHmbsCustodianByCustodianID/
        [ResponseType(typeof(List<ref_hmbs_custodian>))]
        public IHttpActionResult GetRefHmbsCustodianByCustodianID(string custodianID)
        {
            List<ref_hmbs_custodian> ref_hmbs_custodians = db.ref_hmbs_custodian.Where(a => a.custodian_id == custodianID).ToList();

            if (ref_hmbs_custodians == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_custodians);
        }

        // PUT: api/refHmbsCustodian/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefHmbsCustodian(int id, ref_hmbs_custodian ref_hmbs_custodian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_hmbs_custodian.hmbs_custodian_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_hmbs_custodian).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_hmbs_custodianExists(id))
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

        // POST: api/refHmbsCustodian
        [ResponseType(typeof(ref_hmbs_custodian))]
        public IHttpActionResult PostRefHmbsCustodian(ref_hmbs_custodian ref_hmbs_custodian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_hmbs_custodian.Add(ref_hmbs_custodian);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_hmbs_custodianExists(ref_hmbs_custodian.hmbs_custodian_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_hmbs_custodian.hmbs_custodian_skey }, ref_hmbs_custodian);
        }

        // DELETE: api/refHmbsCustodian/5
        [ResponseType(typeof(ref_hmbs_custodian))]
        public IHttpActionResult DeleteRefHmbsCustodian(int id)
        {
            ref_hmbs_custodian ref_hmbs_custodian = db.ref_hmbs_custodian.Find(id);
            if (ref_hmbs_custodian == null)
            {
                return NotFound();
            }

            db.ref_hmbs_custodian.Remove(ref_hmbs_custodian);
            db.SaveChanges();

            return Ok(ref_hmbs_custodian);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_hmbs_custodianExists(int id)
        {
            return db.ref_hmbs_custodian.Count(e => e.hmbs_custodian_skey == id) > 0;
        }
    }
}
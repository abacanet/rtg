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
    public class refHmbsIssuerController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refHmbsIssuer
        public IQueryable<ref_hmbs_issuer> GetRefHmbsIssuer()
        {
            return db.ref_hmbs_issuer;
        }

        // GET: api/refHmbsIssuer/5
        [ResponseType(typeof(ref_hmbs_issuer))]
        public IHttpActionResult GetRefHmbsIssuer(string id)
        {
            ref_hmbs_issuer ref_hmbs_issuer = db.ref_hmbs_issuer.Find(id);
            if (ref_hmbs_issuer == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_issuer);
        }

        // GET: api/refHmbsIssuerActive/
        [ResponseType(typeof(List<ref_hmbs_issuer>))]
        public IHttpActionResult GetRefHmbsIssuerActive()
        {
            List<ref_hmbs_issuer> ref_hmbs_issuers = db.ref_hmbs_issuer.Where(a => a.status_skey == 1).ToList();

            if (ref_hmbs_issuers == null)
            {
                return NotFound();
            }

            return Ok(ref_hmbs_issuers);
        }

        // PUT: api/refHmbsIssuer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefHmbsIssuer(string id, ref_hmbs_issuer ref_hmbs_issuer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_hmbs_issuer.hmbs_issuer_id)
            {
                return BadRequest();
            }

            db.Entry(ref_hmbs_issuer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_hmbs_issuerExists(id))
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

        // POST: api/refHmbsIssuer
        [ResponseType(typeof(ref_hmbs_issuer))]
        public IHttpActionResult PostRefHmbsIssuer(ref_hmbs_issuer ref_hmbs_issuer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_hmbs_issuer.Add(ref_hmbs_issuer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_hmbs_issuerExists(ref_hmbs_issuer.hmbs_issuer_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_hmbs_issuer.hmbs_issuer_id }, ref_hmbs_issuer);
        }

        // DELETE: api/refHmbsIssuer/5
        [ResponseType(typeof(ref_hmbs_issuer))]
        public IHttpActionResult DeleteRefHmbsIssuer(string id)
        {
            ref_hmbs_issuer ref_hmbs_issuer = db.ref_hmbs_issuer.Find(id);
            if (ref_hmbs_issuer == null)
            {
                return NotFound();
            }

            db.ref_hmbs_issuer.Remove(ref_hmbs_issuer);
            db.SaveChanges();

            return Ok(ref_hmbs_issuer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_hmbs_issuerExists(string id)
        {
            return db.ref_hmbs_issuer.Count(e => e.hmbs_issuer_id == id) > 0;
        }
    }
}
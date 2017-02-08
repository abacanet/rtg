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

namespace ReverseQuestWeb.Controllers
{
    [RoutePrefix("refapi/v1")]

    public class refBankRoutingController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refBankRouting
        public IQueryable<ref_bank_routing> GetRefBankRouting()
        {
            return db.ref_bank_routing;
        }

        // GET: api/refBankRouting/5
        [ResponseType(typeof(ref_bank_routing))]
        public IHttpActionResult GetRefBankRouting(string id)
        {
            ref_bank_routing ref_bank_routing = db.ref_bank_routing.Find(id);
            if (ref_bank_routing == null)
            {
                return NotFound();
            }

            return Ok(ref_bank_routing);
        }

        // GET: api/refBankRoutingActive/
        [ResponseType(typeof(List<ref_bank_routing>))]
        public IHttpActionResult GetRefBankRoutingActive()
        {
            List<ref_bank_routing> ref_bank_routings = db.ref_bank_routing.Where(a => a.status_skey == 1).ToList();

            if (ref_bank_routings == null)
            {
                return NotFound();
            }

            return Ok(ref_bank_routings);
        }

        // PUT: api/refBankRouting/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefBankRouting(string id, ref_bank_routing ref_bank_routing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_bank_routing.aba_number)
            {
                return BadRequest();
            }

            db.Entry(ref_bank_routing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_bank_routingExists(id))
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

        // POST: api/refBankRouting
        [ResponseType(typeof(ref_bank_routing))]
        public IHttpActionResult PostRefBankRouting(ref_bank_routing ref_bank_routing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_bank_routing.Add(ref_bank_routing);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_bank_routingExists(ref_bank_routing.aba_number))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_bank_routing.aba_number }, ref_bank_routing);
        }

        // DELETE: api/refBankRouting/5
        [ResponseType(typeof(ref_bank_routing))]
        public IHttpActionResult DeleteRefBankRouting(string id)
        {
            ref_bank_routing ref_bank_routing = db.ref_bank_routing.Find(id);
            if (ref_bank_routing == null)
            {
                return NotFound();
            }

            db.ref_bank_routing.Remove(ref_bank_routing);
            db.SaveChanges();

            return Ok(ref_bank_routing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_bank_routingExists(string id)
        {
            return db.ref_bank_routing.Count(e => e.aba_number == id) > 0;
        }
    }
}
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
    public class refGrowthMethodController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refGrowthMethod
        public IQueryable<ref_growth_method> GetRefGrowthMethod()
        {
            return db.ref_growth_method;
        }

        // GET: api/refGrowthMethod/5
        [ResponseType(typeof(ref_growth_method))]
        public IHttpActionResult GetRefGrowthMethod(int id)
        {
            ref_growth_method ref_growth_method = db.ref_growth_method.Find(id);
            if (ref_growth_method == null)
            {
                return NotFound();
            }

            return Ok(ref_growth_method);
        }

        // GET: api/refGrowthMethodActive/
        [ResponseType(typeof(List<ref_growth_method>))]
        public IHttpActionResult GetRefGrowthMethodActive()
        {
            List<ref_growth_method> ref_growth_methods = db.ref_growth_method.Where(a => a.status_skey == 1).ToList();

            if (ref_growth_methods == null)
            {
                return NotFound();
            }

            return Ok(ref_growth_methods);
        }

        // PUT: api/refGrowthMethod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefGrowthMethod(int id, ref_growth_method ref_growth_method)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_growth_method.growth_method_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_growth_method).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_growth_methodExists(id))
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

        // POST: api/refGrowthMethod
        [ResponseType(typeof(ref_growth_method))]
        public IHttpActionResult PostRefGrowthMethod(ref_growth_method ref_growth_method)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_growth_method.Add(ref_growth_method);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_growth_methodExists(ref_growth_method.growth_method_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_growth_method.growth_method_skey }, ref_growth_method);
        }

        // DELETE: api/refGrowthMethod/5
        [ResponseType(typeof(ref_growth_method))]
        public IHttpActionResult DeleteRefGrowthMethod(int id)
        {
            ref_growth_method ref_growth_method = db.ref_growth_method.Find(id);
            if (ref_growth_method == null)
            {
                return NotFound();
            }

            db.ref_growth_method.Remove(ref_growth_method);
            db.SaveChanges();

            return Ok(ref_growth_method);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_growth_methodExists(int id)
        {
            return db.ref_growth_method.Count(e => e.growth_method_skey == id) > 0;
        }
    }
}
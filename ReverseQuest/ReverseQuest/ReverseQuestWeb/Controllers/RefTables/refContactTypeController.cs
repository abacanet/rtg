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

    public class refContactTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refContactType/GetContactTypes
        [ResponseType(typeof(ref_contact_type))]
        [System.Web.Http.AcceptVerbs("GET")]
        public IQueryable<ref_contact_type> GetRefContactType()
        {
            return db.ref_contact_type;
        }

        // GET: api/refContactType/5
        [ResponseType(typeof(ref_contact_type))]
        [System.Web.Http.AcceptVerbs("GET")]
        public IHttpActionResult GetRefContactType(int id)
        {
            ref_contact_type ref_contact_type = db.ref_contact_type.Find(id);
            if (ref_contact_type == null)
            {
                return NotFound();
            }

            return Ok(ref_contact_type);
        }

        // GET: api/refContactTypeActive/
        [ResponseType(typeof(List<ref_contact_type>))]
        [Route("ContactTypesActive")]
        [System.Web.Http.AcceptVerbs("GET")]
        public IHttpActionResult GetRefContactTypeActive()
        {
            List<ref_contact_type> ref_contact_types = db.ref_contact_type.Where(a => a.status_skey == 1).ToList();

            if (ref_contact_types == null)
            {
                return NotFound();
            }

            return Ok(ref_contact_types);
        }
       // // GET: api/refContactTypeActive/
       //// [ResponseType(typeof(List<ref_contact_type>))]
       // [System.Web.Http.Route("api/GetRefContactTypeActive2")]
       // [System.Web.Http.AcceptVerbs("GET")]
       // public IHttpActionResult GetRefContactTypeActive2()
       // {
       //     List<ref_contact_type> ref_contact_types = db.ref_contact_type.Where(a => a.status_skey == 1).
       //         Select( s.contact_type_skey);

       //     if (ref_contact_types == null)
       //     {
       //         return NotFound();
       //     }

       //     return Ok(ref_contact_types);
       // }

        // PUT: api/refContactType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefContactType(int id, ref_contact_type ref_contact_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_contact_type.contact_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_contact_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_contact_typeExists(id))
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

        // POST: api/refContactType
        [ResponseType(typeof(ref_contact_type))]
        public IHttpActionResult PostRefContactType(ref_contact_type ref_contact_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_contact_type.Add(ref_contact_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_contact_typeExists(ref_contact_type.contact_type_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_contact_type.contact_type_skey }, ref_contact_type);
        }

        // DELETE: api/refContactType/5
        [ResponseType(typeof(ref_contact_type))]
        public IHttpActionResult DeleteRefContactType(int id)
        {
            ref_contact_type ref_contact_type = db.ref_contact_type.Find(id);
            if (ref_contact_type == null)
            {
                return NotFound();
            }

            db.ref_contact_type.Remove(ref_contact_type);
            db.SaveChanges();

            return Ok(ref_contact_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_contact_typeExists(int id)
        {
            return db.ref_contact_type.Count(e => e.contact_type_skey == id) > 0;
        }
    }
}
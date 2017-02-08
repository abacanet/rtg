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
    public class refRffGroupController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refRffGroup
        public IQueryable<ref_rff_group> GetRefRffGroup()
        {
            return db.ref_rff_group;
        }

        // GET: api/refRffGroup/5
        [ResponseType(typeof(ref_rff_group))]
        public IHttpActionResult GetRefRffGroup(int id)
        {
            ref_rff_group ref_rff_group = db.ref_rff_group.Find(id);
            if (ref_rff_group == null)
            {
                return NotFound();
            }

            return Ok(ref_rff_group);
        }

        // GET: api/GetRefRffGroupActive/
        [ResponseType(typeof(List<ref_rff_group>))]
        public IHttpActionResult GetRefRffGroupActive()
        {
            List<ref_rff_group> ref_rff_groups = db.ref_rff_group.Where(a => a.status_skey == 1).ToList();

            if (ref_rff_groups == null)
            {
                return NotFound();
            }

            return Ok(ref_rff_groups);
        }

        // GET: api/GetRefRffGroupByRffType/5
        [ResponseType(typeof(List<ref_rff_group>))]
        public IHttpActionResult GetRefRffGroupByRffType(string RffType)
        {
            List<ref_rff_group> ref_rff_groups = db.ref_rff_group.Where(a => a.rff_type == RffType).ToList();

            if (ref_rff_groups == null)
            {
                return NotFound();
            }

            return Ok(ref_rff_groups);
        }

        // GET: api/GetRefRffGroupByClientSkey/5
        [ResponseType(typeof(List<ref_rff_group>))]
        public IHttpActionResult GetRefRffGroupByClientSkey(int ClientSkey)
        {
            List<ref_rff_group> ref_rff_groups = db.ref_rff_group.Where(a => a.client_skey == ClientSkey).ToList();

            if (ref_rff_groups == null)
            {
                return NotFound();
            }

            return Ok(ref_rff_groups);
        }

        // PUT: api/refRffGroup/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefRffGroup(int id, ref_rff_group ref_rff_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_rff_group.rff_group_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_rff_group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_rff_groupExists(id))
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

        // POST: api/refRffGroup
        [ResponseType(typeof(ref_rff_group))]
        public IHttpActionResult PostRefRffGroup(ref_rff_group ref_rff_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_rff_group.Add(ref_rff_group);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_rff_groupExists(ref_rff_group.rff_group_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_rff_group.rff_group_skey }, ref_rff_group);
        }

        // DELETE: api/refRffGroup/5
        [ResponseType(typeof(ref_rff_group))]
        public IHttpActionResult DeleteRefRffGroup(int id)
        {
            ref_rff_group ref_rff_group = db.ref_rff_group.Find(id);
            if (ref_rff_group == null)
            {
                return NotFound();
            }

            db.ref_rff_group.Remove(ref_rff_group);
            db.SaveChanges();

            return Ok(ref_rff_group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_rff_groupExists(int id)
        {
            return db.ref_rff_group.Count(e => e.rff_group_skey == id) > 0;
        }
    }
}
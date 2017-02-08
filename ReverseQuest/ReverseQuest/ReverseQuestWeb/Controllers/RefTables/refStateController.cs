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
    public class refStateController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refState
        public IQueryable<ref_state> GetRefState()
        {
            return db.ref_state;
        }

        // GET: api/refState/5
        [ResponseType(typeof(ref_state))]
        public IHttpActionResult GetRefState(int id)
        {
            ref_state ref_state = db.ref_state.Find(id);
            if (ref_state == null)
            {
                return NotFound();
            }

            return Ok(ref_state);
        }

        // GET: api/GetRefStateActive/
        [Route("States")]
        [ResponseType(typeof(List<ref_state>))]
        public IHttpActionResult GetRefStateActive()
        {
            var ref_states = db.ref_state.Where(a => a.status_skey == 1).Select(s => new { state_code = s.state_code, state_name = s.state_name }).ToList();

            if (ref_states == null)
            {
                return NotFound();
            }

            return Ok(ref_states);
        }

        // GET: api/GetRefStateByHocSkey/5
        [ResponseType(typeof(List<ref_state>))]
        public IHttpActionResult GetRefStateByHocSkey(int HocSkey)
        {
            List<ref_state> ref_states = db.ref_state.Where(a => a.hoc_skey == HocSkey).ToList();

            if (ref_states == null)
            {
                return NotFound();
            }

            return Ok(ref_states);
        }

        // PUT: api/refState/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefState(int id, ref_state ref_state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_state.status_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_state).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_stateExists(id))
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

        // POST: api/refState
        [ResponseType(typeof(ref_state))]
        public IHttpActionResult PostRefState(ref_state ref_state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_state.Add(ref_state);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_stateExists(ref_state.status_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_state.status_skey }, ref_state);
        }

        // DELETE: api/refState/5
        [ResponseType(typeof(ref_state))]
        public IHttpActionResult DeleteRefState(int id)
        {
            ref_state ref_state = db.ref_state.Find(id);
            if (ref_state == null)
            {
                return NotFound();
            }

            db.ref_state.Remove(ref_state);
            db.SaveChanges();

            return Ok(ref_state);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_stateExists(int id)
        {
            return db.ref_state.Count(e => e.status_skey == id) > 0;
        }
    }
}
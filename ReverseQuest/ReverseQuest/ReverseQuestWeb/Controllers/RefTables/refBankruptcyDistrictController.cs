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

    public class refBankruptcyDistrictController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refBankruptcyDistrict
        public IQueryable<ref_bankruptcy_district> GetRefBankruptcyDistrict()
        {
            return db.ref_bankruptcy_district;
        }

        // GET: api/refBankruptcyDistrict/5
        [ResponseType(typeof(ref_bankruptcy_district))]
        public IHttpActionResult GetRefBankruptcyDistrict(int id)
        {
            ref_bankruptcy_district ref_bankruptcy_district = db.ref_bankruptcy_district.Find(id);
            if (ref_bankruptcy_district == null)
            {
                return NotFound();
            }

            return Ok(ref_bankruptcy_district);
        }

        // GET: api/refBankruptcyDistrictActive/
        [ResponseType(typeof(List<ref_bankruptcy_district>))]
        public IHttpActionResult GetRefBankruptcyDistrictActive()
        {
            List<ref_bankruptcy_district> ref_bankruptcy_districts = db.ref_bankruptcy_district.Where(a => a.status_skey == 1).ToList();

            if (ref_bankruptcy_districts == null)
            {
                return NotFound();
            }

            return Ok(ref_bankruptcy_districts);
        }

        // GET: api/refBankruptcyDistrictByStateCode/
        [ResponseType(typeof(List<ref_bankruptcy_district>))]
        public IHttpActionResult GetRefBankruptcyDistrictByStateCode(string stateCode)
        {
            List<ref_bankruptcy_district> ref_bankruptcy_districts = db.ref_bankruptcy_district.Where(a => a.state_code == stateCode).ToList();

            if (ref_bankruptcy_districts == null)
            {
                return NotFound();
            }

            return Ok(ref_bankruptcy_districts);
        }

        // PUT: api/refBankruptcyDistrict/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefBankruptcyDistrict(int id, ref_bankruptcy_district ref_bankruptcy_district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_bankruptcy_district.bankruptcy_district_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_bankruptcy_district).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_bankruptcy_districtExists(id))
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

        // POST: api/refBankruptcyDistrict
        [ResponseType(typeof(ref_bankruptcy_district))]
        public IHttpActionResult PostRefBankruptcyDistrict(ref_bankruptcy_district ref_bankruptcy_district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_bankruptcy_district.Add(ref_bankruptcy_district);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_bankruptcy_districtExists(ref_bankruptcy_district.bankruptcy_district_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_bankruptcy_district.bankruptcy_district_skey }, ref_bankruptcy_district);
        }

        // DELETE: api/refBankruptcyDistrict/5
        [ResponseType(typeof(ref_bankruptcy_district))]
        public IHttpActionResult DeleteRefBankruptcyDistrict(int id)
        {
            ref_bankruptcy_district ref_bankruptcy_district = db.ref_bankruptcy_district.Find(id);
            if (ref_bankruptcy_district == null)
            {
                return NotFound();
            }

            db.ref_bankruptcy_district.Remove(ref_bankruptcy_district);
            db.SaveChanges();

            return Ok(ref_bankruptcy_district);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_bankruptcy_districtExists(int id)
        {
            return db.ref_bankruptcy_district.Count(e => e.bankruptcy_district_skey == id) > 0;
        }
    }
}
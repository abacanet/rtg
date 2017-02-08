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
    public class refLoanBoardingValidationMappingController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refLoanBoardingValidationMapping
        public IQueryable<ref_loan_boarding_validation_mapping> GetRefLoanBoardingValidationMapping()
        {
            return db.ref_loan_boarding_validation_mapping;
        }

        // GET: api/refLoanBoardingValidationMapping/5
        [ResponseType(typeof(ref_loan_boarding_validation_mapping))]
        public IHttpActionResult GetRefLoanBoardingValidationMapping(int id)
        {
            ref_loan_boarding_validation_mapping ref_loan_boarding_validation_mapping = db.ref_loan_boarding_validation_mapping.Find(id);
            if (ref_loan_boarding_validation_mapping == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_boarding_validation_mapping);
        }

        // GET: api/GetRefLoanBoardingValidationMappingActive/
        [ResponseType(typeof(List<ref_loan_boarding_validation_mapping>))]
        public IHttpActionResult GetRefLoanBoardingValidationMappingActive()
        {
            List<ref_loan_boarding_validation_mapping> ref_loan_boarding_validation_mappings = db.ref_loan_boarding_validation_mapping.Where(a => a.status_skey == 1).ToList();

            if (ref_loan_boarding_validation_mappings == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_boarding_validation_mappings);
        }

        // GET: api/GetRefLoanBoardingValidationMappingByProductTypeSkey/5
        [ResponseType(typeof(List<ref_loan_boarding_validation_mapping>))]
        public IHttpActionResult GetRefLoanBoardingValidationMappingByProductTypeSkey(int productTypeSkey)
        {
            List<ref_loan_boarding_validation_mapping> ref_loan_boarding_validation_mappings = db.ref_loan_boarding_validation_mapping.Where(a => a.product_type_skey == productTypeSkey).ToList();

            if (ref_loan_boarding_validation_mappings == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_boarding_validation_mappings);
        }

        // PUT: api/refLoanBoardingValidationMapping/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLoanBoardingValidationMapping(int id, ref_loan_boarding_validation_mapping ref_loan_boarding_validation_mapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_loan_boarding_validation_mapping.loan_boarding_validation_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_loan_boarding_validation_mapping).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_loan_boarding_validation_mappingExists(id))
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

        // POST: api/refLoanBoardingValidationMapping
        [ResponseType(typeof(ref_loan_boarding_validation_mapping))]
        public IHttpActionResult PostRefLoanBoardingValidationMapping(ref_loan_boarding_validation_mapping ref_loan_boarding_validation_mapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_loan_boarding_validation_mapping.Add(ref_loan_boarding_validation_mapping);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_loan_boarding_validation_mapping.loan_boarding_validation_skey }, ref_loan_boarding_validation_mapping);
        }

        // DELETE: api/refLoanBoardingValidationMapping/5
        [ResponseType(typeof(ref_loan_boarding_validation_mapping))]
        public IHttpActionResult DeleteRefLoanBoardingValidationMapping(int id)
        {
            ref_loan_boarding_validation_mapping ref_loan_boarding_validation_mapping = db.ref_loan_boarding_validation_mapping.Find(id);
            if (ref_loan_boarding_validation_mapping == null)
            {
                return NotFound();
            }

            db.ref_loan_boarding_validation_mapping.Remove(ref_loan_boarding_validation_mapping);
            db.SaveChanges();

            return Ok(ref_loan_boarding_validation_mapping);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_loan_boarding_validation_mappingExists(int id)
        {
            return db.ref_loan_boarding_validation_mapping.Count(e => e.loan_boarding_validation_skey == id) > 0;
        }
    }
}
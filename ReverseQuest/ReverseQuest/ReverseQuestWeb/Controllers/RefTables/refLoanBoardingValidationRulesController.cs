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
    public class refLoanBoardingValidationRulesController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refLoanBoardingValidationRules
        public IQueryable<ref_loan_boarding_validation_rules> GetRefLoanBoardingValidationRules()
        {
            return db.ref_loan_boarding_validation_rules;
        }

        // GET: api/refLoanBoardingValidationRules/5
        [ResponseType(typeof(ref_loan_boarding_validation_rules))]
        public IHttpActionResult GetRefLoanBoardingValidationRules(int id)
        {
            ref_loan_boarding_validation_rules ref_loan_boarding_validation_rules = db.ref_loan_boarding_validation_rules.Find(id);
            if (ref_loan_boarding_validation_rules == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_boarding_validation_rules);
        }

        // GET: api/GetRefLoanBoardingValidationRulesActive/
        [ResponseType(typeof(List<ref_loan_boarding_validation_rules>))]
        public IHttpActionResult GetRefLoanBoardingValidationRulesActive()
        {
            List<ref_loan_boarding_validation_rules> ref_loan_boarding_val_rules = db.ref_loan_boarding_validation_rules.Where(a => a.status_skey == 1).ToList();

            if (ref_loan_boarding_val_rules == null)
            {
                return NotFound();
            }

            return Ok(ref_loan_boarding_val_rules);
        }

        // PUT: api/refLoanBoardingValidationRules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefLoanBoardingValidationRules(int id, ref_loan_boarding_validation_rules ref_loan_boarding_validation_rules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_loan_boarding_validation_rules.validation_code)
            {
                return BadRequest();
            }

            db.Entry(ref_loan_boarding_validation_rules).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_loan_boarding_validation_rulesExists(id))
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

        // POST: api/refLoanBoardingValidationRules
        [ResponseType(typeof(ref_loan_boarding_validation_rules))]
        public IHttpActionResult PostRefLoanBoardingValidationRules(ref_loan_boarding_validation_rules ref_loan_boarding_validation_rules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_loan_boarding_validation_rules.Add(ref_loan_boarding_validation_rules);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_loan_boarding_validation_rulesExists(ref_loan_boarding_validation_rules.validation_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_loan_boarding_validation_rules.validation_code }, ref_loan_boarding_validation_rules);
        }

        // DELETE: api/refLoanBoardingValidationRules/5
        [ResponseType(typeof(ref_loan_boarding_validation_rules))]
        public IHttpActionResult DeleteRefLoanBoardingValidationRules(int id)
        {
            ref_loan_boarding_validation_rules ref_loan_boarding_validation_rules = db.ref_loan_boarding_validation_rules.Find(id);
            if (ref_loan_boarding_validation_rules == null)
            {
                return NotFound();
            }

            db.ref_loan_boarding_validation_rules.Remove(ref_loan_boarding_validation_rules);
            db.SaveChanges();

            return Ok(ref_loan_boarding_validation_rules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_loan_boarding_validation_rulesExists(int id)
        {
            return db.ref_loan_boarding_validation_rules.Count(e => e.validation_code == id) > 0;
        }
    }
}
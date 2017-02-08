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
    public class refInvestorBankAccountController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refInvestorBankAccount
        public IQueryable<ref_investor_bank_account> GetRefInvestorBankAccount()
        {
            return db.ref_investor_bank_account;
        }

        // GET: api/refInvestorBankAccount/5
        [ResponseType(typeof(ref_investor_bank_account))]
        public IHttpActionResult GetRefInvestorBankAccount(int id)
        {
            ref_investor_bank_account ref_investor_bank_account = db.ref_investor_bank_account.Find(id);
            if (ref_investor_bank_account == null)
            {
                return NotFound();
            }

            return Ok(ref_investor_bank_account);
        }

        // GET: api/GGetRefInvestorBankAccountActive/
        [ResponseType(typeof(List<ref_investor_bank_account>))]
        public IHttpActionResult GGetRefInvestorBankAccountActive()
        {
            List<ref_investor_bank_account> ref_investor_bank_accounts = db.ref_investor_bank_account.Where(a => a.status_skey == 1).ToList();

            if (ref_investor_bank_accounts == null)
            {
                return NotFound();
            }

            return Ok(ref_investor_bank_accounts);
        }

        // PUT: api/refInvestorBankAccount/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefInvestorBankAccount(int id, ref_investor_bank_account ref_investor_bank_account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_investor_bank_account.investor_bank_account_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_investor_bank_account).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_investor_bank_accountExists(id))
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

        // POST: api/refInvestorBankAccount
        [ResponseType(typeof(ref_investor_bank_account))]
        public IHttpActionResult PostRefInvestorBankAccount(ref_investor_bank_account ref_investor_bank_account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_investor_bank_account.Add(ref_investor_bank_account);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_investor_bank_accountExists(ref_investor_bank_account.investor_bank_account_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_investor_bank_account.investor_bank_account_skey }, ref_investor_bank_account);
        }

        // DELETE: api/refInvestorBankAccount/5
        [ResponseType(typeof(ref_investor_bank_account))]
        public IHttpActionResult DeleteRefInvestorBankAccount(int id)
        {
            ref_investor_bank_account ref_investor_bank_account = db.ref_investor_bank_account.Find(id);
            if (ref_investor_bank_account == null)
            {
                return NotFound();
            }

            db.ref_investor_bank_account.Remove(ref_investor_bank_account);
            db.SaveChanges();

            return Ok(ref_investor_bank_account);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_investor_bank_accountExists(int id)
        {
            return db.ref_investor_bank_account.Count(e => e.investor_bank_account_skey == id) > 0;
        }
    }
}
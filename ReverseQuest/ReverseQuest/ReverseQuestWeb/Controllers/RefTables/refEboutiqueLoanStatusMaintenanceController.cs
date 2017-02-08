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

    public class refEboutiqueLoanStatusMaintenanceController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refEboutiqueLoanStatusMaintenance
        public IQueryable<ref_eboutique_loan_status_maintenance> GeRefEboutiqueLoanStatusMaintenance()
        {
            return db.ref_eboutique_loan_status_maintenance;
        }

        // GET: api/refEboutiqueLoanStatusMaintenance/5
        [ResponseType(typeof(ref_eboutique_loan_status_maintenance))]
        public IHttpActionResult GeRefEboutiqueLoanStatusMaintenance(int id)
        {
            ref_eboutique_loan_status_maintenance ref_eboutique_loan_status_maintenance = db.ref_eboutique_loan_status_maintenance.Find(id);
            if (ref_eboutique_loan_status_maintenance == null)
            {
                return NotFound();
            }

            return Ok(ref_eboutique_loan_status_maintenance);
        }

        // GET: api/refEboutiqueLoanStatusMaintenanceActive/
        [ResponseType(typeof(List<ref_eboutique_loan_status_maintenance>))]
        public IHttpActionResult GetRefEboutiqueLoanStatusMaintenanceActive()
        {
            List<ref_eboutique_loan_status_maintenance> ref_eboutique_loan_status_maintenances = db.ref_eboutique_loan_status_maintenance.Where(a => a.status_skey == 1).ToList();

            if (ref_eboutique_loan_status_maintenances == null)
            {
                return NotFound();
            }

            return Ok(ref_eboutique_loan_status_maintenances);
        }

        // PUT: api/refEboutiqueLoanStatusMaintenance/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefEboutiqueLoanStatusMaintenance(int id, ref_eboutique_loan_status_maintenance ref_eboutique_loan_status_maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_eboutique_loan_status_maintenance.loan_status_mainterest_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_eboutique_loan_status_maintenance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_eboutique_loan_status_maintenanceExists(id))
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

        // POST: api/refEboutiqueLoanStatusMaintenance
        [ResponseType(typeof(ref_eboutique_loan_status_maintenance))]
        public IHttpActionResult PostRefEboutiqueLoanStatusMaintenance(ref_eboutique_loan_status_maintenance ref_eboutique_loan_status_maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_eboutique_loan_status_maintenance.Add(ref_eboutique_loan_status_maintenance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ref_eboutique_loan_status_maintenanceExists(ref_eboutique_loan_status_maintenance.loan_status_mainterest_skey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ref_eboutique_loan_status_maintenance.loan_status_mainterest_skey }, ref_eboutique_loan_status_maintenance);
        }

        // DELETE: api/refEboutiqueLoanStatusMaintenance/5
        [ResponseType(typeof(ref_eboutique_loan_status_maintenance))]
        public IHttpActionResult DeleteRefEboutiqueLoanStatusMaintenance(int id)
        {
            ref_eboutique_loan_status_maintenance ref_eboutique_loan_status_maintenance = db.ref_eboutique_loan_status_maintenance.Find(id);
            if (ref_eboutique_loan_status_maintenance == null)
            {
                return NotFound();
            }

            db.ref_eboutique_loan_status_maintenance.Remove(ref_eboutique_loan_status_maintenance);
            db.SaveChanges();

            return Ok(ref_eboutique_loan_status_maintenance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_eboutique_loan_status_maintenanceExists(int id)
        {
            return db.ref_eboutique_loan_status_maintenance.Count(e => e.loan_status_mainterest_skey == id) > 0;
        }
    }
}
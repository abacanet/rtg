//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using ReverseQuestWeb.Models;

//namespace ReverseQuestWeb.Controllers.RefTables
//{
//    public class refLoanSubStatusCategoryController : ApiController
//    {
//        private ReverseQuestEntities db = new ReverseQuestEntities();

//        // GET: api/refLoanSubStatusCategory
//        public IQueryable< ref_loan_sub ref_loan_sub_status_category> GetRefLoanSubStatusCategory()
//        {
//            return db.ref_loan_sub_status_category;
//        }

//        // GET: api/refLoanSubStatusCategory/5
//        [ResponseType(typeof(ref_loan_sub_status_category))]
//        public IHttpActionResult GetRefLoanSubStatusCategory(int id)
//        {
//            ref_loan_sub_status_category ref_loan_sub_status_category = db.ref_loan_sub_status_category.Find(id);
//            if (ref_loan_sub_status_category == null)
//            {
//                return NotFound();
//            }

//            return Ok(ref_loan_sub_status_category);
//        }

//        // GET: api/GetRefLoanSubStatusCategoryActive/
//        [ResponseType(typeof(List<ref_loan_sub_status_category>))]
//        public IHttpActionResult GetRefLoanSubStatusCategoryActive()
//        {
//            List<ref_loan_sub_status_category> ref_loan_sub_status_categories = db.ref_loan_sub_status_category.Where(a => a.status_skey == 1).ToList();

//            if (ref_loan_sub_status_categories == null)
//            {
//                return NotFound();
//            }

//            return Ok(ref_loan_sub_status_categories);
//        }

//        // PUT: api/refLoanSubStatusCategory/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutRefLoanSubStatusCategory(int id, ref_loan_sub_status_category ref_loan_sub_status_category)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != ref_loan_sub_status_category.loan_sub_status_category_skey)
//            {
//                return BadRequest();
//            }

//            db.Entry(ref_loan_sub_status_category).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ref_loan_sub_status_categoryExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/refLoanSubStatusCategory
//        [ResponseType(typeof(ref_loan_sub_status_category))]
//        public IHttpActionResult PostRefLoanSubStatusCategory(ref_loan_sub_status_category ref_loan_sub_status_category)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.ref_loan_sub_status_category.Add(ref_loan_sub_status_category);

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateException)
//            {
//                if (ref_loan_sub_status_categoryExists(ref_loan_sub_status_category.loan_sub_status_category_skey))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtRoute("DefaultApi", new { id = ref_loan_sub_status_category.loan_sub_status_category_skey }, ref_loan_sub_status_category);
//        }

//        // DELETE: api/refLoanSubStatusCategory/5
//        [ResponseType(typeof(ref_loan_sub_status_category))]
//        public IHttpActionResult DeleteRefLoanSubStatusCategory(int id)
//        {
//            ref_loan_sub_status_category ref_loan_sub_status_category = db.ref_loan_sub_status_category.Find(id);
//            if (ref_loan_sub_status_category == null)
//            {
//                return NotFound();
//            }

//            db.ref_loan_sub_status_category.Remove(ref_loan_sub_status_category);
//            db.SaveChanges();

//            return Ok(ref_loan_sub_status_category);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool ref_loan_sub_status_categoryExists(int id)
//        {
//            return db.ref_loan_sub_status_category.Count(e => e.loan_sub_status_category_skey == id) > 0;
//        }
//    }
//}
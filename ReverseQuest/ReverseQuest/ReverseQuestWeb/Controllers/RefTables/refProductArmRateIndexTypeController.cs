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
    public class refProductArmRateIndexTypeController : ApiController
    {
        private ReverseQuestEntities db = new ReverseQuestEntities();

        // GET: api/refProductArmRateIndexType
        public IQueryable<ref_product_arm_rate_index_type> GetRefProductArmRateIndexType()
        {
            return db.ref_product_arm_rate_index_type;
        }

        // GET: api/refProductArmRateIndexType/5
        [ResponseType(typeof(ref_product_arm_rate_index_type))]
        public IHttpActionResult GetRefProductArmRateIndexType(int id)
        {
            ref_product_arm_rate_index_type ref_product_arm_rate_index_type = db.ref_product_arm_rate_index_type.Find(id);
            if (ref_product_arm_rate_index_type == null)
            {
                return NotFound();
            }

            return Ok(ref_product_arm_rate_index_type);
        }

        // GET: api/GetRefProductArmRateIndexTypeActive/
        [ResponseType(typeof(List<ref_product_arm_rate_index_type>))]
        public IHttpActionResult GetRefProductArmRateIndexTypeActive()
        {
            List<ref_product_arm_rate_index_type> ref_product_arm_rate_index_types = db.ref_product_arm_rate_index_type.Where(a => a.status_skey == 1).ToList();

            if (ref_product_arm_rate_index_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_arm_rate_index_types);
        }

        // GET: api/GetRefProductArmRateIndexTypeByProductTypeSkey/5
        [ResponseType(typeof(List<ref_product_arm_rate_index_type>))]
        public IHttpActionResult GetRefProductArmRateIndexTypeByProductTypeSkey(int ProductTypeSkey)
        {
            List<ref_product_arm_rate_index_type> ref_product_arm_rate_index_types = db.ref_product_arm_rate_index_type.Where(a => a.product_type_skey == ProductTypeSkey).ToList();

            if (ref_product_arm_rate_index_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_arm_rate_index_types);
        }

        // GET: api/GetRefProductArmRateIndexTypeByRateIndexTypeSkey/5
        [ResponseType(typeof(List<ref_product_arm_rate_index_type>))]
        public IHttpActionResult GetRefProductArmRateIndexTypeByRateIndexTypeSkey(int RateIndexTypeSkey)
        {
            List<ref_product_arm_rate_index_type> ref_product_arm_rate_index_types = db.ref_product_arm_rate_index_type.Where(a => a.rate_index_type_skey == RateIndexTypeSkey).ToList();

            if (ref_product_arm_rate_index_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_arm_rate_index_types);
        }

        // GET: api/GetRefProductArmRateIndexTypeByArmType/5
        [ResponseType(typeof(List<ref_product_arm_rate_index_type>))]
        public IHttpActionResult GetRefProductArmRateIndexTypeByArmType(string ArmType)
        {
            List<ref_product_arm_rate_index_type> ref_product_arm_rate_index_types = db.ref_product_arm_rate_index_type.Where(a => a.arm_type == ArmType).ToList();

            if (ref_product_arm_rate_index_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_arm_rate_index_types);
        }

        // GET: api/GetRefProductArmRateIndexTypeByHmdsPoolType/5
        [ResponseType(typeof(List<ref_product_arm_rate_index_type>))]
        public IHttpActionResult GetRefProductArmRateIndexTypeByHmdsPoolType(string HmdsPoolType)
        {
            List<ref_product_arm_rate_index_type> ref_product_arm_rate_index_types = db.ref_product_arm_rate_index_type.Where(a => a.hmbs_pool_type == HmdsPoolType).ToList();

            if (ref_product_arm_rate_index_types == null)
            {
                return NotFound();
            }

            return Ok(ref_product_arm_rate_index_types);
        }

        // PUT: api/refProductArmRateIndexType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefProductArmRateIndexType(int id, ref_product_arm_rate_index_type ref_product_arm_rate_index_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ref_product_arm_rate_index_type.product_arm_rate_index_type_skey)
            {
                return BadRequest();
            }

            db.Entry(ref_product_arm_rate_index_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ref_product_arm_rate_index_typeExists(id))
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

        // POST: api/refProductArmRateIndexType
        [ResponseType(typeof(ref_product_arm_rate_index_type))]
        public IHttpActionResult PostRefProductArmRateIndexType(ref_product_arm_rate_index_type ref_product_arm_rate_index_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ref_product_arm_rate_index_type.Add(ref_product_arm_rate_index_type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ref_product_arm_rate_index_type.product_arm_rate_index_type_skey }, ref_product_arm_rate_index_type);
        }

        // DELETE: api/refProductArmRateIndexType/5
        [ResponseType(typeof(ref_product_arm_rate_index_type))]
        public IHttpActionResult DeleteRefProductArmRateIndexType(int id)
        {
            ref_product_arm_rate_index_type ref_product_arm_rate_index_type = db.ref_product_arm_rate_index_type.Find(id);
            if (ref_product_arm_rate_index_type == null)
            {
                return NotFound();
            }

            db.ref_product_arm_rate_index_type.Remove(ref_product_arm_rate_index_type);
            db.SaveChanges();

            return Ok(ref_product_arm_rate_index_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ref_product_arm_rate_index_typeExists(int id)
        {
            return db.ref_product_arm_rate_index_type.Count(e => e.product_arm_rate_index_type_skey == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HospitalDeliveriesController : ApiController
    {
        private TestHospitalDelivery db = new TestHospitalDelivery();

        // GET: api/HospitalDeliveries
        public IQueryable<HospitalDelivery> GetHospitalDeliveries()
        {
            return db.HospitalDeliveries;
        }

        // GET: api/HospitalDeliveries/5
        [ResponseType(typeof(HospitalDelivery))]
        public async Task<IHttpActionResult> GetHospitalDelivery(int id)
        {
            HospitalDelivery hospitalDelivery = await db.HospitalDeliveries.FindAsync(id);
            if (hospitalDelivery == null)
            {
                return NotFound();
            }

            return Ok(hospitalDelivery);
        }

        // GET: api/HospitalDeliveries/5
        [ResponseType(typeof(HospitalDelivery))]
        public async Task<IHttpActionResult> GetHospital(string ccn)
        {
            HospitalDelivery hospitalDelivery = await db.HospitalDeliveries.FindAsync(ccn);
            if (hospitalDelivery == null)
            {
                return NotFound();
            }

            return Ok(hospitalDelivery);
        }

        // PUT: api/HospitalDeliveries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHospitalDelivery(int id, HospitalDelivery hospitalDelivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalDelivery.DeliveryID)
            {
                return BadRequest();
            }

            db.Entry(hospitalDelivery).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalDeliveryExists(id))
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

        // POST: api/HospitalDeliveries
        [ResponseType(typeof(HospitalDelivery))]
        public async Task<IHttpActionResult> PostHospitalDelivery(HospitalDelivery hospitalDelivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HospitalDeliveries.Add(hospitalDelivery);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HospitalDeliveryExists(hospitalDelivery.DeliveryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hospitalDelivery.DeliveryID }, hospitalDelivery);
        }

        // DELETE: api/HospitalDeliveries/5
        [ResponseType(typeof(HospitalDelivery))]
        public async Task<IHttpActionResult> DeleteHospitalDelivery(int id)
        {
            HospitalDelivery hospitalDelivery = await db.HospitalDeliveries.FindAsync(id);
            if (hospitalDelivery == null)
            {
                return NotFound();
            }

            db.HospitalDeliveries.Remove(hospitalDelivery);
            await db.SaveChangesAsync();

            return Ok(hospitalDelivery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalDeliveryExists(int id)
        {
            return db.HospitalDeliveries.Count(e => e.DeliveryID == id) > 0;
        }
    }
}
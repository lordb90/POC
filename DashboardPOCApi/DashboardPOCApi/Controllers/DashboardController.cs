using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DashboardPOCApi.Models;

namespace DashboardPOCApi.Controllers
{
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        private DashboardContext db = new DashboardContext();

        // GET: api/Hospitals
        //[Route(Name = "Dashboard")]
        //public IQueryable<HospitalDelivery> GetHospitalDeliveries()
        //{
        //    return db.HospitalDeliveries;
        //}

        // GET: api/Hospitals/5
        [ResponseType(typeof(HospitalDelivery))]
        [Route("~/api/dashboard/ccn")]
        public async Task<IHttpActionResult> GetHospitalDelivery(string ccn, long reportingQuarter)
        {
            HospitalDelivery hospitalDelivery = await db.HospitalDeliveries.FindAsync(ccn);
            if (hospitalDelivery == null)
            {
                return NotFound();
            }

            return Ok(hospitalDelivery);
        }

        // PUT: api/Hospitals/5
        [Route("~/api/dashboard/ccn")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateHospital(string ccn, long reportingQuarter, HttpPostedFileBase file)
        {
            var visualization = await db.Visualizations.FindAsync(ccn);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ccn != hospitalDelivery.CCN)
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
                if (!HospitalDeliveryExists(ccn))
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

        // POST: api/Hospitals
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
                if (HospitalDeliveryExists(hospitalDelivery.CCN))
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

        // DELETE: api/Hospitals/5
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

        private bool HospitalDeliveryExists(string ccn)
        {
            return db.HospitalDeliveries.Count(e => e.CCN == ccn) > 0;
        }
    }
}
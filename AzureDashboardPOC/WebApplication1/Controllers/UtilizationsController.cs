using Swashbuckle.Swagger.Annotations;
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
    public class UtilizationsController : ApiController
    {
        private TestUtilization db = new TestUtilization();

        // GET: api/Utilizations
        public IQueryable<Utilization> GetUtilizations()
        {
            return db.Utilizations;
        }

        // GET: api/Utilizations/5
        [ResponseType(typeof(Utilization))]
        [SwaggerOperation("CreatePdf")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task<IHttpActionResult> GetUtilization(int id)
        {
            Utilization utilization = await db.Utilizations.FindAsync(id);
            if (utilization == null)
            {
                return NotFound();
            }

            return Ok(utilization);
        }

        // PUT: api/Utilizations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUtilization(int id, Utilization utilization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utilization.DeliveryID)
            {
                return BadRequest();
            }

            db.Entry(utilization).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizationExists(id))
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

        // POST: api/Utilizations
        [ResponseType(typeof(Utilization))]
        public async Task<IHttpActionResult> PostUtilization(Utilization utilization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Utilizations.Add(utilization);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UtilizationExists(utilization.DeliveryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = utilization.DeliveryID }, utilization);
        }

        // DELETE: api/Utilizations/5
        [ResponseType(typeof(Utilization))]
        public async Task<IHttpActionResult> DeleteUtilization(int id)
        {
            Utilization utilization = await db.Utilizations.FindAsync(id);
            if (utilization == null)
            {
                return NotFound();
            }

            db.Utilizations.Remove(utilization);
            await db.SaveChangesAsync();

            return Ok(utilization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UtilizationExists(int id)
        {
            return db.Utilizations.Count(e => e.DeliveryID == id) > 0;
        }
    }
}
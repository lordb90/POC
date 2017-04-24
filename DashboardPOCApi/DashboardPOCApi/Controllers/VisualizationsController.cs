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
using DashboardPOCApi.Models;

namespace DashboardPOCApi.Controllers
{
    public class VisualizationsController : ApiController
    {
        private DashboardContext db = new DashboardContext();

        // GET: api/Visualizations
        public IQueryable<Visualization> GetVisualizations()
        {
            return db.Visualizations;
        }

        // GET: api/Visualizations/5
        [ResponseType(typeof(Visualization))]
        public async Task<IHttpActionResult> GetVisualization(string id)
        {
            Visualization visualization = await db.Visualizations.FindAsync(id);
            if (visualization == null)
            {
                return NotFound();
            }

            return Ok(visualization);
        }

        // PUT: api/Visualizations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVisualization(string id, Visualization visualization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visualization.CCN)
            {
                return BadRequest();
            }

            db.Entry(visualization).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisualizationExists(id))
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

        // POST: api/Visualizations
        [ResponseType(typeof(Visualization))]
        public async Task<IHttpActionResult> PostVisualization(Visualization visualization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visualizations.Add(visualization);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VisualizationExists(visualization.CCN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = visualization.CCN }, visualization);
        }

        // DELETE: api/Visualizations/5
        [ResponseType(typeof(Visualization))]
        public async Task<IHttpActionResult> DeleteVisualization(string id)
        {
            Visualization visualization = await db.Visualizations.FindAsync(id);
            if (visualization == null)
            {
                return NotFound();
            }

            db.Visualizations.Remove(visualization);
            await db.SaveChangesAsync();

            return Ok(visualization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisualizationExists(string id)
        {
            return db.Visualizations.Count(e => e.CCN == id) > 0;
        }
    }
}
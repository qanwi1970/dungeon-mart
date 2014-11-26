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
using DungeonMart.Data.OldSql;

namespace DungeonMart.ApiControllers.v1
{
    [RoutePrefix("api/v1/equipment")]
    public class EquipmentController : ApiController
    {
        private SRDContext db = new SRDContext();

        [Route("")]
        // GET: api/Equipment
        public IQueryable<equipment> Getequipments()
        {
            return db.equipments;
        }

        [Route("{id}")]
        // GET: api/Equipment/5
        [ResponseType(typeof(equipment))]
        public async Task<IHttpActionResult> Getequipment(int id)
        {
            equipment equipment = await db.equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
        }

        [Route("{id}")]
        // PUT: api/Equipment/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putequipment(int id, equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipment.Id)
            {
                return BadRequest();
            }

            db.Entry(equipment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!equipmentExists(id))
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

        [Route("")]
        // POST: api/Equipment
        [ResponseType(typeof(equipment))]
        public async Task<IHttpActionResult> Postequipment(equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.equipments.Add(equipment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (equipmentExists(equipment.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = equipment.Id }, equipment);
        }

        [Route("{id}")]
        // DELETE: api/Equipment/5
        [ResponseType(typeof(equipment))]
        public async Task<IHttpActionResult> Deleteequipment(int id)
        {
            equipment equipment = await db.equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            db.equipments.Remove(equipment);
            await db.SaveChangesAsync();

            return Ok(equipment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool equipmentExists(int id)
        {
            return db.equipments.Count(e => e.Id == id) > 0;
        }
    }
}
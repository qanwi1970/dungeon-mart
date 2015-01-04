using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Data.OldSql;
using DungeonMart.Filters;

namespace DungeonMart.ApiControllers.v1
{
    /// <summary>
    /// Api for Equipment. Includes everything from a pound of wheat to a two handed sword.
    /// </summary>
    [Exception]
    [RoutePrefix("api/v1/equipment")]
    public class V1EquipmentController : ApiController
    {
        private SRDContext db = new SRDContext();

        /// <summary>
        /// Returns the entire equipment inventory
        /// </summary>
        /// <returns>array of equipment objects</returns>
        [Route("")]
        public IQueryable<equipment> Getequipments()
        {
            return db.equipments;
        }

        /// <summary>
        /// Get a single equipment object by Id.
        /// </summary>
        /// <param name="id">the Id of the equipment</param>
        /// <returns>a single equipment object</returns>
        /// <remarks>Gets a single equipment object</remarks>
        /// <response code="404">Equipment with that Id not found</response>
        [Route("{id}")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="equipment"></param>
        /// <returns></returns>
        [Route("{id}")]
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
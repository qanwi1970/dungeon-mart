using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Data.OldSql;

namespace DungeonMart.ApiControllers.v1
{
    [RoutePrefix("api/v1/power")]
    public class V1PowerController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/Power
        [Route("")]
        public IQueryable<power> Getpowers()
        {
            return db.powers;
        }

        // GET: api/Power/5
        [Route("{id}")]
        [ResponseType(typeof(power))]
        public async Task<IHttpActionResult> Getpower(int id)
        {
            power power = await db.powers.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }

            return Ok(power);
        }

        // PUT: api/Power/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpower(int id, power power)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != power.Id)
            {
                return BadRequest();
            }

            db.Entry(power).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!powerExists(id))
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

        // POST: api/Power
        [Route("")]
        [ResponseType(typeof(power))]
        public async Task<IHttpActionResult> Postpower(power power)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.powers.Add(power);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (powerExists(power.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = power.Id }, power);
        }

        // DELETE: api/Power/5
        [Route("{id}")]
        [ResponseType(typeof(power))]
        public async Task<IHttpActionResult> Deletepower(int id)
        {
            power power = await db.powers.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }

            db.powers.Remove(power);
            await db.SaveChangesAsync();

            return Ok(power);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool powerExists(int id)
        {
            return db.powers.Count(e => e.Id == id) > 0;
        }
    }
}
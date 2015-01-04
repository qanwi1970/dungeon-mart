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
    [RoutePrefix("api/v1/class")]
    public class V1ClassController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/ClassTable
        [Route("")]
        public IQueryable<@class> Getclass()
        {
            return db.classes;
        }

        // GET: api/ClassTable/5
        [Route("{id}")]
        [ResponseType(typeof(@class))]
        public async Task<IHttpActionResult> Getclass(int id)
        {
            @class characterClass = await db.classes.FindAsync(id);
            if (characterClass == null)
            {
                return NotFound();
            }

            return Ok(characterClass);
        }

        // PUT: api/ClassTable/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putclass(int id, @class characterClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characterClass.Id)
            {
                return BadRequest();
            }

            db.Entry(characterClass).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!classExists(id))
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

        // POST: api/ClassTable
        [Route("")]
        [ResponseType(typeof(@class))]
        public async Task<IHttpActionResult> Postclass(@class characterClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.classes.Add(characterClass);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (classExists(characterClass.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("api/v1/class/{id}", new { id = characterClass.Id }, characterClass);
        }

        // DELETE: api/ClassTable/5
        [Route("{id}")]
        [ResponseType(typeof(@class))]
        public async Task<IHttpActionResult> Deleteclass(int id)
        {
            @class characterClass = await db.classes.FindAsync(id);
            if (characterClass == null)
            {
                return NotFound();
            }

            db.classes.Remove(characterClass);
            await db.SaveChangesAsync();

            return Ok(characterClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool classExists(int id)
        {
            return db.classes.Count(e => e.Id == id) > 0;
        }
    }
}
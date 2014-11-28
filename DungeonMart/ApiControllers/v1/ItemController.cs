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
    [RoutePrefix("api/v1/item")]
    public class ItemController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/Item
        [Route("")]
        public IQueryable<item> Getitems()
        {
            return db.items;
        }

        // GET: api/Item/5
        [Route("{id}")]
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Getitem(int id)
        {
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Item/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putitem(int id, item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemExists(id))
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

        // POST: api/Item
        [Route("")]
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Postitem(item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.items.Add(item);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (itemExists(item.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        // DELETE: api/Item/5
        [Route("{id}")]
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Deleteitem(int id)
        {
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            db.items.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool itemExists(int id)
        {
            return db.items.Count(e => e.Id == id) > 0;
        }
    }
}
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
    [RoutePrefix("api/v1/classTable")]
    public class V1ClassTableController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/ClassTable
        [Route("")]
        public IQueryable<class_table> Getclass_table()
        {
            return db.class_table;
        }

        // GET: api/ClassTable/5
        [Route("{id}")]
        [ResponseType(typeof(class_table))]
        public async Task<IHttpActionResult> Getclass_table(int id)
        {
            class_table class_table = await db.class_table.FindAsync(id);
            if (class_table == null)
            {
                return NotFound();
            }

            return Ok(class_table);
        }

        // PUT: api/ClassTable/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putclass_table(int id, class_table class_table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != class_table.Id)
            {
                return BadRequest();
            }

            db.Entry(class_table).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!class_tableExists(id))
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
        [ResponseType(typeof(class_table))]
        public async Task<IHttpActionResult> Postclass_table(class_table class_table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.class_table.Add(class_table);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (class_tableExists(class_table.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = class_table.Id }, class_table);
        }

        // DELETE: api/ClassTable/5
        [Route("{id}")]
        [ResponseType(typeof(class_table))]
        public async Task<IHttpActionResult> Deleteclass_table(int id)
        {
            class_table class_table = await db.class_table.FindAsync(id);
            if (class_table == null)
            {
                return NotFound();
            }

            db.class_table.Remove(class_table);
            await db.SaveChangesAsync();

            return Ok(class_table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool class_tableExists(int id)
        {
            return db.class_table.Count(e => e.Id == id) > 0;
        }
    }
}
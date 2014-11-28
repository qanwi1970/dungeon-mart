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
    [RoutePrefix("api/v1/monster")]
    public class MonsterController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/Monster
        [Route("")]
        public IQueryable<monster> Getmonsters()
        {
            return db.monsters;
        }

        // GET: api/Monster/5
        [Route("{id}")]
        [ResponseType(typeof(monster))]
        public async Task<IHttpActionResult> Getmonster(int id)
        {
            monster monster = await db.monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            return Ok(monster);
        }

        // PUT: api/Monster/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmonster(int id, monster monster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monster.Id)
            {
                return BadRequest();
            }

            db.Entry(monster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!monsterExists(id))
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

        // POST: api/Monster
        [Route("")]
        [ResponseType(typeof(monster))]
        public async Task<IHttpActionResult> Postmonster(monster monster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.monsters.Add(monster);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (monsterExists(monster.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = monster.Id }, monster);
        }

        // DELETE: api/Monster/5
        [Route("{id}")]
        [ResponseType(typeof(monster))]
        public async Task<IHttpActionResult> Deletemonster(int id)
        {
            monster monster = await db.monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            db.monsters.Remove(monster);
            await db.SaveChangesAsync();

            return Ok(monster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool monsterExists(int id)
        {
            return db.monsters.Count(e => e.Id == id) > 0;
        }
    }
}
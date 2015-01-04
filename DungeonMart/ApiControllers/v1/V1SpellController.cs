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
    [RoutePrefix("api/v1/spell")]
    public class V1SpellController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/Spell
        [Route("")]
        public IQueryable<spell> Getspells()
        {
            return db.spells;
        }

        // GET: api/Spell/5
        [Route("{id}")]
        [ResponseType(typeof(spell))]
        public async Task<IHttpActionResult> Getspell(int id)
        {
            spell spell = await db.spells.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }

            return Ok(spell);
        }

        // PUT: api/Spell/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putspell(int id, spell spell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spell.Id)
            {
                return BadRequest();
            }

            db.Entry(spell).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!spellExists(id))
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

        // POST: api/Spell
        [Route("")]
        [ResponseType(typeof(spell))]
        public async Task<IHttpActionResult> Postspell(spell spell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.spells.Add(spell);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (spellExists(spell.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spell.Id }, spell);
        }

        // DELETE: api/Spell/5
        [Route("{id}")]
        [ResponseType(typeof(spell))]
        public async Task<IHttpActionResult> Deletespell(int id)
        {
            spell spell = await db.spells.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }

            db.spells.Remove(spell);
            await db.SaveChangesAsync();

            return Ok(spell);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool spellExists(int id)
        {
            return db.spells.Count(e => e.Id == id) > 0;
        }
    }
}
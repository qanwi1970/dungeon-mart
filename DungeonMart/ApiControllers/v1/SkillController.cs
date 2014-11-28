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
    [RoutePrefix("api/v1/skill")]
    public class SkillController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/Skill
        [Route("")]
        public IQueryable<skill> Getskills()
        {
            return db.skills;
        }

        // GET: api/Skill/5
        [Route("{id}")]
        [ResponseType(typeof(skill))]
        public async Task<IHttpActionResult> Getskill(int id)
        {
            skill skill = await db.skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        // PUT: api/Skill/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putskill(int id, skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skill.Id)
            {
                return BadRequest();
            }

            db.Entry(skill).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!skillExists(id))
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

        // POST: api/Skill
        [Route("")]
        [ResponseType(typeof(skill))]
        public async Task<IHttpActionResult> Postskill(skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.skills.Add(skill);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (skillExists(skill.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skill/5
        [Route("{id}")]
        [ResponseType(typeof(skill))]
        public async Task<IHttpActionResult> Deleteskill(int id)
        {
            skill skill = await db.skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            db.skills.Remove(skill);
            await db.SaveChangesAsync();

            return Ok(skill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool skillExists(int id)
        {
            return db.skills.Count(e => e.Id == id) > 0;
        }
    }
}
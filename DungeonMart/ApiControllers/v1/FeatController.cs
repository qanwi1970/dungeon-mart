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
    [RoutePrefix("api/v1/feat")]
    public class FeatController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/Feat
        [Route("")]
        public IQueryable<feat> Getfeats()
        {
            return db.feats;
        }

        // GET: api/Feat/5
        [Route("{id}")]
        [ResponseType(typeof(feat))]
        public async Task<IHttpActionResult> Getfeat(int id)
        {
            feat feat = await db.feats.FindAsync(id);
            if (feat == null)
            {
                return NotFound();
            }

            return Ok(feat);
        }

        // PUT: api/Feat/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putfeat(int id, feat feat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feat.Id)
            {
                return BadRequest();
            }

            db.Entry(feat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!featExists(id))
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

        // POST: api/Feat
        [Route("")]
        [ResponseType(typeof(feat))]
        public async Task<IHttpActionResult> Postfeat(feat feat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.feats.Add(feat);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (featExists(feat.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = feat.Id }, feat);
        }

        // DELETE: api/Feat/5
        [Route("{id}")]
        [ResponseType(typeof(feat))]
        public async Task<IHttpActionResult> Deletefeat(int id)
        {
            feat feat = await db.feats.FindAsync(id);
            if (feat == null)
            {
                return NotFound();
            }

            db.feats.Remove(feat);
            await db.SaveChangesAsync();

            return Ok(feat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool featExists(int id)
        {
            return db.feats.Count(e => e.Id == id) > 0;
        }
    }
}
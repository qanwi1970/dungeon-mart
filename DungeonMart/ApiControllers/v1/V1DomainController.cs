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
    [RoutePrefix("api/v1/domain")]
    public class V1DomainController : ApiController
    {
        private SRDContext db = new SRDContext();

        // GET: api/Domain
        [Route("")]
        public IQueryable<domain> Getdomains()
        {
            return db.domains;
        }

        // GET: api/Domain/5
        [Route("{id}")]
        [ResponseType(typeof(domain))]
        public async Task<IHttpActionResult> Getdomain(int id)
        {
            domain domain = await db.domains.FindAsync(id);
            if (domain == null)
            {
                return NotFound();
            }

            return Ok(domain);
        }

        // PUT: api/Domain/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdomain(int id, domain domain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != domain.Id)
            {
                return BadRequest();
            }

            db.Entry(domain).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!domainExists(id))
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

        // POST: api/Domain
        [Route("")]
        [ResponseType(typeof(domain))]
        public async Task<IHttpActionResult> Postdomain(domain domain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.domains.Add(domain);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (domainExists(domain.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = domain.Id }, domain);
        }

        // DELETE: api/Domain/5
        [Route("{id}")]
        [ResponseType(typeof(domain))]
        public async Task<IHttpActionResult> Deletedomain(int id)
        {
            domain domain = await db.domains.FindAsync(id);
            if (domain == null)
            {
                return NotFound();
            }

            db.domains.Remove(domain);
            await db.SaveChangesAsync();

            return Ok(domain);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool domainExists(int id)
        {
            return db.domains.Count(e => e.Id == id) > 0;
        }
    }
}
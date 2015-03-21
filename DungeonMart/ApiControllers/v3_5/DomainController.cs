using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Repositories;
using DungeonMart.Models;
using DungeonMart.Services;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.ApiControllers.v3_5
{
    /// <summary>
    /// Endpoint for cleric domains
    /// </summary>
    [RoutePrefix("api/v3.5/domain")]
    public class DomainController : ApiController
    {
        private readonly IDomainService _domainService;

        public DomainController() : this(new DomainService(new DomainRepository(new DungeonMartContext())))
        {
        }

        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        /// <summary>
        /// Get a list of all the domains
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(DomainViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var domains = await Task.Run(() => _domainService.GetDomains());
            return Ok(domains);
        }

        /// <summary>
        /// Gets a single domain by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetDomainById")]
        [ResponseType(typeof(DomainViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var domain = await Task.Run(() => _domainService.GetDomainById(id));
            return Ok(domain);
        }

        /// <summary>
        /// Add a domain
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(DomainViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]DomainViewModel domain)
        {
            var addedDomain = await Task.Run(() => _domainService.AddDomain(domain));
            return CreatedAtRoute("GetDomainById", new {id = addedDomain.Id}, addedDomain);
        }

        /// <summary>
        /// Update a domain
        /// </summary>
        /// <param name="id"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(DomainViewModel))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]DomainViewModel domain)
        {
            var updatedDomain = await Task.Run(() => _domainService.UpdateDomain(id, domain));
            return Ok(updatedDomain);
        }

        /// <summary>
        /// Delete a domain
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _domainService.DeleteDomain(id));
            return Ok();
        }

        /// <summary>
        /// Re-seeds the base SRD domain data
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _domainService.SeedDomain(seedDataPath));
            return Ok();
        }

    }
}

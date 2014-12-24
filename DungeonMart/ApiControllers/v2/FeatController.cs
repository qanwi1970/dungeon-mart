using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DungeonMart.Data.Interfaces;
using DungeonMart.Service.Interfaces;
using DungeonMart.Shared.Models;

namespace DungeonMart.ApiControllers.v2
{
    [RoutePrefix("api/v2/feat")]
    public class FeatController : ApiController
    {
        private readonly IFeatService _featService;

        public FeatController(IFeatService featService)
        {
            _featService = featService;
        }

        [Route("")]
        // GET: api/v2/Feat
        public IQueryable<Feat> Get()
        {
            return _featService.GetFeats();
        }

        [Route("{id}")]
        // GET: api/v2/Feat/5
        public async Task<IHttpActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        [Route("")]
        // POST: api/Feat
        public async Task<IHttpActionResult> Post([FromBody]Feat value)
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        // PUT: api/Feat/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Feat value)
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        // DELETE: api/Feat/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

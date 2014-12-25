using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Repositories;
using DungeonMart.Service.Interfaces;
using DungeonMart.Shared.Models;

namespace DungeonMart.ApiControllers.v2
{
    /// <summary>
    /// REST service for Feats
    /// </summary>
    [RoutePrefix("api/v2/feat")]
    public class FeatController : ApiController
    {
        private readonly IFeatService _featService;

        /// <summary>
        /// Ok, it's a constructor
        /// </summary>
        /// <param name="featService">An implementation of IFeatService</param>
        public FeatController(IFeatService featService)
        {
            _featService = featService;
        }

        /// <summary>
        /// Gets the complete list of feats
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(Feat))]
        // GET: api/v2/Feat
        public IQueryable<Feat> Get()
        {
            return _featService.GetFeats();
        }

        /// <summary>
        /// Get a single feat by id
        /// </summary>
        /// <param name="id">the id of the feat</param>
        /// <returns>a single feat object</returns>
        [Route("{id}", Name = "FeatGet")]
        [ResponseType(typeof(Feat))]
        // GET: api/v2/Feat/5
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(_featService.GetFeatById(id));
        }

        /// <summary>
        /// Add a new feat to the database
        /// </summary>
        /// <param name="value">the feat to add</param>
        /// <returns></returns>
        [Route("", Name = "FeatPost")]
        [ResponseType(typeof(Feat))]
        // POST: api/Feat
        public async Task<IHttpActionResult> Post([FromBody]Feat value)
        {
            var postedFeat = _featService.AddFeat(value);
            return CreatedAtRoute("FeatGet", new {id = postedFeat.Id}, postedFeat);
        }

        /// <summary>
        /// Update a feat in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(Feat))]
        // PUT: api/Feat/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Feat value)
        {
            var updatedFeat = _featService.PutFeat(id, value);
            return Ok(updatedFeat);
        }

        /// <summary>
        /// Deletes a feat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        // DELETE: api/Feat/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            _featService.DeleteFeat(id);
            return Ok();
        }
    }
}

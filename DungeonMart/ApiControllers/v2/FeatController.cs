using System.Web;
using DungeonMart.Services.Interfaces;
using DungeonMart.Shared.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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
        public async Task<IHttpActionResult> Get()
        {
            var featList = await Task.Run(() => _featService.GetFeats());
            return Ok(featList);
        }

        /// <summary>
        /// Get a single feat by id
        /// </summary>
        /// <param name="id">the id of the feat</param>
        /// <returns>a single feat object</returns>
        [Route("{id}", Name = "FeatGet")]
        [ResponseType(typeof(Feat))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var feat = await Task.Run(() => _featService.GetFeatById(id));
            return Ok(feat);
        }

        /// <summary>
        /// Add a new feat to the database
        /// </summary>
        /// <param name="value">the feat to add</param>
        /// <returns></returns>
        [Route("", Name = "FeatPost")]
        [ResponseType(typeof(Feat))]
        public async Task<IHttpActionResult> Post([FromBody]Feat value)
        {
            var postedFeat = await Task.Run(() => _featService.AddFeat(value));
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
        public async Task<IHttpActionResult> Put(int id, [FromBody]Feat value)
        {
            var updatedFeat = await Task.Run(() => _featService.PutFeat(id, value));
            return Ok(updatedFeat);
        }

        /// <summary>
        /// Deletes a feat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _featService.DeleteFeat(id));
            return Ok();
        }

        /// <summary>
        /// Re-seeds the base SRD feat data
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _featService.SeedFeat(seedDataPath));
            return Ok();
        }
    }
}

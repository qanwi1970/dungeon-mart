using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.ApiControllers.v2
{
    /// <summary>
    /// REST service for Powers
    /// </summary>
    [RoutePrefix("api/v2/power")]
    public class PowerController : ApiController
    {
        private readonly IPowerService _powerService;

        public PowerController(IPowerService powerService)
        {
            _powerService = powerService;
        }

        /// <summary>
        /// Gets a list of powers
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(Power))]
        public async Task<IHttpActionResult> Get()
        {
            var powerList = await Task.Run(() => _powerService.GetPowers());
            return Ok(powerList);
        }

        /// <summary>
        /// Gets a single power by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetPowerById")]
        [ResponseType(typeof(Power))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var power = await Task.Run(() => _powerService.GetPowerById(id));
            return Ok(power);
        }

        /// <summary>
        /// Adds a power
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(Power))]
        public async Task<IHttpActionResult> Post([FromBody]Power power)
        {
            var newPower = await Task.Run(() => _powerService.AddPower(power));
            return CreatedAtRoute("GetPowerById", new {id = newPower.Id}, newPower);
        }

        /// <summary>
        /// Updates a power
        /// </summary>
        /// <param name="id"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(Power))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]Power power)
        {
            var updatedPower = await Task.Run(() => _powerService.UdpatePower(id, power));
            return Ok(updatedPower);
        }

        /// <summary>
        /// Deletes a power
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _powerService.DeletePower(id));
            return Ok();
        }

        /// <summary>
        /// Re-seeds the Power table from the json file
        /// </summary>
        /// <returns></returns>
        [Route("0/Seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _powerService.SeedPowers(seedDataPath));
            return Ok();
        }
    }
}

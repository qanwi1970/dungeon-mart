using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.ApiControllers.v2
{
    /// <summary>
    /// REST service endpoint for Equipment
    /// </summary>
    [RoutePrefix("api/v2/equipment")]
    public class EquipmentController : ApiController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        /// <summary>
        /// Get a list of equipment
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(EquipmentViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var equipmentList = await Task.Run(() => _equipmentService.GetEquipments());
            return Ok(equipmentList);
        }

        /// <summary>
        /// Gets a single equipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetEquipmentById")]
        [ResponseType(typeof(EquipmentViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var equipment = await Task.Run(() => _equipmentService.GetEquipmentById(id));
            return Ok(equipment);
        }

        /// <summary>
        /// Add equipment
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(EquipmentViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]EquipmentViewModel equipment)
        {
            var addedEquipment = await Task.Run(() => _equipmentService.AddEquipment(equipment));
            return CreatedAtRoute("GetEquipmentById", new {id = addedEquipment.Id}, addedEquipment);
        }

        /// <summary>
        /// Update equipment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="equipment"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(EquipmentViewModel))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]EquipmentViewModel equipment)
        {
            var updatedEquipment = await Task.Run(() => _equipmentService.UpdateEquipment(id, equipment));
            return Ok(updatedEquipment);
        }

        /// <summary>
        /// Delete equipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _equipmentService.DeleteEquipment(id));
            return Ok();
        }

        /// <summary>
        /// Re-seeds the base SRD equipment data
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _equipmentService.SeedEquipment(seedDataPath));
            return Ok();
        }
    }
}

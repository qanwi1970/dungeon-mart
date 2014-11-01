using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DungeonMart.Data.DocumentDB;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Controllers
{
    
    public class EquipmentController : ApiController
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController()
        {
            _equipmentRepository = new EquipmentDocDbRepository();
        }

        // GET: api/Equipment
        public async Task<HttpResponseMessage> Get()
        {
            var result = Request.CreateResponse(HttpStatusCode.OK, _equipmentRepository.GetEquipments());
            return await Task.FromResult(result);
        }

        // GET: api/Equipment/5
        public async Task<HttpResponseMessage> Get(string id)
        {
            var result = Request.CreateResponse(HttpStatusCode.OK, _equipmentRepository.GetEquipmentById(id));
            return await Task.FromResult(result);
        }

        // POST: api/Equipment
        public async Task<HttpResponseMessage> Post([FromBody]Equipment value)
        {
            var newEquipment = await _equipmentRepository.AddEquipment(value);
            return Request.CreateResponse(HttpStatusCode.Created, newEquipment);
        }

        // PUT: api/Equipment/5
        public async Task<HttpResponseMessage> Put(string id, [FromBody]Equipment value)
        {
            var updatedEquipment = await _equipmentRepository.UpdateEquipment(id, value);
            return Request.CreateResponse(HttpStatusCode.OK, updatedEquipment);
        }

        // DELETE: api/Equipment/5
        public async Task<HttpResponseMessage> Delete(string id)
        {
            await _equipmentRepository.DeleteEquipment(id);
            return Request.CreateResponse();
        }
    }
}

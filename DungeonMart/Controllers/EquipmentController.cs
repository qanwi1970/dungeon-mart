using System.Collections.Generic;
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
        public IEnumerable<Equipment> Get()
        {
            return _equipmentRepository.GetEquipments();
        }

        // GET: api/Equipment/5
        public Equipment Get(string id)
        {
            return _equipmentRepository.GetEquipmentById(id);
        }

        // POST: api/Equipment
        public async Task<Equipment> Post([FromBody]Equipment value)
        {
            return await _equipmentRepository.AddEquipment(value);
        }

        // PUT: api/Equipment/5
        public async Task<Equipment> Put(string id, [FromBody]Equipment value)
        {
            return await _equipmentRepository.UpdateEquipment(id, value);
        }

        // DELETE: api/Equipment/5
        public async void Delete(string id)
        {
            await _equipmentRepository.DeleteEquipment(id);
        }
    }
}

using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public IQueryable<Equipment> GetEquipments()
        {
            return _equipmentRepository.GetAll().Select(EquipmentMapper.MapEntityToModel).AsQueryable();
        }

        public Equipment GetEquipmentById(int id)
        {
            return EquipmentMapper.MapEntityToModel(_equipmentRepository.GetById(id));
        }

        public Equipment AddEquipment(Equipment equipment)
        {
            var equipmentToAdd = EquipmentMapper.MapModelToEntity(equipment);
            equipmentToAdd.CreatedBy = "TEST";
            var addedEquipment = _equipmentRepository.Add(equipmentToAdd);
            return EquipmentMapper.MapEntityToModel(addedEquipment);
        }

        public Equipment UpdateEquipment(int id, Equipment equipment)
        {
            var equipmentToUpdate = EquipmentMapper.MapModelToEntity(equipment);
            var originalEquipment = _equipmentRepository.GetById(id);
            equipmentToUpdate.CreatedBy = originalEquipment.CreatedBy;
            equipmentToUpdate.CreatedDate = originalEquipment.CreatedDate;
            equipmentToUpdate.ModifiedBy = "TEST";
            var updatedEquipment = _equipmentRepository.Update(equipmentToUpdate);
            return EquipmentMapper.MapEntityToModel(updatedEquipment);
        }

        public void DeleteEquipment(int id)
        {
            _equipmentRepository.Delete(id);
        }
    }
}
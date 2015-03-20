﻿using System.IO;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public IQueryable<EquipmentViewModel> GetEquipments()
        {
            return _equipmentRepository.GetAll().Select(EquipmentMapper.MapEntityToModel).AsQueryable();
        }

        public EquipmentViewModel GetEquipmentById(int id)
        {
            return EquipmentMapper.MapEntityToModel(_equipmentRepository.GetById(id));
        }

        public EquipmentViewModel AddEquipment(EquipmentViewModel equipment)
        {
            var equipmentToAdd = EquipmentMapper.MapModelToEntity(equipment);
            equipmentToAdd.CreatedBy = "TEST";
            equipmentToAdd.SeedData = false;
            var addedEquipment = _equipmentRepository.Add(equipmentToAdd);
            return EquipmentMapper.MapEntityToModel(addedEquipment);
        }

        public EquipmentViewModel UpdateEquipment(int id, EquipmentViewModel equipment)
        {
            var originalEquipment = _equipmentRepository.GetById(id);
            EquipmentMapper.MapModelToEntity(equipment, originalEquipment);
            originalEquipment.ModifiedBy = "TEST";
            var updatedEquipment = _equipmentRepository.Update(originalEquipment);
            return EquipmentMapper.MapEntityToModel(updatedEquipment);
        }

        public void DeleteEquipment(int id)
        {
            _equipmentRepository.Delete(id);
        }

        public void SeedEquipment(string seedPath)
        {
            EquipmentSeed[] equipmentArray;
            using (var equipmentStream = new StreamReader(seedPath + "/equipment.json"))
            {
                equipmentArray = JsonConvert.DeserializeObject<EquipmentSeed[]>(equipmentStream.ReadToEnd());
            }
            foreach (var equipmentSeed in equipmentArray)
            {
                var equipmentEntity = _equipmentRepository.GetById(equipmentSeed.Id);
                if (equipmentEntity == null)
                {
                    var newEquipment = EquipmentMapper.MapSeedToEntity(equipmentSeed);
                    newEquipment.CreatedBy = "SeedEquipment";
                    newEquipment.SeedData = true;
                    _equipmentRepository.Add(newEquipment);
                }
                else
                {
                    EquipmentMapper.MapSeedToEntity(equipmentSeed, equipmentEntity);
                    equipmentEntity.ModifiedBy = "SeedEquipment";
                    _equipmentRepository.Update(equipmentEntity);
                }
            }
        }
    }
}
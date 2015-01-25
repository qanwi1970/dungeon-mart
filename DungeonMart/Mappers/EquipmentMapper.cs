using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class EquipmentMapper
    {
        static EquipmentMapper()
        {
            Mapper.CreateMap<Equipment, EquipmentEntity>();
            Mapper.CreateMap<EquipmentEntity, Equipment>();
        }

        public static Equipment MapEntityToModel(EquipmentEntity equipmentEntity)
        {
            return Mapper.Map<Equipment>(equipmentEntity);
        }

        public static EquipmentEntity MapModelToEntity(Equipment equipment)
        {
            return Mapper.Map<EquipmentEntity>(equipment);
        }
    }
}
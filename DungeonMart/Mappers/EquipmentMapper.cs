using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
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

        public static void MapModelToEntity(Equipment equipment, EquipmentEntity equipmentEntity)
        {
            Mapper.Map(equipment, equipmentEntity);
        }

        public static EquipmentEntity MapSeedToEntity(EquipmentSeed equipmentSeed)
        {
            var entity = new EquipmentEntity();
            MapSeedToEntity(equipmentSeed, entity);
            return entity;
        }

        public static void MapSeedToEntity(EquipmentSeed equipmentSeed, EquipmentEntity equipmentEntity)
        {
            equipmentEntity.ArcaneSpellFailureChance = equipmentSeed.arcane_spell_failure_chance;
            equipmentEntity.ArmorCheckPenalty = equipmentSeed.armor_check_penalty;
            equipmentEntity.ArmorShieldBonus = equipmentSeed.armor_shield_bonus;
            equipmentEntity.Category = equipmentSeed.category;
            equipmentEntity.Cost = equipmentSeed.cost;
            equipmentEntity.Critical = equipmentSeed.critical;
            equipmentEntity.DamageMedium = equipmentSeed.dmg_m;
            equipmentEntity.DamageSmall = equipmentSeed.dmg_s;
            equipmentEntity.Family = equipmentSeed.family;
            equipmentEntity.FullText = equipmentSeed.full_text;
            equipmentEntity.Id = equipmentSeed.Id;
            equipmentEntity.MaximumDexBonus = equipmentSeed.maximum_dex_bonus;
            equipmentEntity.Name = equipmentSeed.name;
            equipmentEntity.RangeIncrement = equipmentSeed.range_increment;
            equipmentEntity.Reference = equipmentSeed.reference;
            equipmentEntity.Speed20 = equipmentSeed.speed_20;
            equipmentEntity.Speed30 = equipmentSeed.speed_30;
            equipmentEntity.Subcategory = equipmentSeed.subcategory;
            equipmentEntity.WeaponType = equipmentSeed.type;
            equipmentEntity.Weight = equipmentSeed.weight;
        }
    }
}
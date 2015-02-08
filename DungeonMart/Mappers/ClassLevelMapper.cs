using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class ClassLevelMapper
    {
        static ClassLevelMapper()
        {
            Mapper.CreateMap<ClassLevel, ClassProgressionEntity>();
            Mapper.CreateMap<ClassProgressionEntity, ClassLevel>();
        }

        public static ClassLevel MapEntityToModel(ClassProgressionEntity classProgressionEntity)
        {
            return Mapper.Map<ClassLevel>(classProgressionEntity);
        }

        public static ClassProgressionEntity MapModelToEntity(ClassLevel classLevel)
        {
            return Mapper.Map<ClassProgressionEntity>(classLevel);
        }

        public static void MapModelToEntity(ClassLevel classLevel, ClassProgressionEntity classProgressionEntity)
        {
            Mapper.Map(classLevel, classProgressionEntity);
        }

        public static ClassProgressionEntity MapSeedToEntity(ClassLevelSeed classLevelSeed)
        {
            var classProgressionEntity = new ClassProgressionEntity();
            MapSeedToEntity(classLevelSeed, classProgressionEntity);
            return classProgressionEntity;
        }

        public static void MapSeedToEntity(ClassLevelSeed classLevelSeed, ClassProgressionEntity classProgressionEntity)
        {
            classProgressionEntity.ArmorClassBonus = classLevelSeed.ac_bonus;
            classProgressionEntity.BaseAttackBonus = classLevelSeed.base_attack_bonus;
            classProgressionEntity.BonusSpells = classLevelSeed.bonus_spells;
            classProgressionEntity.CasterLevel = classLevelSeed.caster_level;
            classProgressionEntity.ClassName = classLevelSeed.name;
            classProgressionEntity.FlurryOfBlows = classLevelSeed.flurry_of_blows;
            classProgressionEntity.FortitudeSave = classLevelSeed.fort_save;
            classProgressionEntity.Id = classLevelSeed.Id;
            classProgressionEntity.Level = classLevelSeed.level;
            classProgressionEntity.PointsPerDay = classLevelSeed.points_per_day;
            classProgressionEntity.PowerLevel = classLevelSeed.power_level;
            classProgressionEntity.PowersKnown = classLevelSeed.powers_known;
            classProgressionEntity.Reference = classLevelSeed.reference;
            classProgressionEntity.ReflexSave = classLevelSeed.ref_save;
            classProgressionEntity.Slots0 = classLevelSeed.slots_0;
            classProgressionEntity.Slots1 = classLevelSeed.slots_1;
            classProgressionEntity.Slots2 = classLevelSeed.slots_2;
            classProgressionEntity.Slots3 = classLevelSeed.slots_3;
            classProgressionEntity.Slots4 = classLevelSeed.slots_4;
            classProgressionEntity.Slots5 = classLevelSeed.slots_5;
            classProgressionEntity.Slots6 = classLevelSeed.slots_6;
            classProgressionEntity.Slots7 = classLevelSeed.slots_7;
            classProgressionEntity.Slots8 = classLevelSeed.slots_8;
            classProgressionEntity.Slots9 = classLevelSeed.slots_9;
            classProgressionEntity.Special = classLevelSeed.special;
            classProgressionEntity.SpellsKnown0 = classLevelSeed.spells_known_0;
            classProgressionEntity.SpellsKnown1 = classLevelSeed.spells_known_1;
            classProgressionEntity.SpellsKnown2 = classLevelSeed.spells_known_2;
            classProgressionEntity.SpellsKnown3 = classLevelSeed.spells_known_3;
            classProgressionEntity.SpellsKnown4 = classLevelSeed.spells_known_4;
            classProgressionEntity.SpellsKnown5 = classLevelSeed.spells_known_5;
            classProgressionEntity.SpellsKnown6 = classLevelSeed.spells_known_6;
            classProgressionEntity.SpellsKnown7 = classLevelSeed.spells_known_7;
            classProgressionEntity.SpellsKnown8 = classLevelSeed.spells_known_8;
            classProgressionEntity.SpellsKnown9 = classLevelSeed.spells_known_9;
            classProgressionEntity.UnarmedDamage = classLevelSeed.unarmed_damage;
            classProgressionEntity.UnarmoredSpeedBonus = classLevelSeed.unarmored_speed_bonus;
            classProgressionEntity.WillSave = classLevelSeed.will_save;
        }
    }
}
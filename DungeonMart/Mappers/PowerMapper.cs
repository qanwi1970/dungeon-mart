using System.Web;
using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class PowerMapper
    {
        static PowerMapper()
        {
            Mapper.CreateMap<Power, PowerEntity>();
            Mapper.CreateMap<PowerEntity, Power>();
        }

        public static Power MapEntityToModel(PowerEntity powerEntity)
        {
            return Mapper.Map<Power>(powerEntity);
        }

        public static PowerEntity MapModelToEntity(Power power)
        {
            return Mapper.Map<PowerEntity>(power);
        }

        public static void MapModelToEntity(Power power, PowerEntity powerEntity)
        {
            Mapper.Map(power, powerEntity);
        }

        public static PowerEntity MapSeedToEntity(PowerSeed powerSeed)
        {
            var newPower = new PowerEntity();
            MapSeedToEntity(powerSeed, newPower);
            return newPower;
        }

        public static void MapSeedToEntity(PowerSeed powerSeed, PowerEntity powerEntity)
        {
            powerEntity.Area = powerSeed.area;
            powerEntity.Augment = HttpUtility.HtmlDecode(powerSeed.augment);
            powerEntity.Description = HttpUtility.HtmlDecode(powerSeed.description);
            powerEntity.Descriptor = powerSeed.descriptor;
            powerEntity.Discipline = powerSeed.discipline;
            powerEntity.Display = powerSeed.display;
            powerEntity.Duration = powerSeed.duration;
            powerEntity.Effect = powerSeed.effect;
            powerEntity.FullText = HttpUtility.HtmlDecode(powerSeed.full_text);
            powerEntity.Id = powerSeed.Id;
            powerEntity.Level = powerSeed.level;
            powerEntity.ManifestingTime = powerSeed.manifesting_time;
            powerEntity.Name = powerSeed.name;
            powerEntity.PowerPoints = powerSeed.power_points;
            powerEntity.PowerResistance = powerSeed.power_resistance;
            powerEntity.Range = powerSeed.range;
            powerEntity.Reference = powerSeed.reference;
            powerEntity.SavingThrow = powerSeed.saving_throw;
            powerEntity.ShortDescription = powerSeed.short_description;
            powerEntity.Subdiscipline = powerSeed.subdiscipline;
            powerEntity.Target = powerSeed.target;
            powerEntity.XPCost = powerSeed.xp_cost;
        }
    }
}
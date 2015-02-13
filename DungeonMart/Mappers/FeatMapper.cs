using System.Web;
using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Shared.Models;

namespace DungeonMart.Mappers
{
    public class FeatMapper
    {

        static FeatMapper()
        {
            Mapper.CreateMap<Feat, FeatEntity>();
            Mapper.CreateMap<FeatEntity, Feat>();
        }

        public static Feat MapEntityToModel(FeatEntity featEntity)
        {
            return Mapper.Map<Feat>(featEntity);
        }

        public static FeatEntity MapModelToEntity(Feat feat)
        {
            return Mapper.Map<FeatEntity>(feat);
        }

        public static void MapModelToEntity(Feat feat, FeatEntity featEntity)
        {
            Mapper.Map(feat, featEntity);
        }

        public static FeatEntity MapSeedToEntity(FeatSeed featSeed)
        {
            var featEntity = new FeatEntity();
            MapSeedToEntity(featSeed, featEntity);
            return featEntity;
        }

        public static void MapSeedToEntity(FeatSeed featSeed, FeatEntity featEntity)
        {
            featEntity.Benefit = HttpUtility.HtmlDecode(featSeed.benefit);
            featEntity.Choice = featSeed.choice;
            featEntity.FeatType = featSeed.type;
            featEntity.FullText = HttpUtility.HtmlDecode(featSeed.full_text);
            featEntity.Multiple = featSeed.multiple;
            featEntity.Name = featSeed.name;
            featEntity.Normal = featSeed.normal;
            featEntity.Prerequisite = featSeed.prerequisite;
            featEntity.Reference = featSeed.reference;
            featEntity.Special = featSeed.special;
            featEntity.Stack = featSeed.stack;
        }
    }
}

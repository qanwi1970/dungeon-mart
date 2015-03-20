using System.Web;
using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class FeatMapper
    {

        static FeatMapper()
        {
            Mapper.CreateMap<Feat, FeatViewModel>();
            Mapper.CreateMap<FeatViewModel, Feat>();
        }

        public static FeatViewModel MapEntityToModel(Feat featEntity)
        {
            return Mapper.Map<FeatViewModel>(featEntity);
        }

        public static Feat MapModelToEntity(FeatViewModel featViewModel)
        {
            return Mapper.Map<Feat>(featViewModel);
        }

        public static void MapModelToEntity(FeatViewModel feat, Feat featEntity)
        {
            Mapper.Map(feat, featEntity);
        }

        public static Feat MapSeedToEntity(FeatSeed featSeed)
        {
            var featEntity = new Feat();
            MapSeedToEntity(featSeed, featEntity);
            return featEntity;
        }

        public static void MapSeedToEntity(FeatSeed featSeed, Feat featEntity)
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

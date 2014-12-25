using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMart.Data.Models;
using DungeonMart.Shared.Models;

namespace DungeonMart.Service.Mappers
{
    public class FeatMapper
    {
        public static Feat MapEntityToModel(FeatEntity featEntity)
        {
            return new Feat
            {
                Benefit = featEntity.Benefit,
                Choice = featEntity.Choice,
                FeatType = featEntity.FeatType,
                FullText = featEntity.FullText,
                Id = featEntity.Id,
                Multiple = featEntity.Multiple,
                Name = featEntity.Name,
                Normal = featEntity.Normal,
                Prerequisite = featEntity.Prerequisite,
                Reference = featEntity.Reference,
                Special = featEntity.Special,
                Stack = featEntity.Stack
            };
        }

        public static FeatEntity MapModelToEntity(Feat feat)
        {
            return new FeatEntity
            {
                Benefit = feat.Benefit,
                Choice = feat.Choice,
                FeatType = feat.FeatType,
                FullText = feat.FullText,
                Id = feat.Id,
                Multiple = feat.Multiple,
                Name = feat.Name,
                Normal = feat.Normal,
                Prerequisite = feat.Prerequisite,
                Reference = feat.Reference,
                Special = feat.Special,
                Stack = feat.Stack
            };
        }
    }
}

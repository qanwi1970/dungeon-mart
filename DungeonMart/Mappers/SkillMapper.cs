using System.Web;
using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class SkillMapper
    {
        static SkillMapper()
        {
            Mapper.CreateMap<Skill, SkillEntity>();
            Mapper.CreateMap<SkillEntity, Skill>();
        }

        public static Skill MapEntityToModel(SkillEntity skillEntity)
        {
            return Mapper.Map<Skill>(skillEntity);
        }

        public static SkillEntity MapModelToEntity(Skill skill)
        {
            return Mapper.Map<SkillEntity>(skill);
        }

        public static void MapModelToEntity(Skill skill, SkillEntity skillEntity)
        {
            Mapper.Map(skill, skillEntity);
        }

        public static SkillEntity MapSeedToEntity(SkillSeed skillSeed)
        {
            var skillEntity = new SkillEntity();
            MapSeedToEntity(skillSeed, skillEntity);
            return skillEntity;
        }

        public static void MapSeedToEntity(SkillSeed skillSeed, SkillEntity skillEntity)
        {
            skillEntity.Action = skillSeed.action;
            skillEntity.ArmorCheck = skillSeed.armor_check;
            skillEntity.Description = HttpUtility.HtmlDecode(skillSeed.description);
            skillEntity.EpicUse = HttpUtility.HtmlDecode(skillSeed.epic_use);
            skillEntity.FullText = HttpUtility.HtmlDecode(skillSeed.full_text);
            skillEntity.Id = skillSeed.Id;
            skillEntity.KeyAbility = skillSeed.key_ability;
            skillEntity.Name = skillSeed.name;
            skillEntity.Psionic = skillSeed.psionic;
            skillEntity.Reference = skillSeed.reference;
            skillEntity.Restriction = skillSeed.restriction;
            skillEntity.SkillCheck = HttpUtility.HtmlDecode(skillSeed.skill_check);
            skillEntity.Special = skillSeed.special;
            skillEntity.Subtype = skillSeed.subtype;
            skillEntity.Synergy = skillSeed.synergy;
            skillEntity.Trained = skillSeed.trained;
            skillEntity.TryAgain = skillSeed.try_again;
            skillEntity.Untrained = skillSeed.untrained;
        }
    }
}
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
            Mapper.CreateMap<SkillViewModel, Skill>();
            Mapper.CreateMap<Skill, SkillViewModel>();
        }

        public static SkillViewModel MapEntityToModel(Skill skillEntity)
        {
            return Mapper.Map<SkillViewModel>(skillEntity);
        }

        public static Skill MapModelToEntity(SkillViewModel skill)
        {
            return Mapper.Map<Skill>(skill);
        }

        public static void MapModelToEntity(SkillViewModel skill, Skill skillEntity)
        {
            Mapper.Map(skill, skillEntity);
        }

        public static Skill MapSeedToEntity(SkillSeed skillSeed)
        {
            var skillEntity = new Skill();
            MapSeedToEntity(skillSeed, skillEntity);
            return skillEntity;
        }

        public static void MapSeedToEntity(SkillSeed skillSeed, Skill skillEntity)
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
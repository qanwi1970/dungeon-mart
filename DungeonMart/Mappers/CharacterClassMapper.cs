using System.Web;
using AutoMapper;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Models;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class CharacterClassMapper
    {
        static CharacterClassMapper()
        {
            Mapper.CreateMap<CharacterClass, CharacterClassViewModel>();
            Mapper.CreateMap<CharacterClassViewModel, CharacterClass>();
        }

        public static CharacterClassViewModel MapEntityToModel(CharacterClass entity)
        {
            return Mapper.Map<CharacterClassViewModel>(entity);
        }

        public static CharacterClass MapModelToEntity(CharacterClassViewModel characterClass)
        {
            return Mapper.Map<CharacterClass>(characterClass);
        }

        public static void MapModelToEntity(CharacterClassViewModel characterClass, CharacterClass originalCharacterClass)
        {
            Mapper.Map(characterClass, originalCharacterClass);
        }

        public static CharacterClass MapSeedToEntity(ClassSeed classSeed)
        {
            var characterClass = new CharacterClass();
            MapSeedToEntity(classSeed, characterClass);
            return characterClass;
        }

        public static void MapSeedToEntity(ClassSeed classSeed, CharacterClass dbClass)
        {
            dbClass.Alignment = classSeed.alignment;
            dbClass.ClassSkills = classSeed.class_skills;
            dbClass.EpicFeatBaseLevel = classSeed.epic_feat_base_level;
            dbClass.EpicFeatInterval = classSeed.epic_feat_interval;
            dbClass.EpicFeatList = classSeed.epic_feat_list;
            dbClass.EpicFullText = HttpUtility.HtmlDecode(classSeed.epic_full_text);
            dbClass.FullText = HttpUtility.HtmlDecode(classSeed.full_text);
            dbClass.HitDie = classSeed.hit_die;
            dbClass.Id = classSeed.Id;
            dbClass.Name = classSeed.name;
            dbClass.Proficiencies = classSeed.proficiencies;
            dbClass.Reference = classSeed.reference;
            dbClass.RequiredBaseAttackBonus = classSeed.req_base_attack_bonus;
            dbClass.RequiredEpicFeat = classSeed.req_epic_feat;
            dbClass.RequiredFeat = classSeed.req_feat;
            dbClass.RequiredLanguages = classSeed.req_languages;
            dbClass.RequiredPsionics = classSeed.req_psionics;
            dbClass.RequiredRace = classSeed.req_race;
            dbClass.RequiredSkill = classSeed.req_skill;
            dbClass.RequiredSpecial = classSeed.req_special;
            dbClass.RequiredSpells = classSeed.req_spells;
            dbClass.RequiredWeaponProficiency = classSeed.req_weapon_proficiency;
            dbClass.SkillPoints = classSeed.skill_points;
            dbClass.SkillPointsAbility = classSeed.skill_points_ability;
            dbClass.SpellList1 = classSeed.spell_list_1;
            dbClass.SpellList2 = classSeed.spell_list_2;
            dbClass.SpellList3 = classSeed.spell_list_3;
            dbClass.SpellList4 = classSeed.spell_list_4;
            dbClass.SpellList5 = classSeed.spell_list_5;
            dbClass.SpellStat = classSeed.spell_stat;
            dbClass.SpellType = classSeed.spell_type;
            dbClass.Type = classSeed.type;
        }
    }
}
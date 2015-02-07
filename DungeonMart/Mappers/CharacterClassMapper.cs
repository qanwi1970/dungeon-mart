using System;
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
            Mapper.CreateMap<CharacterClassEntity, CharacterClass>();
            Mapper.CreateMap<CharacterClass, CharacterClassEntity>();
        }

        public static CharacterClass MapEntityToModel(CharacterClassEntity entity)
        {
            return Mapper.Map<CharacterClass>(entity);
        }

        public static CharacterClassEntity MapModelToEntity(CharacterClass characterClass)
        {
            return Mapper.Map<CharacterClassEntity>(characterClass);
        }

        public static void MapModelToEntity(CharacterClass characterClass, CharacterClassEntity originalCharacterClass)
        {
            Mapper.Map(characterClass, originalCharacterClass);
        }

        public static CharacterClassEntity MapSeedToEntity(ClassSeed classSeed)
        {
            return new CharacterClassEntity
            {
                Alignment = classSeed.alignment,
                ClassSkills = classSeed.class_skills,
                EpicFeatBaseLevel = classSeed.epic_feat_base_level,
                EpicFeatInterval = classSeed.epic_feat_interval,
                EpicFeatList = classSeed.epic_feat_list,
                EpicFullText = classSeed.epic_full_text,
                FullText = classSeed.full_text,
                HitDie = classSeed.hit_die,
                Id = classSeed.Id,
                Name = classSeed.name,
                Proficiencies = classSeed.proficiencies,
                Reference = classSeed.reference,
                RequiredBaseAttackBonus = classSeed.req_base_attack_bonus,
                RequiredEpicFeat = classSeed.req_epic_feat,
                RequiredFeat = classSeed.req_feat,
                RequiredLanguages = classSeed.req_languages,
                RequiredPsionics = classSeed.req_psionics,
                RequiredRace = classSeed.req_race,
                RequiredSkill = classSeed.req_skill,
                RequiredSpecial = classSeed.req_special,
                RequiredSpells = classSeed.req_spells,
                RequiredWeaponProficiency = classSeed.req_weapon_proficiency,
                SkillPoints = classSeed.skill_points,
                SkillPointsAbility = classSeed.skill_points_ability,
                SpellList1 = classSeed.spell_list_1,
                SpellList2 = classSeed.spell_list_2,
                SpellList3 = classSeed.spell_list_3,
                SpellList4 = classSeed.spell_list_4,
                SpellList5 = classSeed.spell_list_5,
                SpellStat = classSeed.spell_stat,
                SpellType = classSeed.spell_type,
                Type = classSeed.type,
                CreatedBy = "MapSeedToEntity",
                CreatedDate = DateTime.UtcNow
            };
        }

        public static void MapSeedToEntity(ClassSeed classSeed, CharacterClassEntity dbClass)
        {
            dbClass.Alignment = classSeed.alignment;
            dbClass.ClassSkills = classSeed.class_skills;
            dbClass.EpicFeatBaseLevel = classSeed.epic_feat_base_level;
            dbClass.EpicFeatInterval = classSeed.epic_feat_interval;
            dbClass.EpicFeatList = classSeed.epic_feat_list;
            dbClass.EpicFullText = classSeed.epic_full_text;
            dbClass.FullText = classSeed.full_text;
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
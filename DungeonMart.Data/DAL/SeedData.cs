using System;
using System.Data.Entity.Migrations;
using DungeonMart.Data.Models;
using DungeonMart.Data.OldSql;

namespace DungeonMart.Data.DAL
{
    public class SeedData
    {
        public static void Seed(DungeonMartContext context)
        {
            SeedCharacterClass(context);
            SeedClassProgression(context);
        }

        private static void SeedCharacterClass(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var charClass in srdContext.classes)
                {
                    var characterClass = new CharacterClass
                    {
                        Alignment = charClass.alignment,
                        ClassSkills = charClass.class_skills,
                        CreatedBy = "SeedCharacterClass",
                        CreatedDate = DateTime.UtcNow,
                        EpicFeatBaseLevel = charClass.epic_feat_base_level,
                        EpicFeatInterval = charClass.epic_feat_interval,
                        EpicFeatList = charClass.epic_feat_list,
                        EpicFullText = charClass.epic_full_text,
                        FullText = charClass.full_text,
                        HitDie = charClass.hit_die,
                        ModifiedBy = "SeedCharacterClass",
                        ModifiedDate = DateTime.UtcNow,
                        Name = charClass.name,
                        Proficiencies = charClass.proficiencies,
                        Reference = charClass.reference,
                        RequiredBaseAttackBonus = charClass.req_base_attack_bonus,
                        RequiredEpicFeat = charClass.req_epic_feat,
                        RequiredLanguages = charClass.req_languages,
                        RequiredFeat = charClass.req_feat,
                        RequiredPsionics = charClass.req_psionics,
                        RequiredRace = charClass.req_race,
                        RequiredSkill = charClass.req_skill,
                        RequiredSpecial = charClass.req_special,
                        RequiredSpells = charClass.req_spells,
                        RequiredWeaponProficiency = charClass.req_weapon_proficiency,
                        SkillPoints = charClass.skill_points,
                        SkillPointsAbility = charClass.skill_points_ability,
                        SpellList1 = charClass.spell_list_1,
                        SpellList2 = charClass.spell_list_2,
                        SpellList3 = charClass.spell_list_3,
                        SpellList4 = charClass.spell_list_4,
                        SpellList5 = charClass.spell_list_5,
                        SpellStat = charClass.spell_stat,
                        SpellType = charClass.spell_type,
                        Type = charClass.type
                    };
                    context.CharacterClasses.AddOrUpdate(characterClass);
                }
            }
        }

        private static void SeedClassProgression(DungeonMartContext context)
        {
            
        }
    }
}

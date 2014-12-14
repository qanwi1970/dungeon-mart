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
            SeedDomain(context);
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
                        Id = charClass.Id,
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
            using (var srdContext = new SRDContext())
            {
                foreach (var classTable in srdContext.class_table)
                {
                    var classProgression = new ClassProgression
                    {
                        ArmorClassBonus = classTable.ac_bonus,
                        BaseAttackBonus = classTable.base_attack_bonus,
                        BonusSpells = classTable.bonus_spells,
                        CasterLevel = classTable.caster_level,
                        ClassName = classTable.name,
                        CreatedBy = "SeedClassProgression",
                        CreatedDate = DateTime.UtcNow,
                        FlurryOfBlows = classTable.flurry_of_blows,
                        FortitudeSave = classTable.fort_save,
                        Id = classTable.Id,
                        Level = classTable.level,
                        ModifiedBy = "SeedClassProgression",
                        ModifiedDate = DateTime.UtcNow,
                        PointsPerDay = classTable.points_per_day,
                        PowerLevel = classTable.power_level,
                        PowersKnown = classTable.powers_known,
                        Reference = classTable.reference,
                        ReflexSave = classTable.ref_save,
                        Slots0 = classTable.slots_0,
                        Slots1 = classTable.slots_1,
                        Slots2 = classTable.slots_2,
                        Slots3 = classTable.slots_3,
                        Slots4 = classTable.slots_4,
                        Slots5 = classTable.slots_5,
                        Slots6 = classTable.slots_6,
                        Slots7 = classTable.slots_7,
                        Slots8 = classTable.slots_8,
                        Slots9 = classTable.slots_9,
                        Special = classTable.special,
                        SpellsKnown0 = classTable.spells_known_0,
                        SpellsKnown1 = classTable.spells_known_1,
                        SpellsKnown2 = classTable.spells_known_2,
                        SpellsKnown3 = classTable.spells_known_3,
                        SpellsKnown4 = classTable.spells_known_4,
                        SpellsKnown5 = classTable.spells_known_5,
                        SpellsKnown6 = classTable.spells_known_6,
                        SpellsKnown7 = classTable.spells_known_7,
                        SpellsKnown8 = classTable.spells_known_8,
                        SpellsKnown9 = classTable.spells_known_9,
                        UnarmedDamage = classTable.unarmed_damage,
                        UnarmoredSpeedBonus = classTable.unarmored_speed_bonus,
                        WillSave = classTable.will_save
                    };
                    context.ClassProgressions.AddOrUpdate(classProgression);
                }
            }
        }

        private static void SeedDomain(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var domain in srdContext.domains)
                {
                    var dmDomain = new Domain
                    {
                        CreatedBy = "SeedDomain",
                        CreatedDate = DateTime.UtcNow,
                        FullText = domain.full_text,
                        GrantedPowers = domain.granted_powers,
                        Id = domain.Id,
                        ModifiedBy = "SeedDomain",
                        ModifiedDate = DateTime.UtcNow,
                        Name = domain.name,
                        Reference = domain.reference,
                        Spell1 = domain.spell_1,
                        Spell2 = domain.spell_2,
                        Spell3 = domain.spell_3,
                        Spell4 = domain.spell_4,
                        Spell5 = domain.spell_5,
                        Spell6 = domain.spell_6,
                        Spell7 = domain.spell_7,
                        Spell8 = domain.spell_8,
                        Spell9 = domain.spell_9
                    };
                    context.Domains.AddOrUpdate(dmDomain);
                }
            }
        }
    }
}

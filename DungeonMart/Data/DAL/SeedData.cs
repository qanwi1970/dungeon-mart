using System;
using System.Data.Entity.Migrations;
using DungeonMart.Data.Models;
using DungeonMart.Data.OldSql;

namespace DungeonMart.Data.DAL
{
    internal class SeedData
    {
        public static void Seed(DungeonMartContext context)
        {
            SeedCharacterClass(context);
            SeedClassProgression(context);
            SeedDomain(context);
            SeedEquipment(context);
            SeedFeat(context);
            SeedItem(context);
            SeedMonster(context);
            SeedPower(context);
            SeedSkill(context);
            SeedSpell(context);
        }

        private static void SeedCharacterClass(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var charClass in srdContext.classes)
                {
                    var characterClass = new CharacterClassEntity
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
                    var classProgression = new ClassProgressionEntity
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
                    var dmDomain = new DomainEntity
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

        private static void SeedEquipment(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var equipment in srdContext.equipments)
                {
                    var dmEquipment = new EquipmentEntity
                    {
                        ArcaneSpellFailureChance = equipment.arcane_spell_failure_chance,
                        ArmorCheckPenalty = equipment.armor_check_penalty,
                        ArmorShieldBonus = equipment.armor_shield_bonus,
                        Category = equipment.category,
                        Cost = equipment.cost,
                        CreatedBy = "SeedEquipment",
                        CreatedDate = DateTime.UtcNow,
                        Critical = equipment.critical,
                        DamageMedium = equipment.dmg_m,
                        DamageSmall = equipment.dmg_s,
                        Family = equipment.family,
                        FullText = equipment.full_text,
                        Id = equipment.Id,
                        MaximumDexBonus = equipment.maximum_dex_bonus,
                        ModifiedBy = "SeedEquipment",
                        ModifiedDate = DateTime.UtcNow,
                        Name = equipment.name,
                        RangeIncrement = equipment.range_increment,
                        Reference = equipment.reference,
                        Speed20 = equipment.speed_20,
                        Speed30 = equipment.speed_30,
                        Subcategory = equipment.subcategory,
                        WeaponType = equipment.type,
                        Weight = equipment.weight
                    };
                    context.Equipments.AddOrUpdate(dmEquipment);
                }
            }
        }

        private static void SeedFeat(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var feat in srdContext.feats)
                {
                    var dmFeat = new FeatEntity
                    {
                        Benefit = feat.benefit,
                        Choice = feat.choice,
                        CreatedBy = "SeedFeat",
                        CreatedDate = DateTime.UtcNow,
                        FeatType = feat.type,
                        FullText = feat.full_text,
                        Id = feat.Id,
                        ModifiedBy = "SeedFeat",
                        ModifiedDate = DateTime.UtcNow,
                        Multiple = feat.multiple,
                        Name = feat.name,
                        Normal = feat.normal,
                        Prerequisite = feat.prerequisite,
                        Reference = feat.reference,
                        Special = feat.special,
                        Stack = feat.stack
                    };
                    context.Feats.AddOrUpdate(dmFeat);
                }
            }
        }

        private static void SeedItem(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var item in srdContext.items)
                {
                    var dmItem = new Item
                    {
                        Aura = item.aura,
                        CasterLevel = item.caster_level,
                        Category = item.category,
                        Cost = item.cost,
                        CreatedBy = "SeedItem",
                        CreatedDate = DateTime.UtcNow,
                        FullText = item.full_text,
                        Id = item.Id,
                        ManifesterLevel = item.manifester_level,
                        ModifiedBy = "SeedItem",
                        ModifiedDate = DateTime.UtcNow,
                        Name = item.name,
                        Prerequisites = item.prereq,
                        Price = item.price,
                        Reference = item.reference,
                        SpecialAbility = item.special_ability,
                        Subcategory = item.subcategory,
                        Weight = item.weight
                    };
                    context.Items.AddOrUpdate(dmItem);
                }
            }
        }

        private static void SeedMonster(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var monster in srdContext.monsters)
                {
                    var dmMonster = new MonsterEntity
                    {
                        Abilities = monster.abilities,
                        Advancement = monster.advancement,
                        Alignment = monster.alignment,
                        AlternateName = monster.altname,
                        ArmorClass = monster.armor_class,
                        Attack = monster.attack,
                        BaseAttack = monster.base_attack,
                        BonusFeats = monster.bonus_feats,
                        ChallengeRating = monster.challenge_rating,
                        CreatedBy = "SeedMonster",
                        CreatedDate = DateTime.UtcNow,
                        Descriptor = monster.descriptor,
                        Environment = monster.environment,
                        EpicFeats = monster.epic_feats,
                        Family = monster.family,
                        Feats = monster.feats,
                        FullAttack = monster.full_attack,
                        FullText = monster.full_text,
                        Grapple = monster.grapple,
                        HitDice = monster.hit_dice,
                        Id = monster.Id,
                        Initiative = monster.initiative,
                        LevelAdjustment = monster.level_adjustment,
                        ModifiedBy = "SeedMonster",
                        ModifiedDate = DateTime.UtcNow,
                        Name = monster.name,
                        Organization = monster.organization,
                        Reach = monster.reach,
                        Reference = monster.reference,
                        Saves = monster.saves,
                        Size = monster.size,
                        Skills = monster.skills,
                        Space = monster.space,
                        SpecialAbilities = monster.special_abilities,
                        SpecialAttacks = monster.special_attacks,
                        SpecialQualities = monster.special_qualities,
                        Speed = monster.speed,
                        StatBlock = monster.stat_block,
                        Treasure = monster.treasure,
                        Type = monster.type
                    };
                    context.Monsters.AddOrUpdate(dmMonster);
                }
            }
        }

        private static void SeedPower(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var power in srdContext.powers)
                {
                    var dmPower = new Power
                    {
                        Area = power.area,
                        Augment = power.augment,
                        CreatedBy = "SeedPower",
                        CreatedDate = DateTime.UtcNow,
                        Description = power.description,
                        Descriptor = power.descriptor,
                        Discipline = power.discipline,
                        Display = power.display,
                        Duration = power.duration,
                        Effect = power.effect,
                        FullText = power.full_text,
                        Id = power.Id,
                        Level = power.level,
                        ManifestingTime = power.manifesting_time,
                        ModifiedBy = "SeedPower",
                        ModifiedDate = DateTime.UtcNow,
                        Name = power.name,
                        PowerPoints = power.power_points,
                        PowerResistance = power.power_resistance,
                        Range = power.range,
                        Reference = power.reference,
                        SavingThrow = power.saving_throw,
                        ShortDescription = power.short_description,
                        Subdiscipline = power.subdiscipline,
                        Target = power.target,
                        XPCost = power.xp_cost
                    };
                    context.Powers.AddOrUpdate(dmPower);
                }
            }
        }

        private static void SeedSkill(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var skill in srdContext.skills)
                {
                    var dmSkill = new Skill
                    {
                        Action = skill.action,
                        ArmorCheck = skill.armor_check,
                        CreatedBy = "SeedSkill",
                        CreatedDate = DateTime.UtcNow,
                        Description = skill.description,
                        EpicUse = skill.epic_use,
                        FullText = skill.full_text,
                        Id = skill.Id,
                        KeyAbility = skill.key_ability,
                        ModifiedBy = "SeedSkill",
                        ModifiedDate = DateTime.UtcNow,
                        Name = skill.name,
                        Psionic = skill.psionic,
                        Reference = skill.reference,
                        Restriction = skill.restriction,
                        SkillCheck = skill.skill_check,
                        Special = skill.special,
                        Subtype = skill.subtype,
                        Synergy = skill.synergy,
                        Trained = skill.trained,
                        TryAgain = skill.try_again,
                        Untrained = skill.untrained
                    };
                    context.Skills.AddOrUpdate(dmSkill);
                }
            }
        }

        private static void SeedSpell(DungeonMartContext context)
        {
            using (var srdContext = new SRDContext())
            {
                foreach (var spell in srdContext.spells)
                {
                    var dmSpell = new Spell
                    {
                        AlternateName = spell.altname,
                        ArcaneFocus = spell.arcane_focus,
                        ArcaneMaterialComponents = spell.arcane_material_components,
                        Area = spell.area,
                        BardFocus = spell.bard_focus,
                        CastingTime = spell.casting_time,
                        ClericFocus = spell.cleric_focus,
                        Components = spell.components,
                        CreatedBy = "SeedSpell",
                        CreatedDate = DateTime.UtcNow,
                        Description = spell.description,
                        Descriptor = spell.descriptor,
                        DruidFocus = spell.druid_focus,
                        Duration = spell.duration,
                        Effect = spell.effect,
                        Focus = spell.focus,
                        FullText = spell.full_text,
                        Id = spell.Id,
                        Level = spell.level,
                        MaterialComponents = spell.material_components,
                        ModifiedBy = "SeedSpell",
                        ModifiedDate = DateTime.UtcNow,
                        Name = spell.name,
                        Range = spell.range,
                        Reference = spell.reference,
                        SavingThrow = spell.saving_throw,
                        School = spell.school,
                        ShortDescription = spell.short_description,
                        SorcererFocus = spell.sorcerer_focus,
                        SpellResistance = spell.spell_resistance,
                        SpellcraftDC = spell.spellcraft_dc,
                        Subschool = spell.subschool,
                        Target = spell.target,
                        ToDevelop = spell.to_develop,
                        VerbalComponents = spell.verbal_components,
                        WizardFocus = spell.wizard_focus,
                        XPCost = spell.xp_cost
                    };
                    context.Spells.AddOrUpdate(dmSpell);
                }
            }
        }
    }

    public class ClassSeed
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string alignment { get; set; }
        public string hit_die { get; set; }
        public string class_skills { get; set; }
        public string skill_points { get; set; }
        public string skill_points_ability { get; set; }
        public string spell_stat { get; set; }
        public string proficiencies { get; set; }
        public string spell_type { get; set; }
        public string epic_feat_base_level { get; set; }
        public string epic_feat_interval { get; set; }
        public string epic_feat_list { get; set; }
        public string epic_full_text { get; set; }
        public string req_race { get; set; }
        public string req_weapon_proficiency { get; set; }
        public string req_base_attack_bonus { get; set; }
        public string req_skill { get; set; }
        public string req_feat { get; set; }
        public string req_spells { get; set; }
        public string req_languages { get; set; }
        public string req_psionics { get; set; }
        public string req_epic_feat { get; set; }
        public string req_special { get; set; }
        public string spell_list_1 { get; set; }
        public string spell_list_2 { get; set; }
        public string spell_list_3 { get; set; }
        public string spell_list_4 { get; set; }
        public string spell_list_5 { get; set; }
        public string full_text { get; set; }
        public string reference { get; set; }
    }
}

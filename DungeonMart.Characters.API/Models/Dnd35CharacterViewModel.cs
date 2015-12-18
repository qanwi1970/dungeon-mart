using System.Collections.Generic;

namespace DungeonMart.Characters.API.Models
{
    public class Dnd35CharacterViewModel : BaseCharacterViewModel
    {
        public List<ClassLevel> Classes { get; set; }
        public int? Ecl { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public string Diety { get; set; }
        public string Size { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Eyes { get; set; }
        public string Hair { get; set; }
        public string Skin { get; set; }
        public Ability Strength { get; set; }
        public Ability Dexterity { get; set; }
        public Ability Constitution { get; set; }
        public Ability Intelligence { get; set; }
        public Ability Wisdom { get; set; }
        public Ability Charisma { get; set; }
        public int? HitPoints { get; set; }
        public int? Speed { get; set; }
        public ArmorClassModifiers ArmorClass { get; set; }
        public string DamageReduction { get; set; }
        public InitiativeModifier Initiative { get; set; }
        public GrappleModifier Grapple { get; set; }
        public SavingThrow FortitudeSave { get; set; }
        public SavingThrow ReflexSave { get; set; }
        public SavingThrow WillSave { get; set; }
        public List<string> ConditionalSaveModifiers { get; set; }
        public int? BaseAttackBonus { get; set; }
        public List<AttackStats> AttackOptions { get; set; }
        public List<SkillStats> Skills { get; set; }
        public int? ExperiencePoints { get; set; }
        public ArmorStats Armor { get; set; }
        public ShieldStats Shield { get; set; }
        public List<ItemStats> Items { get; set; }
        public List<string> RacialTraits { get; set; }
        public List<string> ClassFeatures { get; set; }
        public List<string> Feats { get; set; }
        public List<string> Languages { get; set; }


        public Dnd35CharacterViewModel()
        {
            Classes = new List<ClassLevel>();
            ConditionalSaveModifiers = new List<string>();
            AttackOptions = new List<AttackStats>();
            Skills = new List<SkillStats>();
            Items = new List<ItemStats>();
            RacialTraits = new List<string>();
            ClassFeatures = new List<string>();
            Feats = new List<string>();
            Languages = new List<string>();
        }


        public class ClassLevel
        {
            public string ClassName { get; set; }
            public int? Level { get; set; }
        }

        public class Ability
        {
            public int? Score { get; set; }
            public int? Modifier { get; set; }
        }

        public class ArmorClassModifiers
        {
            public int? ArmorBonus { get; set; }
            public int? ShieldBonus { get; set; }
            public int? DexModifier { get; set; }
            public int? SizeModifier { get; set; }
            public int? NaturalArmor { get; set; }
            public int? DeflectionModifier { get; set; }
            public int? MiscModifier { get; set; }
            public int? Total { get; set; }
            public int? Touch { get; set; }
            public int? FlatFooted { get; set; }
        }

        public class InitiativeModifier
        {
            public int? DexModifier { get; set; }
            public int? MiscModifier { get; set; }
            public int? Total { get; set; }
        }

        public class GrappleModifier
        {
            public int? BaseAttackBonus { get; set; }
            public int? StrengthModifier { get; set; }
            public int? SizeModifier { get; set; }
            public int? MiscModifier { get; set; }
            public int? Total { get; set; }
        }

        public class SavingThrow
        {
            public int? Base { get; set; }
            public int? AbilityModifier { get; set; }
            public int? MagicModifier { get; set; }
            public int? MiscModifier { get; set; }
            public int? TempModifier { get; set; }
        }

        public class AttackStats
        {
            public string Name { get; set; }
            public int? AttackBonus { get; set; }
            public string Damage { get; set; }
            public string Critical { get; set; }
            public string DamageType { get; set; }
            public int? RangeIncrement { get; set; }
            public string Notes { get; set; }
            public int? Ammunition { get; set; }
        }

        public class SkillStats
        {
            public string Name { get; set; }
            public bool ClassSkill { get; set; }
            public string KeyAbility { get; set; }
            public bool ArmorCheck { get; set; }
            public int? Ranks { get; set; }
            public int? AbilityModifier { get; set; }
            public int? MiscModifier { get; set; }
            public int? TotalModifier { get; set; }
        }

        public class ArmorStats
        {
            public string Name { get; set; }
            public string ArmorType { get; set; }
            public int? AcBonus { get; set; }
            public int? MaxDex { get; set; }
            public int? CheckPenalty { get; set; }
            public int? SpellFailure { get; set; }
            public int? Speed { get; set; }
            public int? Weight { get; set; }
            public string SpecialProperties { get; set; }
        }

        public class ShieldStats
        {
            public string Name { get; set; }
            public int? AcBonus { get; set; }
            public int? MaxDex { get; set; }
            public int? CheckPenalty { get; set; }
            public int? SpellFailure { get; set; }
            public int? Weight { get; set; }
            public string SpecialProperties { get; set; }
        }

        public class ItemStats
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public decimal Weight { get; set; }
            public string SpecialProperties { get; set; }
        }
    }

}
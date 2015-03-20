using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("ClassProgression")]
    public class ClassProgression : IAuditable
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        public string Level { get; set; }

        public string BaseAttackBonus { get; set; }

        public string FortitudeSave { get; set; }

        public string ReflexSave { get; set; }

        public string WillSave { get; set; }

        public string CasterLevel { get; set; }

        public string PointsPerDay { get; set; }

        public string ArmorClassBonus { get; set; }

        public string FlurryOfBlows { get; set; }

        public string BonusSpells { get; set; }

        public string PowersKnown { get; set; }

        public string UnarmoredSpeedBonus { get; set; }

        public string UnarmedDamage { get; set; }

        public string PowerLevel { get; set; }

        public string Special { get; set; }

        public string Slots0 { get; set; }

        public string Slots1 { get; set; }

        public string Slots2 { get; set; }

        public string Slots3 { get; set; }

        public string Slots4 { get; set; }

        public string Slots5 { get; set; }

        public string Slots6 { get; set; }

        public string Slots7 { get; set; }

        public string Slots8 { get; set; }

        public string Slots9 { get; set; }

        public string SpellsKnown0 { get; set; }

        public string SpellsKnown1 { get; set; }

        public string SpellsKnown2 { get; set; }

        public string SpellsKnown3 { get; set; }

        public string SpellsKnown4 { get; set; }

        public string SpellsKnown5 { get; set; }

        public string SpellsKnown6 { get; set; }

        public string SpellsKnown7 { get; set; }

        public string SpellsKnown8 { get; set; }

        public string SpellsKnown9 { get; set; }

        public string Reference { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool SeedData { get; set; }
    }
}

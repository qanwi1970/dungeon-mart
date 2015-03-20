﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("Equipment")]
    public class Equipment : IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string Cost { get; set; }

        public string DamageSmall { get; set; }

        public string ArmorShieldBonus { get; set; }

        public string MaximumDexBonus { get; set; }

        public string DamageMedium { get; set; }

        public string Weight { get; set; }

        public string Critical { get; set; }

        public string ArmorCheckPenalty { get; set; }

        public string ArcaneSpellFailureChance { get; set; }

        public string RangeIncrement { get; set; }

        public string Speed30 { get; set; }

        public string WeaponType { get; set; }

        public string Speed20 { get; set; }

        public string FullText { get; set; }

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

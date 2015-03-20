﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("CharacterClass")]
    public class CharacterClass : IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Alignment { get; set; }

        public string HitDie { get; set; }

        public string ClassSkills { get; set; }

        public string SkillPoints { get; set; }

        public string SkillPointsAbility { get; set; }

        public string SpellStat { get; set; }

        public string Proficiencies { get; set; }

        public string SpellType { get; set; }

        public string EpicFeatBaseLevel { get; set; }

        public string EpicFeatInterval { get; set; }

        public string EpicFeatList { get; set; }

        public string EpicFullText { get; set; }

        public string RequiredRace { get; set; }

        public string RequiredWeaponProficiency { get; set; }

        public string RequiredBaseAttackBonus { get; set; }

        public string RequiredSkill { get; set; }

        public string RequiredFeat { get; set; }

        public string RequiredSpells { get; set; }

        public string RequiredLanguages { get; set; }

        public string RequiredPsionics { get; set; }

        public string RequiredEpicFeat { get; set; }

        public string RequiredSpecial { get; set; }

        public string SpellList1 { get; set; }

        public string SpellList2 { get; set; }

        public string SpellList3 { get; set; }

        public string SpellList4 { get; set; }

        public string SpellList5 { get; set; }

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

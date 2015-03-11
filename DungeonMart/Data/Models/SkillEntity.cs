using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("Skill")]
    public class SkillEntity : IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Subtype { get; set; }

        public string KeyAbility { get; set; }

        public string Psionic { get; set; }

        public string Trained { get; set; }

        public string ArmorCheck { get; set; }

        public string Description { get; set; }

        public string SkillCheck { get; set; }

        public string Action { get; set; }

        public string TryAgain { get; set; }

        public string Special { get; set; }

        public string Restriction { get; set; }

        public string Synergy { get; set; }

        public string EpicUse { get; set; }

        public string Untrained { get; set; }

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

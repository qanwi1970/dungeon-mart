using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("Monster")]
    public class MonsterEntity : IAuditable
    {
        public int Id { get; set; }

        public string Family { get; set; }

        public string Name { get; set; }

        public string AlternateName { get; set; }

        public string Size { get; set; }

        public string Type { get; set; }

        public string Descriptor { get; set; }

        public string HitDice { get; set; }

        public string Initiative { get; set; }

        public string Speed { get; set; }

        public string ArmorClass { get; set; }

        public string BaseAttack { get; set; }

        public string Grapple { get; set; }

        public string Attack { get; set; }

        public string FullAttack { get; set; }

        public string Space { get; set; }

        public string Reach { get; set; }

        public string SpecialAttacks { get; set; }

        public string SpecialQualities { get; set; }

        public string Saves { get; set; }

        public string Abilities { get; set; }

        public string Skills { get; set; }

        public string BonusFeats { get; set; }

        public string Feats { get; set; }

        public string EpicFeats { get; set; }

        public string Environment { get; set; }

        public string Organization { get; set; }

        public string ChallengeRating { get; set; }

        public string Treasure { get; set; }

        public string Alignment { get; set; }

        public string Advancement { get; set; }

        public string LevelAdjustment { get; set; }

        public string SpecialAbilities { get; set; }

        public string StatBlock { get; set; }

        public string FullText { get; set; }

        public string Reference { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}

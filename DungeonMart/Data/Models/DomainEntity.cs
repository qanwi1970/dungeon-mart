using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("Domain")]
    public class DomainEntity : IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GrantedPowers { get; set; }

        public string Spell1 { get; set; }

        public string Spell2 { get; set; }

        public string Spell3 { get; set; }

        public string Spell4 { get; set; }

        public string Spell5 { get; set; }

        public string Spell6 { get; set; }

        public string Spell7 { get; set; }

        public string Spell8 { get; set; }

        public string Spell9 { get; set; }

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

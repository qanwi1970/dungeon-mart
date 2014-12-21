using System;
using System.ComponentModel.DataAnnotations;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    public class Power : IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Discipline { get; set; }

        public string Subdiscipline { get; set; }

        public string Descriptor { get; set; }

        public string Level { get; set; }

        public string Display { get; set; }

        public string ManifestingTime { get; set; }

        public string Range { get; set; }

        public string Target { get; set; }

        public string Area { get; set; }

        public string Effect { get; set; }

        public string Duration { get; set; }

        public string SavingThrow { get; set; }

        public string PowerPoints { get; set; }

        public string PowerResistance { get; set; }

        public string ShortDescription { get; set; }

        public string XPCost { get; set; }

        public string Description { get; set; }

        public string Augment { get; set; }

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

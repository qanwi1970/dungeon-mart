using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("Feat")]
    public class FeatEntity : IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FeatType { get; set; }

        public string Multiple { get; set; }

        public string Stack { get; set; }

        public string Choice { get; set; }

        public string Prerequisite { get; set; }

        public string Benefit { get; set; }

        public string Normal { get; set; }

        public string Special { get; set; }

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

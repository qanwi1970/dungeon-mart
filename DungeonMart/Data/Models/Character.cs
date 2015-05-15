using System;
using System.ComponentModel.DataAnnotations.Schema;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Models
{
    [Table("Character")]
    public class Character : IAuditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
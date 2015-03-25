using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DungeonMart.Data.Models
{
    public class Alignment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public short Good { get; set; }

        public short Law { get; set; }

        public string Description { get; set; }

        public string Quote { get; set; }
    }
}
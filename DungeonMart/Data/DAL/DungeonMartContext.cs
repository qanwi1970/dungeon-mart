using System.Data.Entity;
using DungeonMart.Data.Models;
using DungeonMart.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DungeonMart.Data.DAL
{
    public class DungeonMartContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CharacterClass> CharacterClasses { get; set; }

        public DbSet<ClassProgression> ClassProgressions { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Feat> Feats { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Monster> Monsters { get; set; }

        public DbSet<Power> Powers { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<Alignment> Alignments { get; set; }

        public DungeonMartContext()
            : base("name=DungeonMartContext")
        {
        }

        public DungeonMartContext(string connectionString)
            : base(connectionString)
        {
        }

        public static DungeonMartContext Create()
        {
            return new DungeonMartContext();
        }
    }
}
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.DAL
{
    public class DungeonMartContext : DbContext
    {
        public DungeonMartContext() : base("DungeonMartContext")
        {
        }

        public DbSet<CharacterClass> CharacterClasses { get; set; }

        public DbSet<ClassProgression> ClassProgressions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

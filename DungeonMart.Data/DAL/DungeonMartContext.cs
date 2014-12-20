using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.DAL
{
    public class DungeonMartContext : DbContext
    {
        public DungeonMartContext() : base("name=DungeonMartContext")
        {
        }

        public DungeonMartContext(string connectionStringOrName) : base(connectionStringOrName)
        {    
        }

        public DbSet<CharacterClass> CharacterClasses { get; set; }

        public DbSet<ClassProgression> ClassProgressions { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Feat> Feats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.DAL
{
    public class DungeonMartContext : DbContext, IDungeonMartContext
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

        public DbSet<FeatEntity> Feats { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<MonsterEntity> Monsters { get; set; }

        public DbSet<Power> Powers { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Spell> Spells { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

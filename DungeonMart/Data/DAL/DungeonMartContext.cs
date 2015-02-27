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

        public DbSet<CharacterClassEntity> CharacterClasses { get; set; }

        public DbSet<ClassProgressionEntity> ClassProgressions { get; set; }

        public DbSet<DomainEntity> Domains { get; set; }

        public DbSet<EquipmentEntity> Equipments { get; set; }

        public DbSet<FeatEntity> Feats { get; set; }

        public DbSet<ItemEntity> Items { get; set; }

        public DbSet<MonsterEntity> Monsters { get; set; }

        public DbSet<PowerEntity> Powers { get; set; }

        public DbSet<SkillEntity> Skills { get; set; }

        public DbSet<SpellEntity> Spells { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

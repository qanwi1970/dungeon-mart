using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.DAL
{
    internal interface IDungeonMartContext
    {
        DbSet<CharacterClassEntity> CharacterClasses { get; set; }
        DbSet<ClassProgressionEntity> ClassProgressions { get; set; }
        DbSet<DomainEntity> Domains { get; set; }
        DbSet<EquipmentEntity> Equipments { get; set; }
        DbSet<FeatEntity> Feats { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<MonsterEntity> Monsters { get; set; }
        DbSet<Power> Powers { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<Spell> Spells { get; set; }

        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
    }
}

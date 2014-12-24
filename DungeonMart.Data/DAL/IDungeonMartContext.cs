using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.DAL
{
    public interface IDungeonMartContext
    {
        DbSet<CharacterClass> CharacterClasses { get; set; }
        DbSet<ClassProgression> ClassProgressions { get; set; }
        DbSet<Domain> Domains { get; set; }
        DbSet<Equipment> Equipments { get; set; }
        DbSet<FeatEntity> Feats { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Monster> Monsters { get; set; }
        DbSet<Power> Powers { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<Spell> Spells { get; set; }

        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
    }
}

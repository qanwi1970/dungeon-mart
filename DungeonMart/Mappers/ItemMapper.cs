using System.Web;
using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class ItemMapper
    {
        static ItemMapper()
        {
            Mapper.CreateMap<Item, ItemEntity>();
            Mapper.CreateMap<ItemEntity, Item>();
        }

        public static Item MapEntityToModel(ItemEntity itemEntity)
        {
            return Mapper.Map<Item>(itemEntity);
        }

        public static ItemEntity MapModelToEntity(Item item)
        {
            return Mapper.Map<ItemEntity>(item);
        }

        public static void MapModelToEntity(Item item, ItemEntity itemEntity)
        {
            Mapper.Map(item, itemEntity);
        }

        public static ItemEntity MapSeedToEntity(ItemSeed itemSeed)
        {
            var itemEntity = new ItemEntity();
            MapSeedToEntity(itemSeed, itemEntity);
            return itemEntity;
        }

        public static void MapSeedToEntity(ItemSeed itemSeed, ItemEntity itemEntity)
        {
            itemEntity.Aura = itemSeed.aura;
            itemEntity.CasterLevel = itemSeed.caster_level;
            itemEntity.Category = itemSeed.category;
            itemEntity.Cost = itemSeed.cost;
            itemEntity.FullText = HttpUtility.HtmlDecode(itemSeed.full_text);
            itemEntity.Id = itemSeed.Id;
            itemEntity.ManifesterLevel = itemSeed.manifester_level;
            itemEntity.Name = itemSeed.name;
            itemEntity.Prerequisites = itemSeed.prereq;
            itemEntity.Price = itemSeed.price;
            itemEntity.Reference = itemSeed.reference;
            itemEntity.SpecialAbility = itemSeed.special_ability;
            itemEntity.Subcategory = itemSeed.subcategory;
            itemEntity.Weight = itemSeed.weight;
        }
    }
}
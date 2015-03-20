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
            Mapper.CreateMap<ItemViewModel, Item>();
            Mapper.CreateMap<Item, ItemViewModel>();
        }

        public static ItemViewModel MapEntityToModel(Item itemEntity)
        {
            return Mapper.Map<ItemViewModel>(itemEntity);
        }

        public static Item MapModelToEntity(ItemViewModel item)
        {
            return Mapper.Map<Item>(item);
        }

        public static void MapModelToEntity(ItemViewModel item, Item itemEntity)
        {
            Mapper.Map(item, itemEntity);
        }

        public static Item MapSeedToEntity(ItemSeed itemSeed)
        {
            var itemEntity = new Item();
            MapSeedToEntity(itemSeed, itemEntity);
            return itemEntity;
        }

        public static void MapSeedToEntity(ItemSeed itemSeed, Item itemEntity)
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
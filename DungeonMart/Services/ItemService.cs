using System.IO;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IQueryable<ItemViewModel> GetItems()
        {
            return _itemRepository.GetAll().Select(ItemMapper.MapEntityToModel).AsQueryable();
        }

        public ItemViewModel GetItemById(int id)
        {
            return ItemMapper.MapEntityToModel(_itemRepository.GetById(id));
        }

        public ItemViewModel AddItem(ItemViewModel item)
        {
            var newItem = ItemMapper.MapModelToEntity(item);
            newItem.CreatedBy = "TEST";
            newItem.SeedData = false;
            var addedItem = _itemRepository.Add(newItem);
            return ItemMapper.MapEntityToModel(addedItem);
        }

        public ItemViewModel UpdateItem(int id, ItemViewModel item)
        {
            var originalItem = _itemRepository.GetById(id);
            ItemMapper.MapModelToEntity(item, originalItem);
            originalItem.ModifiedBy = "TEST";
            var updatedItem = _itemRepository.Update(originalItem);
            return ItemMapper.MapEntityToModel(updatedItem);
        }

        public void DeleteItem(int id)
        {
            _itemRepository.Delete(id);
        }

        public void SeedItems(string seedPath)
        {
            ItemSeed[] itemArray;
            using (var itemStream = new StreamReader(seedPath + "/item.json"))
            {
                itemArray = JsonConvert.DeserializeObject<ItemSeed[]>(itemStream.ReadToEnd());
            }
            foreach (var itemSeed in itemArray)
            {
                var itemEntity = _itemRepository.GetById(itemSeed.Id);
                if (itemEntity == null)
                {
                    var newItem = ItemMapper.MapSeedToEntity(itemSeed);
                    newItem.CreatedBy = "SeedItems";
                    newItem.SeedData = true;
                    _itemRepository.Add(newItem);
                }
                else
                {
                    ItemMapper.MapSeedToEntity(itemSeed, itemEntity);
                    itemEntity.ModifiedBy = "SeedItems";
                    _itemRepository.Update(itemEntity);
                }
            }
        }
    }
}
using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IItemService
    {
        IQueryable<Item> GetItems();
        Item GetItemById(int id);
        Item AddItem(Item item);
        Item UpdateItem(int id, Item item);
        void DeleteItem(int id);
        void SeedItems(string seedPath);
    }
}

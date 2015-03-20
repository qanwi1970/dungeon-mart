using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IItemService
    {
        IQueryable<ItemViewModel> GetItems();
        ItemViewModel GetItemById(int id);
        ItemViewModel AddItem(ItemViewModel item);
        ItemViewModel UpdateItem(int id, ItemViewModel item);
        void DeleteItem(int id);
        void SeedItems(string seedPath);
    }
}

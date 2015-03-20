using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

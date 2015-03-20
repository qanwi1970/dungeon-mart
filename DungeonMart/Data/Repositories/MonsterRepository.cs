using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    public class MonsterRepository : Repository<Monster>, IMonsterRepository
    {
        public MonsterRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

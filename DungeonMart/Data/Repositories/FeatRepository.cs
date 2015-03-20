using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class FeatRepository : Repository<Feat>, IFeatRepository
    {
        public FeatRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

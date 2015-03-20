using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class ClassProgressionRepository : Repository<ClassProgression>, IClassProgressionRepository
    {
        public ClassProgressionRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

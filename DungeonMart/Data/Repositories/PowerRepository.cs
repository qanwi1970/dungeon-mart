using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class PowerRepository : Repository<Power>, IPowerRepository
    {
        public PowerRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

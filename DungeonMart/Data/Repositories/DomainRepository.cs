using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class DomainRepository : Repository<Domain>, IDomainRepository
    {
        public DomainRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

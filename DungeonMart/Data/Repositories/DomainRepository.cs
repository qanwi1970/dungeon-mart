using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class DomainRepository : Repository<DomainEntity>, IDomainRepository
    {
        public DomainRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

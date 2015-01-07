using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    public class FeatRepository : Repository<FeatEntity>, IFeatRepository
    {
        public FeatRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

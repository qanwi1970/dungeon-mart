using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class ClassProgressionRepository : Repository<ClassProgressionEntity>, IClassProgressionRepository
    {
        public ClassProgressionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

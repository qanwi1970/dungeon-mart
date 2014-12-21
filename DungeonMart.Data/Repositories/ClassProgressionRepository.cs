using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    public class ClassProgressionRepository : Repository<ClassProgression>, IClassProgressionRepository
    {
        public ClassProgressionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

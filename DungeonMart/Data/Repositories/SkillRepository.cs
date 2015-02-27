using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class SkillRepository : Repository<SkillEntity>, ISkillRepository
    {
        public SkillRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

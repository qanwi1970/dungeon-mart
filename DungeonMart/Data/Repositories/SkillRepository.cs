using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

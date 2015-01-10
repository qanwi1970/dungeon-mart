using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class MonsterRepository : Repository<MonsterEntity>, IMonsterRepository
    {
        public MonsterRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

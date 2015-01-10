using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class CharacterClassRepository : Repository<CharacterClassEntity>, ICharacterClassRepository
    {
        public CharacterClassRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

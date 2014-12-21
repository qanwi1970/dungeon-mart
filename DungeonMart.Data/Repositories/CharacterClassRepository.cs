using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    public class CharacterClassRepository : Repository<CharacterClass>, ICharacterClassRepository
    {
        public CharacterClassRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

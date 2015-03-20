using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class CharacterClassRepository : Repository<CharacterClass>, ICharacterClassRepository
    {
        public CharacterClassRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

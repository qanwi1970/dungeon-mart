using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    public class SpellRepository : Repository<Spell>, ISpellRepository
    {
        public SpellRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

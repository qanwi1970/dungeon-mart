using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class SpellRepository : Repository<SpellEntity>, ISpellRepository
    {
        public SpellRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

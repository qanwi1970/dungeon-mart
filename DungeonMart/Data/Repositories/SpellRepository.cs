using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class SpellRepository : Repository<Spell>, ISpellRepository
    {
        public SpellRepository(DungeonMartContext context) : base(context)
        {
        }
    }
}

using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface ISpellService
    {
        IQueryable<SpellViewModel> GetSpells();
        SpellViewModel GetSpellById(int id);
        SpellViewModel AddSpell(SpellViewModel spell);
        SpellViewModel UdpateSpell(int id, SpellViewModel spell);
        void DeleteSpell(int id);
        void SeedSpells(string seedPath);
    }
}

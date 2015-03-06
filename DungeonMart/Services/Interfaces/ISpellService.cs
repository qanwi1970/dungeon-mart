using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface ISpellService
    {
        IQueryable<Spell> GetSpells();
        Spell GetSpellById(int id);
        Spell AddSpell(Spell spell);
        Spell UdpateSpell(int id, Spell spell);
        void DeleteSpell(int id);
        void SeedSpells(string seedPath);
    }
}

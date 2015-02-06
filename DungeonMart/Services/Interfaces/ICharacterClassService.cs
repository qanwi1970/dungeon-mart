using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface ICharacterClassService
    {
        IQueryable<CharacterClass> GetClasses();
        CharacterClass GetClassById(int id);
        CharacterClass AddClass(CharacterClass characterClass);
        CharacterClass UpdateClass(int id, CharacterClass characterClass);
        void DeleteClass(int id);
        void SeedClass();
    }
}

using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface ICharacterClassService
    {
        IQueryable<CharacterClassViewModel> GetClasses();
        CharacterClassViewModel GetClassById(int id);
        CharacterClassViewModel AddClass(CharacterClassViewModel characterClass);
        CharacterClassViewModel UpdateClass(int id, CharacterClassViewModel characterClass);
        void DeleteClass(int id);
        void SeedClass(string seedDataPath);
    }
}

using System.Linq;
using DungeonMart.Models;
using HiPerfMetrics;
using HiPerfMetrics.Info;

namespace DungeonMart.Services.Interfaces
{
    public interface ICharacterClassService
    {
        IQueryable<CharacterClassViewModel> GetClasses();
        CharacterClassViewModel GetClassById(int id);
        CharacterClassViewModel AddClass(CharacterClassViewModel characterClass, string userId);
        CharacterClassViewModel UpdateClass(int id, CharacterClassViewModel characterClass);
        void DeleteClass(int id);
        void SeedClass(string seedDataPath);
		IQueryable<CharacterClassViewModel> GetClasses(IStartStop startChildMetric);
    }
}

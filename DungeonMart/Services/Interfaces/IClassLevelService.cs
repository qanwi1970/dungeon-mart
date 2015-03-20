using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IClassLevelService
    {
        IQueryable<ClassLevelViewModel> GetClassLevels();
        ClassLevelViewModel GetClassLevelById(int id);
        ClassLevelViewModel AddClassLevel(ClassLevelViewModel classLevel);
        ClassLevelViewModel UpdateClassLevel(int id, ClassLevelViewModel classLevel);
        void DeleteClassLevel(int id);
        void SeedClassLevel(string seedDataPath);
    }
}

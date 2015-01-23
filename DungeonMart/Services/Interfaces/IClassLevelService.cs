using System;
using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IClassLevelService
    {
        IQueryable<ClassLevel> GetClassLevels();
        ClassLevel GetClassLevelById(int id);
        ClassLevel AddClassLevel(ClassLevel classLevel);
        ClassLevel UpdateClassLevel(int id, ClassLevel classLevel);
        void DeleteClassLevel(int id);
    }
}

using System.Linq;
using DungeonMart.Shared.Models;

namespace DungeonMart.Service.Interfaces
{
    public interface IMonsterService
    {
        IQueryable<Monster> GetMonsters();
        Monster GetMonsterById(int id);
        Monster AddMonster(Monster monster);
        Monster UpdateMonster(int id, Monster monster);
        void DeleteMonster(int id);
    }
}

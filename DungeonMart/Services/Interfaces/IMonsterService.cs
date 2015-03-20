using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMonsterService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<MonsterViewModel> GetMonsters();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MonsterViewModel GetMonsterById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        MonsterViewModel AddMonster(MonsterViewModel monster);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        MonsterViewModel UpdateMonster(int id, MonsterViewModel monster);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteMonster(int id);

        void SeedMonster(string seedDataPath);
    }
}

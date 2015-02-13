using System.Linq;
using DungeonMart.Shared.Models;

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
        IQueryable<Monster> GetMonsters();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Monster GetMonsterById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        Monster AddMonster(Monster monster);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        Monster UpdateMonster(int id, Monster monster);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteMonster(int id);

        void SeedMonster(string seedDataPath);
    }
}

using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Service.Mappers;
using DungeonMart.Services.Interfaces;
using DungeonMart.Shared.Models;

namespace DungeonMart.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class MonsterService : IMonsterService
    {
        private readonly IMonsterRepository _monsterRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="monsterRepository"></param>
        public MonsterService(IMonsterRepository monsterRepository)
        {
            _monsterRepository = monsterRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Monster> GetMonsters()
        {
            return _monsterRepository.GetAll().Select(MonsterMapper.MapEntityToModel).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Monster GetMonsterById(int id)
        {
            return MonsterMapper.MapEntityToModel(_monsterRepository.GetById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        public Monster AddMonster(Monster monster)
        {
            var monsterToAdd = MonsterMapper.MapModelToEntity(monster);
            monsterToAdd.CreatedBy = "Test";
            var addedMonster = _monsterRepository.Add(monsterToAdd);
            return MonsterMapper.MapEntityToModel(addedMonster);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        public Monster UpdateMonster(int id, Monster monster)
        {
            var originalMonster = _monsterRepository.GetById(id);
            MonsterMapper.UpdateEntityFromModel(originalMonster, monster);
            originalMonster.ModifiedBy = "UpdateMonster";
            var updatedMonster = _monsterRepository.Update(originalMonster);
            return MonsterMapper.MapEntityToModel(updatedMonster);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMonster(int id)
        {
            _monsterRepository.Delete(id);
        }
    }
}

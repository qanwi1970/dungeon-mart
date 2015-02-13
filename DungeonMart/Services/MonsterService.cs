using System.IO;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Services.Interfaces;
using DungeonMart.Shared.Models;
using Newtonsoft.Json;

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
            MonsterMapper.MapModelToEntity(monster, originalMonster);
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

        public void SeedMonster(string seedDataPath)
        {
            MonsterSeed[] monsterArray;
            using (var monsterStream = new StreamReader(seedDataPath + "/monster.json"))
            {
                monsterArray = JsonConvert.DeserializeObject<MonsterSeed[]>(monsterStream.ReadToEnd());
            }
            foreach (var monsterSeed in monsterArray)
            {
                var monsterEntity = _monsterRepository.GetById(monsterSeed.Id);
                if (monsterEntity == null)
                {
                    var newMonster = MonsterMapper.MapSeedToEntity(monsterSeed);
                    newMonster.CreatedBy = "SeedMonster";
                    _monsterRepository.Add(newMonster);
                }
                else
                {
                    MonsterMapper.MapSeedToEntity(monsterSeed, monsterEntity);
                    monsterEntity.ModifiedBy = "SeedMonster";
                    _monsterRepository.Update(monsterEntity);
                }
            }
        }
    }
}

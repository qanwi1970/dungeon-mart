using System.IO;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly IMonsterRepository _monsterRepository;

        public MonsterService(IMonsterRepository monsterRepository)
        {
            _monsterRepository = monsterRepository;
        }

        public IQueryable<MonsterViewModel> GetMonsters()
        {
            return _monsterRepository.GetAll().Select(MonsterMapper.MapEntityToModel).AsQueryable();
        }

        public MonsterViewModel GetMonsterById(int id)
        {
            return MonsterMapper.MapEntityToModel(_monsterRepository.GetById(id));
        }

        public MonsterViewModel AddMonster(MonsterViewModel monster)
        {
            var monsterToAdd = MonsterMapper.MapModelToEntity(monster);
            monsterToAdd.CreatedBy = "Test";
            monsterToAdd.SeedData = false;
            var addedMonster = _monsterRepository.Add(monsterToAdd);
            return MonsterMapper.MapEntityToModel(addedMonster);
        }

        public MonsterViewModel UpdateMonster(int id, MonsterViewModel monster)
        {
            var originalMonster = _monsterRepository.GetById(id);
            MonsterMapper.MapModelToEntity(monster, originalMonster);
            originalMonster.ModifiedBy = "UpdateMonster";
            var updatedMonster = _monsterRepository.Update(originalMonster);
            return MonsterMapper.MapEntityToModel(updatedMonster);
        }

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
                    newMonster.SeedData = true;
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

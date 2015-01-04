using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Service.Interfaces;
using DungeonMart.Service.Mappers;
using DungeonMart.Shared.Models;

namespace DungeonMart.Service
{
    public class MonsterService : IMonsterService
    {
        private readonly IMonsterRepository _monsterRepository;

        public MonsterService(IMonsterRepository monsterRepository)
        {
            _monsterRepository = monsterRepository;
        }

        public IQueryable<Monster> GetMonsters()
        {
            return _monsterRepository.GetAll().Select(MonsterMapper.MapEntityToModel).AsQueryable();
        }

        public Monster GetMonsterById(int id)
        {
            return MonsterMapper.MapEntityToModel(_monsterRepository.GetById(id));
        }

        public Monster AddMonster(Monster monster)
        {
            var monsterToAdd = MonsterMapper.MapModelToEntity(monster);
            monsterToAdd.CreatedBy = "Test";
            var addedMonster = _monsterRepository.Add(monsterToAdd);
            return MonsterMapper.MapEntityToModel(addedMonster);
        }

        public Monster UpdateMonster(int id, Monster monster)
        {
            var originalMonster = _monsterRepository.GetById(id);
            MonsterMapper.UpdateEntityFromModel(originalMonster, monster);
            originalMonster.ModifiedBy = "UpdateMonster";
            var updatedMonster = _monsterRepository.Update(originalMonster);
            return MonsterMapper.MapEntityToModel(updatedMonster);
        }

        public void DeleteMonster(int id)
        {
            _monsterRepository.Delete(id);
        }
    }
}

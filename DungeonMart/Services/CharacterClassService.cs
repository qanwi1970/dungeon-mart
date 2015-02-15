using System.IO;
using System.Linq;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class CharacterClassService : ICharacterClassService
    {
        private readonly ICharacterClassRepository _characterClassRepository;

        public CharacterClassService(ICharacterClassRepository characterClassRepository)
        {
            _characterClassRepository = characterClassRepository;
        }

        public IQueryable<CharacterClass> GetClasses()
        {
            return _characterClassRepository.GetAll().Select(CharacterClassMapper.MapEntityToModel).AsQueryable();
        }

        public CharacterClass GetClassById(int id)
        {
            return CharacterClassMapper.MapEntityToModel(_characterClassRepository.GetById(id));
        }

        public CharacterClass AddClass(CharacterClass characterClass)
        {
            var characterClassToAdd = CharacterClassMapper.MapModelToEntity(characterClass);
            characterClassToAdd.CreatedBy = "TEST";
            var addedCharacterClass = _characterClassRepository.Add(characterClassToAdd);
            return CharacterClassMapper.MapEntityToModel(addedCharacterClass);
        }

        public CharacterClass UpdateClass(int id, CharacterClass characterClass)
        {
            var originalCharacterClass = _characterClassRepository.GetById(id);
            CharacterClassMapper.MapModelToEntity(characterClass, originalCharacterClass);
            originalCharacterClass.ModifiedBy = "TEST";
            var updatedCharacterClass = _characterClassRepository.Update(originalCharacterClass);
            return CharacterClassMapper.MapEntityToModel(updatedCharacterClass);
        }

        public void DeleteClass(int id)
        {
            _characterClassRepository.Delete(id);
        }

        public void SeedClass(string seedDataPath)
        {
            ClassSeed[] classArray;
            using (var classStream = new StreamReader(seedDataPath + "/class.json"))
            {
                classArray = JsonConvert.DeserializeObject<ClassSeed[]>(classStream.ReadToEnd());
            }
            foreach (var classSeed in classArray)
            {
                var dbClass = _characterClassRepository.GetById(classSeed.Id);
                if (dbClass == null)
                {
                    var newClass = CharacterClassMapper.MapSeedToEntity(classSeed);
                    newClass.CreatedBy = "SeedClass";
                    _characterClassRepository.Add(newClass);
                }
                else
                {
                    CharacterClassMapper.MapSeedToEntity(classSeed, dbClass);
                    dbClass.ModifiedBy = "SeedClass";
                    _characterClassRepository.Update(dbClass);
                }
            }
        }
    }
}
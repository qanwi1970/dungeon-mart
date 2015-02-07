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
    /// <summary>
    /// 
    /// </summary>
    public class CharacterClassService : ICharacterClassService
    {
        private readonly ICharacterClassRepository _characterClassRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterClassRepository"></param>
        public CharacterClassService(ICharacterClassRepository characterClassRepository)
        {
            _characterClassRepository = characterClassRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<CharacterClass> GetClasses()
        {
            return _characterClassRepository.GetAll().Select(CharacterClassMapper.MapEntityToModel).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CharacterClass GetClassById(int id)
        {
            return CharacterClassMapper.MapEntityToModel(_characterClassRepository.GetById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterClass"></param>
        /// <returns></returns>
        public CharacterClass AddClass(CharacterClass characterClass)
        {
            var characterClassToAdd = CharacterClassMapper.MapModelToEntity(characterClass);
            characterClassToAdd.CreatedBy = "TEST";
            var addedCharacterClass = _characterClassRepository.Add(characterClassToAdd);
            return CharacterClassMapper.MapEntityToModel(addedCharacterClass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterClass"></param>
        /// <returns></returns>
        public CharacterClass UpdateClass(int id, CharacterClass characterClass)
        {
            var originalCharacterClass = _characterClassRepository.GetById(id);
            CharacterClassMapper.MapModelToEntity(characterClass, originalCharacterClass);
            originalCharacterClass.ModifiedBy = "TEST";
            var updatedCharacterClass = _characterClassRepository.Update(originalCharacterClass);
            return CharacterClassMapper.MapEntityToModel(updatedCharacterClass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteClass(int id)
        {
            _characterClassRepository.Delete(id);
        }

        /// <summary>
        /// Reseed the character class table from the json text file
        /// </summary>
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
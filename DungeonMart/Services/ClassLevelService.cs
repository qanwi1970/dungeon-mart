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
    public class ClassLevelService : IClassLevelService
    {
        private readonly IClassProgressionRepository _classProgressionRepository;

        public ClassLevelService(IClassProgressionRepository classProgressionRepository)
        {
            _classProgressionRepository = classProgressionRepository;
        }

        public IQueryable<ClassLevelViewModel> GetClassLevels()
        {
            return _classProgressionRepository.GetAll().Select(ClassLevelMapper.MapEntityToModel).AsQueryable();
        }

        public ClassLevelViewModel GetClassLevelById(int id)
        {
            return ClassLevelMapper.MapEntityToModel(_classProgressionRepository.GetById(id));
        }

        public ClassLevelViewModel AddClassLevel(ClassLevelViewModel classLevel)
        {
            var classLevelEntity = ClassLevelMapper.MapModelToEntity(classLevel);
            classLevelEntity.CreatedBy = "TEST";
            classLevelEntity.SeedData = false;
            var addedClassLevel = _classProgressionRepository.Add(classLevelEntity);
            return ClassLevelMapper.MapEntityToModel(addedClassLevel);
        }

        public ClassLevelViewModel UpdateClassLevel(int id, ClassLevelViewModel classLevel)
        {
            var originalClassLevel = _classProgressionRepository.GetById(id);
            ClassLevelMapper.MapModelToEntity(classLevel, originalClassLevel);
            originalClassLevel.ModifiedBy = "TEST";
            var updatedClassLevel = _classProgressionRepository.Update(originalClassLevel);
            return ClassLevelMapper.MapEntityToModel(updatedClassLevel);
        }

        public void DeleteClassLevel(int id)
        {
            _classProgressionRepository.Delete(id);
        }

        public void SeedClassLevel(string seedDataPath)
        {
            ClassLevelSeed[] classArray;
            using (var classStream = new StreamReader(seedDataPath + "/classtable.json"))
            {
                classArray = JsonConvert.DeserializeObject<ClassLevelSeed[]>(classStream.ReadToEnd());
            }
            foreach (var classLevelSeed in classArray)
            {
                var dbClass = _classProgressionRepository.GetById(classLevelSeed.Id);
                if (dbClass == null)
                {
                    var newClass = ClassLevelMapper.MapSeedToEntity(classLevelSeed);
                    newClass.CreatedBy = "SeedClassLevel";
                    newClass.SeedData = true;
                    _classProgressionRepository.Add(newClass);
                }
                else
                {
                    ClassLevelMapper.MapSeedToEntity(classLevelSeed, dbClass);
                    dbClass.ModifiedBy = "SeedClassLevel";
                    _classProgressionRepository.Update(dbClass);
                }
            }
        }
    }
}
using System;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.Services
{
    public class ClassLevelService : IClassLevelService
    {
        private readonly IClassProgressionRepository _classProgressionRepository;

        public ClassLevelService(IClassProgressionRepository classProgressionRepository)
        {
            _classProgressionRepository = classProgressionRepository;
        }

        public IQueryable<ClassLevel> GetClassLevels()
        {
            return _classProgressionRepository.GetAll().Select(ClassLevelMapper.MapEntityToModel).AsQueryable();
        }

        public ClassLevel GetClassLevelById(int id)
        {
            return ClassLevelMapper.MapEntityToModel(_classProgressionRepository.GetById(id));
        }

        public ClassLevel AddClassLevel(ClassLevel classLevel)
        {
            var classLevelEntity = ClassLevelMapper.MapModelToEntity(classLevel);
            classLevelEntity.CreatedBy = "TEST";
            var addedClassLevel = _classProgressionRepository.Add(classLevelEntity);
            return ClassLevelMapper.MapEntityToModel(addedClassLevel);
        }

        public ClassLevel UpdateClassLevel(int id, ClassLevel classLevel)
        {
            var classLevelEntity = ClassLevelMapper.MapModelToEntity(classLevel);
            var originalClassLevel = _classProgressionRepository.GetById(id);
            classLevelEntity.CreatedBy = originalClassLevel.CreatedBy;
            classLevelEntity.CreatedDate = originalClassLevel.CreatedDate;
            classLevelEntity.ModifiedBy = "TEST";
            var updatedClassLevel = _classProgressionRepository.Update(classLevelEntity);
            return ClassLevelMapper.MapEntityToModel(updatedClassLevel);
        }

        public void DeleteClassLevel(int id)
        {
            _classProgressionRepository.Delete(id);
        }
    }
}
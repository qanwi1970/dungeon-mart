using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class ClassLevelMapper
    {
        static ClassLevelMapper()
        {
            Mapper.CreateMap<ClassLevel, ClassProgressionEntity>();
            Mapper.CreateMap<ClassProgressionEntity, ClassLevel>();
        }

        public static ClassLevel MapEntityToModel(ClassProgressionEntity classProgressionEntity)
        {
            return Mapper.Map<ClassLevel>(classProgressionEntity);
        }

        public static ClassProgressionEntity MapModelToEntity(ClassLevel classLevel)
        {
            return Mapper.Map<ClassProgressionEntity>(classLevel);
        }
    }
}
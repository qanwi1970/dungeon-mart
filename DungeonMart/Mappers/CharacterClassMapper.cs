using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class CharacterClassMapper
    {
        static CharacterClassMapper()
        {
            Mapper.CreateMap<CharacterClassEntity, CharacterClass>();
            Mapper.CreateMap<CharacterClass, CharacterClassEntity>();
        }

        public static CharacterClass MapEntityToModel(CharacterClassEntity entity)
        {
            return Mapper.Map<CharacterClass>(entity);
        }

        public static CharacterClassEntity MapModelToEntity(CharacterClass characterClass)
        {
            return Mapper.Map<CharacterClassEntity>(characterClass);
        }
    }
}
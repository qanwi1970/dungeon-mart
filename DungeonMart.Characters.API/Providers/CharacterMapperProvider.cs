using System;
using DungeonMart.Characters.API.Mappers;
using DungeonMart.Characters.API.Models;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Providers
{
    public interface ICharacterMapperProvider
    {
        ICharacterMapper GetCharacterMapper(GameSystem gameSystem);
        ICharacterMapper GetCharacterMapper(BsonDocument characterBsonDocument);
        ICharacterMapper GetCharacterMapper(BaseCharacterViewModel character);
    }

    public class CharacterMapperProvider : ICharacterMapperProvider
    {
        private readonly ICharacterMapper _dnd35Mapper = new Dnd35Mapper();
        private readonly ICharacterMapper _dnd5Mapper = new Dnd5Mapper();

        public ICharacterMapper GetCharacterMapper(BsonDocument characterBsonDocument)
        {
            var gameSystemString = characterBsonDocument.GetValue("system").AsString;
            var gameSystem = (GameSystem)Enum.Parse(typeof(GameSystem), gameSystemString);
            return GetCharacterMapper(gameSystem);
        }

        public ICharacterMapper GetCharacterMapper(BaseCharacterViewModel characterViewModel)
        {
            return GetCharacterMapper(characterViewModel.System);
        }

        public ICharacterMapper GetCharacterMapper(GameSystem gameSystem)
        {
            switch (gameSystem)
            {
                case GameSystem.Dnd35:
                    return _dnd35Mapper;
                case GameSystem.Dnd5:
                    return _dnd5Mapper;
                default:
                    throw new Exception("Mapper not defined for this game system.");
            }
        }
    }
}
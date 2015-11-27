using DungeonMart.Characters.API.Models;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Mappers
{
    public class Dnd5Mapper : ICharacterMapper
    {
        public BaseCharacterViewModel MapDocumentToViewModel(BsonDocument character)
        {
            var newModel = new BaseCharacterViewModel
            {
                System = GameSystem.Dnd5,
                CharacterID = character.GetValue("_id").AsObjectId.ToString(),
                CharacterName = character.GetValue("characterName").AsString,
                IsShared = character.GetValue("isShared").AsBoolean
            };

            return newModel;
        }

        public BsonDocument MapViewModelToDocument(BaseCharacterViewModel character)
        {
            var bsonCharacter = new BsonDocument
            {
                { "characterName", character.CharacterName },
                { "isShared", character.IsShared },
                { "system", character.System.ToString() }
            };

            if (character.CharacterID != null)
            {
                var objectId = ObjectId.Parse(character.CharacterID);
                bsonCharacter.Add(new BsonElement("_id", objectId));
            }

            return bsonCharacter;
        }
    }
}
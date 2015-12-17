using DungeonMart.Characters.API.Mappers.Interfaces;
using DungeonMart.Characters.API.Models;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Mappers
{
    public class Dnd35Mapper : IDnd35Mapper
    {
        public Dnd35CharacterViewModel MapDocumentToViewModel(BsonDocument character)
        {
            var newModel = new Dnd35CharacterViewModel
            {
                System = GameSystem.Dnd35,
                CharacterID = character.GetValue("_id").AsObjectId.ToString(),
                CharacterName = character.GetValue("characterName").AsString,
                IsShared = character.GetValue("isShared").AsBoolean
            };

            return newModel;
        }

        public BsonDocument MapViewModelToDocument(Dnd35CharacterViewModel character)
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
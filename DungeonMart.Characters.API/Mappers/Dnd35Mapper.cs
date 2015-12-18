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
            BsonValue classesArray;
            if (character.TryGetValue("classes", out classesArray))
            {
                foreach (var bsonValue in (BsonArray)classesArray)
                {
                    var classLevel = (BsonDocument) bsonValue;
                    newModel.Classes.Add(new Dnd35CharacterViewModel.ClassLevel
                    {
                        ClassName = classLevel.GetValue("className").AsString,
                        Level = classLevel.GetValue("level").AsNullableInt32
                    });
                }
            }
            BsonValue ecl;
            if (character.TryGetValue("ecl", out ecl))
            {
                newModel.Ecl = ecl.AsNullableInt32;
            }

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

            var classes = new BsonArray();
            foreach (var classLevel in character.Classes)
            {
                classes.Add(new BsonDocument
                {
                    {"className", classLevel.ClassName},
                    {"level", classLevel.Level }
                });
            }
            bsonCharacter.Add(new BsonElement("classes", classes));

            bsonCharacter.Add("ecl", () => new BsonInt32(character.Ecl.Value), character.Ecl.HasValue);

            if (character.CharacterID != null)
            {
                var objectId = ObjectId.Parse(character.CharacterID);
                bsonCharacter.Add(new BsonElement("_id", objectId));
            }

            return bsonCharacter;
        }
    }
}
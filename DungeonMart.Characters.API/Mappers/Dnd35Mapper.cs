using System.Collections.Generic;
using DungeonMart.Characters.API.Mappers.Interfaces;
using DungeonMart.Characters.API.Models;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Mappers
{
    public class Dnd35Mapper : BsonMapper, IDnd35Mapper
    {
        private const string characterName = nameof(characterName);
        private const string isShared = nameof(isShared);
        private const string classes = nameof(classes);
        private const string className = nameof(className);
        private const string level = nameof(level);
        private const string system = nameof(system);
        private const string ecl = nameof(ecl);
        private const string race = nameof(race);
        private const string alignment = nameof(alignment);
        private const string diety = nameof(diety);
        private const string size = nameof(size);
        private const string age = nameof(age);
        private const string gender = nameof(gender);
        private const string height = nameof(height);
        private const string weight = nameof(weight);
        private const string eyes = nameof(eyes);
        private const string hair = nameof(hair);
        private const string skin = nameof(skin);
        private const string strength = nameof(strength);
        private const string dexterity = nameof(dexterity);
        private const string constitution = nameof(constitution);
        private const string intelligence = nameof(intelligence);
        private const string wisdom = nameof(wisdom);
        private const string charisma = nameof(charisma);
        private const string score = nameof(score);
        private const string modifier = nameof(modifier);

        public Dnd35CharacterViewModel MapDocumentToViewModel(BsonDocument character)
        {
            var newModel = new Dnd35CharacterViewModel
            {
                System = GameSystem.Dnd35,
                CharacterID = character.GetValue("_id").AsObjectId.ToString(),
                CharacterName = character.GetValue(characterName).AsString,
                IsShared = character.GetValue(isShared).AsBoolean
            };
            BsonValue classesArray;
            if (character.TryGetValue(classes, out classesArray))
            {
                foreach (var bsonValue in (BsonArray)classesArray)
                {
                    var classLevel = (BsonDocument) bsonValue;
                    newModel.Classes.Add(new Dnd35CharacterViewModel.ClassLevel
                    {
                        ClassName = classLevel.GetValue(className).AsString,
                        Level = classLevel.GetValue(level).AsNullableInt32
                    });
                }
            }
            newModel.Ecl = MapValue(character, ecl, newModel.Ecl);
            newModel.Race = MapValue(character, race, newModel.Race);
            newModel.Alignment = MapValue(character, alignment, newModel.Alignment);
            newModel.Diety = MapValue(character, diety, newModel.Diety);
            newModel.Size = MapValue(character, size, newModel.Size);
            newModel.Age = MapValue(character, age, newModel.Age);
            newModel.Gender = MapValue(character, gender, newModel.Gender);
            newModel.Height = MapValue(character, height, newModel.Height);
            newModel.Weight = MapValue(character, weight, newModel.Weight);
            newModel.Eyes = MapValue(character, eyes, newModel.Eyes);
            newModel.Hair = MapValue(character, hair, newModel.Hair);
            newModel.Skin = MapValue(character, skin, newModel.Skin);
            newModel.Strength = MapValue(character, strength, newModel.Strength);
            newModel.Dexterity = MapValue(character, dexterity, newModel.Dexterity);
            newModel.Constitution = MapValue(character, constitution, newModel.Constitution);
            newModel.Intelligence = MapValue(character, intelligence, newModel.Intelligence);
            newModel.Wisdom = MapValue(character, wisdom, newModel.Wisdom);
            newModel.Charisma = MapValue(character, charisma, newModel.Charisma);

            return newModel;
        }

        public BsonDocument MapViewModelToDocument(Dnd35CharacterViewModel character)
        {
            var bsonCharacter = new BsonDocument
            {
                { characterName, character.CharacterName },
                { isShared, character.IsShared },
                { system, character.System.ToString() }
            };

            var classesArray = new BsonArray();
            foreach (var classLevel in character.Classes)
            {
                classesArray.Add(new BsonDocument
                {
                    {className, classLevel.ClassName},
                    {level, classLevel.Level }
                });
            }
            bsonCharacter.Add(new BsonElement(classes, classesArray));

            MapValue(character.Ecl, bsonCharacter, ecl);
            MapValue(character.Race, bsonCharacter, race);
            MapValue(character.Alignment, bsonCharacter, alignment);
            MapValue(character.Diety, bsonCharacter, diety);
            MapValue(character.Size, bsonCharacter, size);
            MapValue(character.Age, bsonCharacter, age);
            MapValue(character.Gender, bsonCharacter, gender);
            MapValue(character.Height, bsonCharacter, height);
            MapValue(character.Weight, bsonCharacter, weight);
            MapValue(character.Eyes, bsonCharacter, eyes);
            MapValue(character.Hair, bsonCharacter, hair);
            MapValue(character.Skin, bsonCharacter, skin);
            MapValue(character.Strength, bsonCharacter, strength);
            MapValue(character.Dexterity, bsonCharacter, dexterity);
            MapValue(character.Constitution, bsonCharacter, constitution);
            MapValue(character.Intelligence, bsonCharacter, intelligence);
            MapValue(character.Wisdom, bsonCharacter, wisdom);
            MapValue(character.Charisma, bsonCharacter, charisma);

            if (character.CharacterID != null)
            {
                var objectId = ObjectId.Parse(character.CharacterID);
                bsonCharacter.Add(new BsonElement("_id", objectId));
            }

            return bsonCharacter;
        }

        protected Dnd35CharacterViewModel.Ability MapValue(BsonDocument document, string field, Dnd35CharacterViewModel.Ability dontCare)
        {
            Dnd35CharacterViewModel.Ability ability = null;
            BsonValue bsonValue;
            if (document.TryGetValue(field, out bsonValue) && bsonValue.IsBsonDocument)
            {
                var abilityDocument = bsonValue.AsBsonDocument;
                ability = new Dnd35CharacterViewModel.Ability
                {
                    Score = MapValue(abilityDocument, score, 0),
                    Modifier = MapValue(abilityDocument, modifier, 0)
                };
            }
            return ability;
        }

        private void MapValue(Dnd35CharacterViewModel.Ability ability, BsonDocument bsonDocument, string field)
        {
            bsonDocument.Add(field, () => new BsonDocument(new Dictionary<string, object>
            {
                {score, ability.Score},
                {modifier, ability.Modifier}
            }), ability != null);
        }
    }
}
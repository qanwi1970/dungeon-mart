using DungeonMart.Characters.API.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMart.Characters.API.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private static IMongoCollection<BsonDocument> _collection;

        public CharacterRepository()
        {
            IMongoClient client = new MongoClient();
            var database = client.GetDatabase("test");
            _collection = database.GetCollection<BsonDocument>("characters");
        }

        public async Task<List<BsonDocument>> GetCharacters(string user)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("owner", user);
			return await _collection.Find(filter).ToListAsync();
        }

        public async Task<BsonDocument> GetCharacter(ObjectId objectId, string userName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId) &
                         Builders<BsonDocument>.Filter.Eq("owner", userName);
	        var characterCollection = await _collection.Find(filter).ToListAsync();
            return characterCollection.FirstOrDefault();
        }

        public async Task<BsonDocument> AddCharacter(BsonDocument character)
        {
            await _collection.InsertOneAsync(character);
            return character;
        }

        public async Task<BsonDocument> UpdateCharacter(BsonDocument character, string userName)
        {
            var characterObjectId = extractCharacterObjectId(character);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", characterObjectId) &
                         Builders<BsonDocument>.Filter.Eq("owner", userName);

            // Now that we have the id in the proper format, we can delete it.
            // This is easier than converting it. If we leave it a BsonValue, Mongo will throw an error
            character.Remove("_id");
            var result = await _collection.ReplaceOneAsync(filter, character);
            if (result.IsAcknowledged && result.ModifiedCount == 1)
            {
                return character;
            }
            else
            {
                // This probably means that the character wasn't found
                throw new ArgumentException("No updates were made. Check that the characterID is correct.");
            }
        }

        public async Task DeleteCharacter(ObjectId characterObjectId, string userName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", characterObjectId) &
                         Builders<BsonDocument>.Filter.Eq("owner", userName);
            var result = await _collection.DeleteOneAsync(filter);
            if (!result.IsAcknowledged || result.DeletedCount != 1)
            {
                // This probably means that the character wasn't found
                throw new ArgumentException("No deletes were made. Check that the characterID is correct.");
            }
        }

        private ObjectId extractCharacterObjectId(BsonDocument character)
        {
            // Get the Id from the document
            BsonValue characterId;
            if (!character.TryGetValue("_id", out characterId))
            {
                throw new ArgumentException("Document does not contain an _id.");
            }

            // If it's already an ObjectId, return it
            if (characterId.BsonType == BsonType.ObjectId)
            {
                return characterId.AsObjectId;
            }

            // Try to parse it from a string to an ObjectId
            ObjectId characterObjectId;
            if (!ObjectId.TryParse(characterId.AsString, out characterObjectId))
            {
                throw new ArgumentException("The character id is not of the proper format.");
            }
            return characterObjectId;
        }
    }
}
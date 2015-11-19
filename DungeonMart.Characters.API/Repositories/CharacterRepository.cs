using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMart.Characters.API.Repositories
{
    public class CharacterRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<BsonDocument> _collection;

        public CharacterRepository()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("test");
            _collection = _database.GetCollection<BsonDocument>("characters");
        }

        public async Task<List<BsonDocument>> GetCharacters()
        {
			return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<BsonDocument> GetCharacter(ObjectId objectId)
        {
	        var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
	        var characterCollection = await _collection.Find(filter).ToListAsync();
	        return characterCollection.First();
        }

        public async Task<BsonDocument> AddCharacter(BsonDocument character)
        {
            await _collection.InsertOneAsync(character);
            return character;
        }

        public void UpdateCharacter(BsonDocument character)
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(BsonDocument character)
        {
            throw new NotImplementedException();
        }
    }
}
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DungeonMart.Characters.API.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Task<List<BsonDocument>> GetCharacters();
        Task<BsonDocument> GetCharacter(ObjectId objectId);
        Task<BsonDocument> AddCharacter(BsonDocument character);
        Task<BsonDocument> UpdateCharacter(BsonDocument character);
        Task DeleteCharacter(ObjectId characterObjectId);
    }
}

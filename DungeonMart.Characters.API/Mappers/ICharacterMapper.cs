using DungeonMart.Characters.API.Models;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Mappers
{
    public interface ICharacterMapper
    {
        BaseCharacterViewModel MapDocumentToViewModel(BsonDocument character);
    }
}

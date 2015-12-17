using DungeonMart.Characters.API.Models;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Mappers.Interfaces
{
    public interface IDnd35Mapper
    {
        Dnd35CharacterViewModel MapDocumentToViewModel(BsonDocument character);
        BsonDocument MapViewModelToDocument(Dnd35CharacterViewModel character);
    }
}

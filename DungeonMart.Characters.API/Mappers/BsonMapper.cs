using DungeonMart.Characters.API.Models;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Mappers
{
    public abstract class BsonMapper
    {
        protected int? MapValue(BsonDocument document, string field, int? dontCare)
        {
            int? intValue = default(int?);
            BsonValue bsonField;
            if (document.TryGetValue(field, out bsonField))
            {
                intValue = bsonField.AsNullableInt32;
            }
            return intValue;
        }

        protected string MapValue(BsonDocument document, string field, string dontCare)
        {
            string stringValue = default(string);
            BsonValue bsonField;
            if (document.TryGetValue(field, out bsonField))
            {
                stringValue = bsonField.AsString;
            }
            return stringValue;
        }

        protected void MapValue(string value, BsonDocument document, string field)
        {
            document.Add(field, () => new BsonString(value), !string.IsNullOrWhiteSpace(value));
        }

        protected void MapValue(int? value, BsonDocument document, string field)
        {
            document.Add(field, () => new BsonInt32(value.GetValueOrDefault()), value.HasValue);
        }
    }
}
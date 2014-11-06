using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace DungeonMart.Data.DocumentDB
{
    public class EquipmentDocDbRepository : IEquipmentRepository
    {
        private const string CollectionName = "equipment";

        private readonly IDocumentDBProperties _properties;

        private readonly DocumentClient _client;

        public EquipmentDocDbRepository()
        {
            _properties = new DocumentDBProperties();
            _client = new DocumentClient(new Uri(_properties.Location), _properties.Key);
        }

        public EquipmentDocDbRepository(IDocumentDBProperties properties)
        {
            _properties = properties;
            _client = new DocumentClient(new Uri(_properties.Location), _properties.Key);
        }

        public async Task<IEnumerable<Equipment>> GetEquipmentsAsync()
        {
            var collection = await _client.GetOrCreateDocumentCollectionAsync(_properties.DatabaseId, CollectionName);
            return _client.CreateDocumentQuery<Equipment>(collection.DocumentsLink).AsEnumerable();
        }

        public async Task<Equipment> GetEquipmentByIdAsync(string id)
        {
            var collection = await _client.GetOrCreateDocumentCollectionAsync(_properties.DatabaseId, CollectionName);
            return _client.CreateDocumentQuery<Equipment>(collection.DocumentsLink).AsEnumerable().First(d => d.id == id);
        }

        public async Task<Equipment> AddEquipmentAsync(Equipment equipment)
        {
            var collection = await _client.GetOrCreateDocumentCollectionAsync(_properties.DatabaseId, CollectionName);
            var result = await _client.CreateDocumentAsync(collection.DocumentsLink, equipment);
            dynamic doc = result.Resource;
            Equipment addedEquipment = doc;
            return addedEquipment;
        }

        public async Task<Equipment> UpdateEquipmentAsync(string id, Equipment equipment)
        {
            var collection = await _client.GetOrCreateDocumentCollectionAsync(_properties.DatabaseId, CollectionName);
            var doc = _client.CreateDocumentQuery(collection.DocumentsLink).AsEnumerable().First(d => d.Id == id);
            var result = await _client.ReplaceDocumentAsync(doc.SelfLink, equipment);
            dynamic updatedDoc = result.Resource;
            Equipment updatedEquipment = updatedDoc;
            return updatedEquipment;
        }

        public async Task DeleteEquipmentAsync(string id)
        {
            var collection = await _client.GetOrCreateDocumentCollectionAsync(_properties.DatabaseId, CollectionName);
            var doc = _client.CreateDocumentQuery(collection.DocumentsLink).AsEnumerable().First(d => d.Id == id);
            await _client.DeleteDocumentAsync(doc.SelfLink);
        }
    }
}

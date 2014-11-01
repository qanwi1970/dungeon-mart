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

        private static readonly DocumentDBProperties Properties = new DocumentDBProperties();

        private static readonly DocumentClient Client = new DocumentClient(new Uri(Properties.Location), Properties.Key);

        public async Task<IEnumerable<Equipment>> GetEquipments()
        {
            var collection = await Client.GetOrCreateDocumentCollectionAsync(Properties.DatabaseId, CollectionName);
            return Client.CreateDocumentQuery<Equipment>(collection.DocumentsLink).AsEnumerable();
        }

        public async Task<Equipment> GetEquipmentById(string id)
        {
            var collection = await Client.GetOrCreateDocumentCollectionAsync(Properties.DatabaseId, CollectionName);
            return Client.CreateDocumentQuery<Equipment>(collection.DocumentsLink).AsEnumerable().First(d => d.id == id);
        }

        public async Task<Equipment> AddEquipment(Equipment equipment)
        {
            var collection = await Client.GetOrCreateDocumentCollectionAsync(Properties.DatabaseId, CollectionName);
            var result = await Client.CreateDocumentAsync(collection.DocumentsLink, equipment);
            dynamic doc = result.Resource;
            Equipment addedEquipment = doc;
            return addedEquipment;
        }

        public async Task<Equipment> UpdateEquipment(string id, Equipment equipment)
        {
            var collection = await Client.GetOrCreateDocumentCollectionAsync(Properties.DatabaseId, CollectionName);
            var doc = Client.CreateDocumentQuery(collection.DocumentsLink).AsEnumerable().First(d => d.Id == id);
            var result = await Client.ReplaceDocumentAsync(doc.SelfLink, equipment);
            dynamic updatedDoc = result.Resource;
            Equipment updatedEquipment = updatedDoc;
            return updatedEquipment;
        }

        public async Task DeleteEquipment(string id)
        {
            var collection = await Client.GetOrCreateDocumentCollectionAsync(Properties.DatabaseId, CollectionName);
            var doc = Client.CreateDocumentQuery(collection.DocumentsLink).AsEnumerable().First(d => d.Id == id);
            await Client.DeleteDocumentAsync(doc.SelfLink);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace DungeonMart.Data.DocumentDB
{
    public class EquipmentDocDbRepository : IEquipmentRepository
    {
        private static readonly DocumentDBProperties Properties = new DocumentDBProperties();

        private static readonly DocumentClient Client = new DocumentClient(new Uri(Properties.Location), Properties.Key);

        private static readonly string CollectionLink =
            Client.GetOrCreateDocumentCollectionAsync("dmart", "equipment").Result.DocumentsLink;

        public IEnumerable<Equipment> GetEquipments()
        {
            return Client.CreateDocumentQuery<Equipment>(CollectionLink).AsEnumerable();
        }

        public Equipment GetEquipmentById(string id)
        {
            return Client.CreateDocumentQuery<Equipment>(CollectionLink).First(d => d.id == id);
        }

        public async Task<Equipment> AddEquipment(Equipment equipment)
        {
            var result = await Client.CreateDocumentAsync(DocumentLink, equipment);
            dynamic doc = result.Resource;
            Equipment addedEquipment = doc;
            return addedEquipment;
        }

        public async Task<Equipment> UpdateEquipment(string id, Equipment equipment)
        {
            var doc = Client.CreateDocumentQuery(DocumentLink).AsEnumerable().First(d => d.Id == id);
            var result = await Client.ReplaceDocumentAsync(doc.SelfLink, equipment);
            dynamic updatedDoc = result.Resource;
            Equipment updatedEquipment = updatedDoc;
            return updatedEquipment;
        }

        public async Task DeleteEquipment(string id)
        {
            var doc = Client.CreateDocumentQuery(DocumentLink).AsEnumerable().First(d => d.Id == id);
            await Client.DeleteDocumentAsync(doc.SelfLink);
        }
    }
}

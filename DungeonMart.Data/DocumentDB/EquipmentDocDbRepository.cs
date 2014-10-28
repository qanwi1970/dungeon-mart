using System;
using System.Collections.Generic;
using System.Linq;
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

        public Equipment AddEquipment(Equipment equipment)
        {
            dynamic doc = Client.CreateDocumentAsync(CollectionLink, equipment).Result.Resource;
            Equipment result = doc;
            return result;
        }

        public Equipment UpdateEquipment(string id, Equipment equipment)
        {
            var doc = Client.CreateDocumentQuery(CollectionLink).AsEnumerable().First(d => d.Id == id);
            dynamic updatedDoc = Client.ReplaceDocumentAsync(doc.SelfLink, equipment).Result.Resource;
            Equipment result = updatedDoc;
            return result;
        }

        public void DeleteEquipment(string id)
        {
            var doc = Client.CreateDocumentQuery(CollectionLink).AsEnumerable().First(d => d.Id == id);
            Client.DeleteDocumentAsync(doc.SelfLink);
        }
    }
}

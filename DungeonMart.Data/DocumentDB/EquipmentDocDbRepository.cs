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

        private static readonly string DocumentLink =
            Client.GetOrCreateDocumentCollectionAsync("dmart", "equipment").Result.DocumentsLink;

        public IEnumerable<Equipment> GetEquipments()
        {
            return Client.CreateDocumentQuery<Equipment>(DocumentLink).AsEnumerable();
        }

        public Equipment GetEquipmentById(string id)
        {
            return Client.CreateDocumentQuery<Equipment>(DocumentLink).First(d => d.id == id);
        }

        public Equipment AddEquipment(Equipment equipment)
        {
            dynamic doc = Client.CreateDocumentAsync(DocumentLink, equipment).Result.Resource;
            Equipment result = doc;
            return result;
        }

        public Equipment UpdateEquipment(string id, Equipment equipment)
        {
            var doc = Client.CreateDocumentQuery<Document>(DocumentLink).AsEnumerable().First(d => d.Id == id);
            dynamic updatedDoc = Client.ReplaceDocumentAsync(doc.SelfLink, equipment).Result.Resource;
            Equipment result = updatedDoc;
            return result;
        }

        public void DeleteEquipment(string id)
        {
            var doc = Client.CreateDocumentQuery(DocumentLink).AsEnumerable().First(d => d.Id == id);
            Client.DeleteDocumentAsync(doc.SelfLink);
        }
    }
}

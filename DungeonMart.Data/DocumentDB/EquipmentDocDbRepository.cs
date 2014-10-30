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

        private readonly string _collectionLink;

        public EquipmentDocDbRepository()
        {
            _collectionLink = EquipmentCollection.Instance.Collection.DocumentsLink;
        }

        public IEnumerable<Equipment> GetEquipments()
        {
            return Client.CreateDocumentQuery<Equipment>(_collectionLink).AsEnumerable();
        }

        public Equipment GetEquipmentById(string id)
        {
            return Client.CreateDocumentQuery<Equipment>(_collectionLink).First(d => d.id == id);
        }

        public async Task<Equipment> AddEquipment(Equipment equipment)
        {
            var result = await Client.CreateDocumentAsync(_collectionLink, equipment);
            dynamic doc = result.Resource;
            Equipment addedEquipment = doc;
            return addedEquipment;
        }

        public async Task<Equipment> UpdateEquipment(string id, Equipment equipment)
        {
            var doc = Client.CreateDocumentQuery(_collectionLink).AsEnumerable().First(d => d.Id == id);
            var result = await Client.ReplaceDocumentAsync(doc.SelfLink, equipment);
            dynamic updatedDoc = result.Resource;
            Equipment updatedEquipment = updatedDoc;
            return updatedEquipment;
        }

        public async Task DeleteEquipment(string id)
        {
            var doc = Client.CreateDocumentQuery(_collectionLink).AsEnumerable().First(d => d.Id == id);
            await Client.DeleteDocumentAsync(doc.SelfLink);
        }

        private class EquipmentCollection
        {
            private static readonly Lazy<EquipmentCollection> LazyMe =
                new Lazy<EquipmentCollection>(() => new EquipmentCollection());

            public DocumentCollection Collection { get; private set; }

            private EquipmentCollection()
            {
                Collection = Client.GetOrCreateDocumentCollectionAsync("dmart", "equipment").Result;
            }

            public static EquipmentCollection Instance { get { return LazyMe.Value; } }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMart.Data.DocumentDB;
using DungeonMart.Data.Models;
using Microsoft.Azure.Documents.Client;
using Moq;
using NUnit.Framework;

namespace DungeonMart.Data.Tests.DocumentDB
{
    [TestFixture]
    public class EquipmentDocDbRepoTests
    {
        private EquipmentDocDbRepository repo;
        private MockDocumentDbProperties _properties;

        [SetUp]
        public void Setup()
        {
            _properties = new MockDocumentDbProperties
            {
                Location = ConfigurationManager.AppSettings["DocDbLocation"],
                Key = ConfigurationManager.AppSettings["DocDbKey"],
                DatabaseId = "dmart_test_" + Guid.NewGuid()
            };
            repo = new EquipmentDocDbRepository(_properties);
        }

        [TearDown]
        public void TearDown()
        {
            var client = new DocumentClient(new Uri(_properties.Location), _properties.Key);
            var databaseLink = client.GetOrCreateDatabaseAsync(_properties.DatabaseId).Result.SelfLink;
            var deleteResult = client.DeleteDatabaseAsync(databaseLink).Result;
        }

        [Test]
        public async void Add_GetAll_GetById()
        {
            var equipment = new Equipment
            {
                Name = "Test"
            };
            var addedEquipment = await repo.AddEquipmentAsync(equipment);
            var newId = addedEquipment.id;
            Assert.AreEqual("Test", addedEquipment.Name);

            var equipmentList = await repo.GetEquipmentsAsync();
            Assert.AreEqual(1, equipmentList.Count());

            var retrievedEquipment = await repo.GetEquipmentByIdAsync(newId);
            Assert.AreEqual("Test", retrievedEquipment.Name);
        }
    }
}

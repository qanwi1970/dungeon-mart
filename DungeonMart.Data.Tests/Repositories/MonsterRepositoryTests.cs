using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Models;
using DungeonMart.Data.Repositories;
using NUnit.Framework;

namespace DungeonMart.Data.Tests.Repositories
{
    [TestFixture]
    public class MonsterRepositoryTests : BaseTest
    {
        private MonsterRepository _repository;

        public MonsterRepositoryTests()
        {
            Initializer = new MonsterRepositoryTestInitializer();
        }

        internal class MonsterRepositoryTestInitializer : DropCreateDatabaseAlways<DungeonMartContext>
        {
            protected override void Seed(DungeonMartContext context)
            {
                context.Monsters.Add(new Monster
                {
                    CreatedBy = "Seed",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Seed",
                    ModifiedDate = DateTime.UtcNow
                });
                // Don't do the whole Seed or each test will take 5 minutes
                //base.Seed(context);
            }
        }

        [SetUp]
        public void SetUp()
        {
            _repository = new MonsterRepository(UnitOfWork);
        }

        [Test]
        public void CreateReadUpdateDelete()
        {
            var newMonster = new Monster
            {
                Abilities = "Abilities",
                Advancement = "Advancement",
                CreatedBy = "CreateReadUpdateDelete"
            };
            var shouldBeNull = _repository.GetAll().FirstOrDefault(x => x.CreatedBy == "CreateReadUpdateDelete");
            Assert.IsNull(shouldBeNull);

            // Create
            var addedMonster = _repository.Add(newMonster);
            UnitOfWork.Commit();

            // Read
            var readMonster = _repository.GetById(addedMonster.Id);
            Assert.AreEqual("CreateReadUpdateDelete", readMonster.ModifiedBy);

            // Update
            readMonster.Alignment = "Alignment";
            var updatedMonster = _repository.Update(readMonster);
            Assert.AreEqual("Alignment", updatedMonster.Alignment);

            // Delete
            _repository.Delete(updatedMonster);
            UnitOfWork.Commit();
            shouldBeNull = _repository.GetAll().FirstOrDefault(x => x.CreatedBy == "CreateReadUpdateDelete");
            Assert.IsNull(shouldBeNull);
        }
    }
}

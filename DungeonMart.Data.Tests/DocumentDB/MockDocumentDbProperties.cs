using DungeonMart.Data.DocumentDB;

namespace DungeonMart.Data.Tests.DocumentDB
{
    class MockDocumentDbProperties : IDocumentDBProperties
    {
        public string Location { get; set; }
        public string Key { get; set; }
        public string DatabaseId { get; set; }
    }
}

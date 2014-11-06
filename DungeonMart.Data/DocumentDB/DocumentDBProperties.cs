using System.Configuration;

namespace DungeonMart.Data.DocumentDB
{
    public class DocumentDBProperties : IDocumentDBProperties
    {
        public string Location
        {
            get { return ConfigurationManager.AppSettings["DocDbLocation"]; }
        }

        public string Key
        {
            get { return ConfigurationManager.AppSettings["DocDbKey"]; }
        }

        public string DatabaseId
        {
            get { return ConfigurationManager.AppSettings["DocDbDatabaseId"]; }
        }
    }
}

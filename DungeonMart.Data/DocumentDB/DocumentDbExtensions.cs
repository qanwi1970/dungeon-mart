using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace DungeonMart.Data.DocumentDB
{
    internal static class DocumentDbExtensions
    {
        public static async Task<Database> GetOrCreateDatabaseAsync(this DocumentClient client, string databaseId)
        {
            Database[] databases = client.CreateDatabaseQuery().Where(db => db.Id == databaseId).ToArray();

            if (databases.Any())
            {
                return databases.First();
            }

            return await client.CreateDatabaseAsync(new Database {Id = databaseId});
        }

        public static async Task<DocumentCollection> GetOrCreateDocumentCollectionAsync(this DocumentClient client,
            string databaseId, string collectionId)
        {
            Database database = await GetOrCreateDatabaseAsync(client, databaseId);

            DocumentCollection[] collections =
                client.CreateDocumentCollectionQuery(database.SelfLink).Where(col => col.Id == collectionId).ToArray();

            if (collections.Any())
            {
                return collections.First();
            }

            return
                await
                    client.CreateDocumentCollectionAsync(database.SelfLink, new DocumentCollection {Id = collectionId});
        }
    }
}

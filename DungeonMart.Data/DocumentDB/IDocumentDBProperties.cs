namespace DungeonMart.Data.DocumentDB
{
    public interface IDocumentDBProperties
    {
        string Location { get; }
        string Key { get; }
        string DatabaseId { get; }
    }
}

using System.Linq;
using DungeonMart.Shared.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IFeatService
    {
        IQueryable<Feat> GetFeats();

        Feat GetFeatById(int id);

        Feat AddFeat(Feat feat);

        Feat PutFeat(int id, Feat feat);

        void DeleteFeat(int id);

        void SeedFeat(string seedDataPath);
    }
}

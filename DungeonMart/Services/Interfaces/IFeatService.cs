using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IFeatService
    {
        IQueryable<FeatViewModel> GetFeats();

        FeatViewModel GetFeatById(int id);

        FeatViewModel AddFeat(FeatViewModel feat);

        FeatViewModel PutFeat(int id, FeatViewModel feat);

        void DeleteFeat(int id);

        void SeedFeat(string seedDataPath);
    }
}

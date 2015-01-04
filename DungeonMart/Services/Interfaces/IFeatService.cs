using DungeonMart.Shared.Models;
using System.Linq;

namespace DungeonMart.Service.Interfaces
{
    public interface IFeatService
    {
        IQueryable<Feat> GetFeats();

        Feat GetFeatById(int id);

        Feat AddFeat(Feat feat);

        Feat PutFeat(int id, Feat feat);

        void DeleteFeat(int id);
    }
}

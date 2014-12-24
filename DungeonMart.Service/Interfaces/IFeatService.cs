using DungeonMart.Shared.Models;
using System.Linq;

namespace DungeonMart.Service.Interfaces
{
    public interface IFeatService
    {
        IQueryable<Feat> GetFeats();
    }
}

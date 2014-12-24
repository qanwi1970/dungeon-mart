using DungeonMart.Data.Interfaces;
using DungeonMart.Service.Interfaces;
using DungeonMart.Service.Mappers;
using DungeonMart.Shared.Models;
using System.Linq;

namespace DungeonMart.Service
{
    public class FeatService : IFeatService
    {
        private readonly IFeatRepository _featRepository;

        public FeatService(IFeatRepository featRepository)
        {
            _featRepository = featRepository;
        }

        public IQueryable<Feat> GetFeats()
        {
            return _featRepository.GetAll().Select(FeatMapper.MapEntityToModel).AsQueryable();
        }
    }
}

using System.IO;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class FeatService : IFeatService
    {
        private readonly IFeatRepository _featRepository;

        public FeatService(IFeatRepository featRepository)
        {
            _featRepository = featRepository;
        }

        public IQueryable<FeatViewModel> GetFeats()
        {
            return _featRepository.GetAll().Select(FeatMapper.MapEntityToModel).AsQueryable();
        }

        public FeatViewModel GetFeatById(int id)
        {
            return FeatMapper.MapEntityToModel(_featRepository.GetById(id));
        }

        public FeatViewModel AddFeat(FeatViewModel feat)
        {
            var featToAdd = FeatMapper.MapModelToEntity(feat);
            featToAdd.CreatedBy = "TEST";
            featToAdd.SeedData = false;
            var addedFeat = _featRepository.Add(featToAdd);
            return FeatMapper.MapEntityToModel(addedFeat);
        }

        public FeatViewModel PutFeat(int id, FeatViewModel feat)
        {
            var featToUpdate = _featRepository.GetById(id);
            FeatMapper.MapModelToEntity(feat, featToUpdate);
            featToUpdate.ModifiedBy = "TEST";
            var updatedFeat = _featRepository.Update(featToUpdate);
            return FeatMapper.MapEntityToModel(updatedFeat);
        }

        public void DeleteFeat(int id)
        {
            _featRepository.Delete(id);
        }

        public void SeedFeat(string seedDataPath)
        {
            FeatSeed[] featArray;
            using (var featStream = new StreamReader(seedDataPath + "/feat.json"))
            {
                featArray = JsonConvert.DeserializeObject<FeatSeed[]>(featStream.ReadToEnd());
            }
            foreach (var featSeed in featArray)
            {
                var featEntity = _featRepository.GetById(featSeed.Id);
                if (featEntity == null)
                {
                    var newFeat = FeatMapper.MapSeedToEntity(featSeed);
                    newFeat.CreatedBy = "SeedFeat";
                    newFeat.SeedData = true;
                    _featRepository.Add(newFeat);
                }
                else
                {
                    FeatMapper.MapSeedToEntity(featSeed, featEntity);
                    featEntity.ModifiedBy = "SeedFeat";
                    _featRepository.Update(featEntity);
                }
            }
        }
    }
}

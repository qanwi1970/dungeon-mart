using System.IO;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Services.Interfaces;
using DungeonMart.Shared.Models;
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

        public IQueryable<Feat> GetFeats()
        {
            return _featRepository.GetAll().Select(FeatMapper.MapEntityToModel).AsQueryable();
        }

        public Feat GetFeatById(int id)
        {
            return FeatMapper.MapEntityToModel(_featRepository.GetById(id));
        }

        public Feat AddFeat(Feat feat)
        {
            var featToAdd = FeatMapper.MapModelToEntity(feat);
            featToAdd.CreatedBy = "TEST";
            var addedFeat = _featRepository.Add(featToAdd);
            return FeatMapper.MapEntityToModel(addedFeat);
        }

        public Feat PutFeat(int id, Feat feat)
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

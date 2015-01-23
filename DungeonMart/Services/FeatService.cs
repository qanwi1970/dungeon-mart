using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Service.Interfaces;
using DungeonMart.Service.Mappers;
using DungeonMart.Shared.Models;

namespace DungeonMart.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class FeatService : IFeatService
    {
        private readonly IFeatRepository _featRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featRepository"></param>
        public FeatService(IFeatRepository featRepository)
        {
            _featRepository = featRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Feat> GetFeats()
        {
            return _featRepository.GetAll().Select(FeatMapper.MapEntityToModel).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Feat GetFeatById(int id)
        {
            return FeatMapper.MapEntityToModel(_featRepository.GetById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feat"></param>
        /// <returns></returns>
        public Feat AddFeat(Feat feat)
        {
            var featToAdd = FeatMapper.MapModelToEntity(feat);
            featToAdd.CreatedBy = "TEST";
            var addedFeat = _featRepository.Add(featToAdd);
            return FeatMapper.MapEntityToModel(addedFeat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="feat"></param>
        /// <returns></returns>
        public Feat PutFeat(int id, Feat feat)
        {
            var featToUpdate = _featRepository.GetById(id);
            featToUpdate.Benefit = feat.Benefit;
            featToUpdate.Choice = feat.Choice;
            featToUpdate.FeatType = feat.FeatType;
            featToUpdate.FullText = feat.FullText;
            featToUpdate.ModifiedBy = "TEST";
            featToUpdate.Multiple = feat.Multiple;
            featToUpdate.Name = feat.Name;
            featToUpdate.Normal = feat.Normal;
            featToUpdate.Prerequisite = feat.Prerequisite;
            featToUpdate.Reference = feat.Reference;
            featToUpdate.Special = feat.Special;
            featToUpdate.Stack = feat.Stack;
            var updatedFeat = _featRepository.Update(featToUpdate);
            return FeatMapper.MapEntityToModel(updatedFeat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFeat(int id)
        {
            _featRepository.Delete(id);
        }
    }
}

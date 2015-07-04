using System.IO;
using System.Linq;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using HiPerfMetrics;
using HiPerfMetrics.Info;
using HiPerfMetrics.Reports;
using log4net;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class CharacterClassService : ICharacterClassService
    {
	    private static readonly ILog _logger = LogManager.GetLogger(typeof (CharacterClassService));

        private readonly ICharacterClassRepository _characterClassRepository;

        public CharacterClassService(ICharacterClassRepository characterClassRepository)
        {
            _characterClassRepository = characterClassRepository;
        }

        public IQueryable<CharacterClassViewModel> GetClasses()
        {
	        var metricInfo = new HiPerfMetric("CharacterClassService.GetClasses");
	        var classes = GetClasses(metricInfo);
			_logger.Debug(metricInfo.ReportAsDefault());
	        return classes;
        }

	    public IQueryable<CharacterClassViewModel> GetClasses(IStartStop metricInfo)
	    {
			metricInfo.Start("Get Records");
			var entityRecords = _characterClassRepository.GetAll();
			metricInfo.Stop();
			metricInfo.Start("Transform to model");
			var modelRecords = entityRecords.Select(CharacterClassMapper.MapEntityToModel).AsQueryable();
			metricInfo.Stop();
		    return modelRecords;
	    }

        public CharacterClassViewModel GetClassById(int id)
        {
            return CharacterClassMapper.MapEntityToModel(_characterClassRepository.GetById(id));
        }

        public CharacterClassViewModel AddClass(CharacterClassViewModel characterClass, string userId)
        {
            var characterClassToAdd = CharacterClassMapper.MapModelToEntity(characterClass);
            characterClassToAdd.CreatedBy = userId;
            characterClassToAdd.SeedData = false;
            var addedCharacterClass = _characterClassRepository.Add(characterClassToAdd);
            return CharacterClassMapper.MapEntityToModel(addedCharacterClass);
        }

        public CharacterClassViewModel UpdateClass(int id, CharacterClassViewModel characterClass)
        {
            var originalCharacterClass = _characterClassRepository.GetById(id);
            CharacterClassMapper.MapModelToEntity(characterClass, originalCharacterClass);
            originalCharacterClass.ModifiedBy = "TEST";
            var updatedCharacterClass = _characterClassRepository.Update(originalCharacterClass);
            return CharacterClassMapper.MapEntityToModel(updatedCharacterClass);
        }

        public void DeleteClass(int id)
        {
            _characterClassRepository.Delete(id);
        }

        public void SeedClass(string seedDataPath)
        {
            ClassSeed[] classArray;
            using (var classStream = new StreamReader(seedDataPath + "/class.json"))
            {
                classArray = JsonConvert.DeserializeObject<ClassSeed[]>(classStream.ReadToEnd());
            }
            foreach (var classSeed in classArray)
            {
                var dbClass = _characterClassRepository.GetById(classSeed.Id);
                if (dbClass == null)
                {
                    var newClass = CharacterClassMapper.MapSeedToEntity(classSeed);
                    newClass.CreatedBy = "SeedClass";
                    newClass.SeedData = true;
                    _characterClassRepository.Add(newClass);
                }
                else
                {
                    CharacterClassMapper.MapSeedToEntity(classSeed, dbClass);
                    dbClass.ModifiedBy = "SeedClass";
                    _characterClassRepository.Update(dbClass);
                }
            }
        }
    }
}
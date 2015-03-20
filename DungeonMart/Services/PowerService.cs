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
    public class PowerService : IPowerService
    {
        private readonly IPowerRepository _powerRepository;

        public PowerService(IPowerRepository powerRepository)
        {
            _powerRepository = powerRepository;
        }

        public IQueryable<PowerViewModel> GetPowers()
        {
            return _powerRepository.GetAll().Select(PowerMapper.MapEntityToModel).AsQueryable();
        }

        public PowerViewModel GetPowerById(int id)
        {
            return PowerMapper.MapEntityToModel(_powerRepository.GetById(id));
        }

        public PowerViewModel AddPower(PowerViewModel power)
        {
            var newPower = PowerMapper.MapModelToEntity(power);
            newPower.CreatedBy = "TEST";
            newPower.SeedData = false;
            var addedPower = _powerRepository.Add(newPower);
            return PowerMapper.MapEntityToModel(addedPower);
        }

        public PowerViewModel UdpatePower(int id, PowerViewModel power)
        {
            var powerToUpdate = _powerRepository.GetById(id);
            PowerMapper.MapModelToEntity(power, powerToUpdate);
            powerToUpdate.ModifiedBy = "TEST";
            var updatedPower = _powerRepository.Update(powerToUpdate);
            return PowerMapper.MapEntityToModel(updatedPower);
        }

        public void DeletePower(int id)
        {
            _powerRepository.Delete(id);
        }

        public void SeedPowers(string seedPath)
        {
            PowerSeed[] powerArray;
            using (var powerStream = new StreamReader(seedPath + "/power.json"))
            {
                powerArray = JsonConvert.DeserializeObject<PowerSeed[]>(powerStream.ReadToEnd());
            }
            foreach (var powerSeed in powerArray)
            {
                var powerEntity = _powerRepository.GetById(powerSeed.Id);
                if (powerEntity == null)
                {
                    powerEntity = PowerMapper.MapSeedToEntity(powerSeed);
                    powerEntity.CreatedBy = "SeedPowers";
                    powerEntity.SeedData = true;
                    _powerRepository.Add(powerEntity);
                }
                else
                {
                    PowerMapper.MapSeedToEntity(powerSeed, powerEntity);
                    powerEntity.ModifiedBy = "SeedPowers";
                    _powerRepository.Update(powerEntity);
                }
            }
        }
    }
}
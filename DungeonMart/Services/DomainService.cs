using System;
using System.IO;
using System.Linq;
using AutoMapper;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class DomainService : IDomainService
    {
        private readonly IDomainRepository _domainRepository;

        public DomainService(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public IQueryable<Domain> GetDomains()
        {
            return _domainRepository.GetAll().Select(DomainMapper.MapEntityToModel).AsQueryable();
        }

        public Domain GetDomainById(int id)
        {
            return DomainMapper.MapEntityToModel(_domainRepository.GetById(id));
        }

        public Domain AddDomain(Domain domain)
        {
            var domainToAdd = DomainMapper.MapModelToEntity(domain);
            domainToAdd.CreatedBy = "TEST";
            var addedDomain = _domainRepository.Add(domainToAdd);
            return DomainMapper.MapEntityToModel(addedDomain);
        }

        public Domain UpdateDomain(int id, Domain domain)
        {
            var domainToUpdate = _domainRepository.GetById(id);
            DomainMapper.MapModelToEntity(domain, domainToUpdate);
            domainToUpdate.ModifiedBy = "TEST";
            var updatedDomain = _domainRepository.Update(domainToUpdate);
            return DomainMapper.MapEntityToModel(updatedDomain);
        }

        public void DeleteDomain(int id)
        {
            _domainRepository.Delete(id);
        }

        public void SeedDomain(string seedPath)
        {
            DomainSeed[] domainArray;
            using (var domainStream = new StreamReader(seedPath + "/domain.json"))
            {
                domainArray = JsonConvert.DeserializeObject<DomainSeed[]>(domainStream.ReadToEnd());
            }
            foreach (var domainSeed in domainArray)
            {
                var dbDomain = _domainRepository.GetById(domainSeed.Id);
                if (dbDomain == null)
                {
                    var newDomain = DomainMapper.MapSeedToEntity(domainSeed);
                    newDomain.CreatedBy = "SeedDomain";
                    _domainRepository.Add(newDomain);
                }
                else
                {
                    DomainMapper.MapSeedToEntity(domainSeed, dbDomain);
                    dbDomain.ModifiedBy = "SeedDomain";
                    _domainRepository.Update(dbDomain);
                }
            }
        }
    }
}
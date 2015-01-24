using System;
using System.Linq;
using AutoMapper;
using DungeonMart.Data.Interfaces;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

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
            var domainToUpdate = DomainMapper.MapModelToEntity(domain);
            var originalDomain = _domainRepository.GetById(id);
            domainToUpdate.CreatedBy = originalDomain.CreatedBy;
            domainToUpdate.CreatedDate = originalDomain.CreatedDate;
            domainToUpdate.ModifiedBy = "TEST";
            var updatedDomain = _domainRepository.Update(domainToUpdate);
            return DomainMapper.MapEntityToModel(updatedDomain);
        }

        public void DeleteDomain(int id)
        {
            _domainRepository.Delete(id);
        }
    }
}
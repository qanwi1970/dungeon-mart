using System.Web;
using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class DomainMapper
    {
        static DomainMapper()
        {
            Mapper.CreateMap<DomainViewModel, Domain>();
            Mapper.CreateMap<Domain, DomainViewModel>();
        }

        public static DomainViewModel MapEntityToModel(Domain domainEntity)
        {
            return Mapper.Map<DomainViewModel>(domainEntity);
        }

        public static Domain MapModelToEntity(DomainViewModel domain)
        {
            return Mapper.Map<Domain>(domain);
        }

        public static void MapModelToEntity(DomainViewModel domain, Domain domainEntity)
        {
            Mapper.Map(domain, domainEntity);
        }

        public static Domain MapSeedToEntity(DomainSeed domainSeed)
        {
            var entity = new Domain();
            MapSeedToEntity(domainSeed, entity);
            return entity;
        }

        public static void MapSeedToEntity(DomainSeed domainSeed, Domain dbDomain)
        {
            dbDomain.FullText = HttpUtility.HtmlDecode(domainSeed.full_text);
            dbDomain.GrantedPowers = domainSeed.granted_powers;
            dbDomain.Id = domainSeed.Id;
            dbDomain.Name = domainSeed.name;
            dbDomain.Reference = domainSeed.reference;
            dbDomain.Spell1 = domainSeed.spell_1;
            dbDomain.Spell2 = domainSeed.spell_2;
            dbDomain.Spell3 = domainSeed.spell_3;
            dbDomain.Spell4 = domainSeed.spell_4;
            dbDomain.Spell5 = domainSeed.spell_5;
            dbDomain.Spell6 = domainSeed.spell_6;
            dbDomain.Spell7 = domainSeed.spell_7;
            dbDomain.Spell8 = domainSeed.spell_8;
            dbDomain.Spell9 = domainSeed.spell_9;
        }
    }
}
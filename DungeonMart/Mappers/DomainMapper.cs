using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainMapper
    {
        static DomainMapper()
        {
            Mapper.CreateMap<Domain, DomainEntity>();
            Mapper.CreateMap<DomainEntity, Domain>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainEntity"></param>
        /// <returns></returns>
        public static Domain MapEntityToModel(DomainEntity domainEntity)
        {
            return Mapper.Map<Domain>(domainEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static DomainEntity MapModelToEntity(Domain domain)
        {
            return Mapper.Map<DomainEntity>(domain);
        }
    }
}
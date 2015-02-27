using AutoMapper;

namespace DungeonMart.Mappers
{
    public abstract class BaseMapper<TM,TE,TS> where TE : new()
    {
        static BaseMapper()
        {
            Mapper.CreateMap<TM, TE>();
            Mapper.CreateMap<TE, TM>();
        }

        public static TM MapEntityToModel(TE entity)
        {
            return Mapper.Map<TM>(entity);
        }

        public static TE MapModelToEntity(TM model)
        {
            return Mapper.Map<TE>(model);
        }

        public static void MapModelToEntity(TM model, TE entity)
        {
            Mapper.Map(model, entity);
        }

        public TE MapSeedToEntity(TS seed)
        {
            var entity = new TE();
            MapSeedToEntity(seed, entity);
            return entity;
        }

        public abstract void MapSeedToEntity(TS seed, TE entity);
    }
}
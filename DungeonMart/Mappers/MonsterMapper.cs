using System.Web;
using AutoMapper;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Shared.Models;

namespace DungeonMart.Mappers
{
    public class MonsterMapper
    {
        static MonsterMapper()
        {
            Mapper.CreateMap<Monster, MonsterEntity>();
            Mapper.CreateMap<MonsterEntity, Monster>();
        }
        public static Monster MapEntityToModel(MonsterEntity monsterEntity)
        {
            return Mapper.Map<Monster>(monsterEntity);
        }

        public static MonsterEntity MapModelToEntity(Monster monster)
        {
            return Mapper.Map<MonsterEntity>(monster);
        }

        public static void MapModelToEntity(Monster monster, MonsterEntity monsterEntity)
        {
            Mapper.Map(monster, monsterEntity);
        }

        public static MonsterEntity MapSeedToEntity(MonsterSeed monsterSeed)
        {
            var monsterEntity = new MonsterEntity();
            MapSeedToEntity(monsterSeed, monsterEntity);
            return monsterEntity;
        }

        public static void MapSeedToEntity(MonsterSeed monsterSeed, MonsterEntity monsterEntity)
        {
            monsterEntity.Abilities = monsterSeed.abilities;
            monsterEntity.Advancement = monsterSeed.advancement;
            monsterEntity.Alignment = monsterSeed.alignment;
            monsterEntity.AlternateName = monsterSeed.altname;
            monsterEntity.ArmorClass = monsterSeed.armor_class;
            monsterEntity.Attack = monsterSeed.attack;
            monsterEntity.BaseAttack = monsterSeed.base_attack;
            monsterEntity.BonusFeats = monsterSeed.bonus_feats;
            monsterEntity.ChallengeRating = monsterSeed.challenge_rating;
            monsterEntity.Descriptor = monsterSeed.descriptor;
            monsterEntity.Environment = monsterSeed.environment;
            monsterEntity.EpicFeats = monsterSeed.epic_feats;
            monsterEntity.Family = monsterSeed.family;
            monsterEntity.Feats = monsterSeed.feats;
            monsterEntity.FullAttack = monsterSeed.full_attack;
            monsterEntity.FullText = HttpUtility.HtmlDecode(monsterSeed.full_text);
            monsterEntity.Grapple = monsterSeed.grapple;
            monsterEntity.HitDice = monsterSeed.hit_dice;
            monsterEntity.Id = monsterSeed.Id;
            monsterEntity.Initiative = monsterSeed.initiative;
            monsterEntity.LevelAdjustment = monsterSeed.level_adjustment;
            monsterEntity.Name = monsterSeed.name;
            monsterEntity.Organization = monsterSeed.organization;
            monsterEntity.Reach = monsterSeed.reach;
            monsterEntity.Reference = monsterSeed.reference;
            monsterEntity.Saves = monsterSeed.saves;
            monsterEntity.Size = monsterSeed.size;
            monsterEntity.Skills = monsterSeed.skills;
            monsterEntity.Space = monsterSeed.space;
            monsterEntity.SpecialAbilities = monsterSeed.special_abilities;
            monsterEntity.SpecialAttacks = monsterSeed.special_attacks;
            monsterEntity.SpecialQualities = monsterSeed.special_qualities;
            monsterEntity.Speed = monsterSeed.speed;
            monsterEntity.StatBlock = monsterSeed.stat_block;
            monsterEntity.Treasure = monsterSeed.treasure;
            monsterEntity.Type = monsterSeed.type;
        }
    }
}

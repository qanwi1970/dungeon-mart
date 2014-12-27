using DungeonMart.Data.Models;
using DungeonMart.Shared.Models;

namespace DungeonMart.Service.Mappers
{
    public class MonsterMapper
    {
        public static Monster MapEntityToModel(MonsterEntity monsterEntity)
        {
            return new Monster
            {
                Abilities = monsterEntity.Abilities,
                Advancement = monsterEntity.Advancement,
                Alignment = monsterEntity.Alignment,
                AlternateName = monsterEntity.AlternateName,
                ArmorClass = monsterEntity.ArmorClass,
                Attack = monsterEntity.Attack,
                BaseAttack = monsterEntity.BaseAttack,
                BonusFeats = monsterEntity.BonusFeats,
                ChallengeRating = monsterEntity.ChallengeRating,
                Descriptor = monsterEntity.Descriptor,
                Environment = monsterEntity.Environment,
                EpicFeats = monsterEntity.EpicFeats,
                Family = monsterEntity.Family,
                Feats = monsterEntity.Feats,
                FullAttack = monsterEntity.FullAttack,
                FullText = monsterEntity.FullText,
                Grapple = monsterEntity.Grapple,
                HitDice = monsterEntity.HitDice,
                Id = monsterEntity.Id,
                Initiative = monsterEntity.Initiative,
                LevelAdjustment = monsterEntity.LevelAdjustment,
                Name = monsterEntity.Name,
                Organization = monsterEntity.Organization,
                Reach = monsterEntity.Reach,
                Reference = monsterEntity.Reference,
                Saves = monsterEntity.Saves,
                Size = monsterEntity.Size,
                Skills = monsterEntity.Skills,
                Space = monsterEntity.Space,
                SpecialAbilities = monsterEntity.SpecialAbilities,
                SpecialAttacks = monsterEntity.SpecialAttacks,
                SpecialQualities = monsterEntity.SpecialQualities,
                Speed = monsterEntity.Speed,
                StatBlock = monsterEntity.StatBlock,
                Treasure = monsterEntity.Treasure,
                Type = monsterEntity.Type
            };
        }

        public static MonsterEntity MapModelToEntity(Monster monster)
        {
            return new MonsterEntity
            {
                Abilities = monster.Abilities,
                Advancement = monster.Advancement,
                Alignment = monster.Alignment,
                AlternateName = monster.AlternateName,
                ArmorClass = monster.ArmorClass,
                Attack = monster.Attack,
                BaseAttack = monster.BaseAttack,
                BonusFeats = monster.BonusFeats,
                ChallengeRating = monster.ChallengeRating,
                Descriptor = monster.Descriptor,
                Environment = monster.Environment,
                EpicFeats = monster.EpicFeats,
                Family = monster.Family,
                Feats = monster.Feats,
                FullAttack = monster.FullAttack,
                FullText = monster.FullText,
                Grapple = monster.Grapple,
                HitDice = monster.HitDice,
                Id = monster.Id,
                Initiative = monster.Initiative,
                LevelAdjustment = monster.LevelAdjustment,
                Name = monster.Name,
                Organization = monster.Organization,
                Reach = monster.Reach,
                Reference = monster.Reference,
                Saves = monster.Saves,
                Size = monster.Size,
                Skills = monster.Skills,
                Space = monster.Space,
                SpecialAbilities = monster.SpecialAbilities,
                SpecialAttacks = monster.SpecialAttacks,
                SpecialQualities = monster.SpecialQualities,
                Speed = monster.Speed,
                StatBlock = monster.StatBlock,
                Treasure = monster.Treasure,
                Type = monster.Type
            };
        }

        public static void UpdateEntityFromModel(MonsterEntity originalMonster, Monster monster)
        {
            originalMonster.Abilities = monster.Abilities;
            originalMonster.Advancement = monster.Advancement;
            originalMonster.Alignment = monster.Alignment;
            originalMonster.AlternateName = monster.AlternateName;
            originalMonster.ArmorClass = monster.ArmorClass;
            originalMonster.Attack = monster.Attack;
            originalMonster.BaseAttack = monster.BaseAttack;
            originalMonster.BonusFeats = monster.BonusFeats;
            originalMonster.ChallengeRating = monster.ChallengeRating;
            originalMonster.Descriptor = monster.Descriptor;
            originalMonster.Environment = monster.Environment;
            originalMonster.EpicFeats = monster.EpicFeats;
            originalMonster.Family = monster.Family;
            originalMonster.Feats = monster.Feats;
            originalMonster.FullAttack = monster.FullAttack;
            originalMonster.FullText = monster.FullText;
            originalMonster.Grapple = monster.Grapple;
            originalMonster.HitDice = monster.HitDice;
            originalMonster.Initiative = monster.Initiative;
            originalMonster.LevelAdjustment = monster.LevelAdjustment;
            originalMonster.Name = monster.Name;
            originalMonster.Organization = monster.Organization;
            originalMonster.Reach = monster.Reach;
            originalMonster.Reference = monster.Reference;
            originalMonster.Saves = monster.Saves;
            originalMonster.Size = monster.Size;
            originalMonster.Skills = monster.Skills;
            originalMonster.Space = monster.Space;
            originalMonster.SpecialAbilities = monster.SpecialAbilities;
            originalMonster.SpecialAttacks = monster.SpecialAttacks;
            originalMonster.SpecialQualities = monster.SpecialQualities;
            originalMonster.Speed = monster.Speed;
            originalMonster.StatBlock = monster.StatBlock;
            originalMonster.Treasure = monster.Treasure;
            originalMonster.Type = monster.Type;
        }
    }
}

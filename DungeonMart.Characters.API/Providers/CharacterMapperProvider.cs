using System;
using DungeonMart.Characters.API.Mappers;
using DungeonMart.Characters.API.Models;

namespace DungeonMart.Characters.API.Providers
{
    public interface ICharacterMapperProvider
    {
        ICharacterMapper GetCharacterMapper(GameSystem gameSystem);
    }

    public class CharacterMapperProvider : ICharacterMapperProvider
    {
        public ICharacterMapper GetCharacterMapper(GameSystem gameSystem)
        {
            switch (gameSystem)
            {
                case GameSystem.Dnd35:
                    return new Dnd35Mapper();
                case GameSystem.Dnd5:
                    return new Dnd5Mapper();
                default:
                    throw new Exception("Mapper not defined for this game system.");
            }
        }
    }
}
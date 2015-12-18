using DungeonMart.Characters.API.Models;
using DungeonMart.Characters.API.Providers;
using DungeonMart.Characters.API.Repositories;
using DungeonMart.Characters.API.Repositories.Interfaces;
using DungeonMart.Characters.API.Services.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DungeonMart.Characters.API.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService() : this(new CharacterRepository()) { }

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task DeleteCharacter(string id, string userName)
        {
            ObjectId characterId;
            if (!ObjectId.TryParse(id, out characterId))
            {
                throw new ArgumentException("The character id is not of the proper format.");
            }

            await _characterRepository.DeleteCharacter(characterId, userName);
        }
    }
}
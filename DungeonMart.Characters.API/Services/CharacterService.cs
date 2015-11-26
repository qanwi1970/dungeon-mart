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
        private readonly ICharacterMapperProvider _characterMapperProvider;

        public CharacterService() : this(new CharacterRepository(), new CharacterMapperProvider()) { }

        public CharacterService(ICharacterRepository characterRepository, ICharacterMapperProvider characterMapperProvider)
        {
            _characterRepository = characterRepository;
            _characterMapperProvider = characterMapperProvider;
        }

        public async Task<List<BaseCharacterViewModel>> GetCharacters()
        {
            var returnList = new List<BaseCharacterViewModel>();

            var bsonCharacters = await _characterRepository.GetCharacters();
            foreach (var character in bsonCharacters)
            {
                var mapper = _characterMapperProvider.GetCharacterMapper(character);
                returnList.Add(mapper.MapDocumentToViewModel(character));
            }

            return returnList;
        }

        public async Task<BaseCharacterViewModel> GetCharacterById(string id)
        {
            ObjectId characterId;
            if (!ObjectId.TryParse(id, out characterId))
            {
                throw new ArgumentException("Character Id invalid");
            }

            var character = await _characterRepository.GetCharacter(characterId);
            if (character == null)
            {
                return null;
            }

            var mapper = _characterMapperProvider.GetCharacterMapper(character);
            return mapper.MapDocumentToViewModel(character);
        }

        public async Task<BaseCharacterViewModel> AddCharacter(BaseCharacterViewModel character)
        {
            var mapper = _characterMapperProvider.GetCharacterMapper(character);

            var bsonCharacter = mapper.MapViewModelToDocument(character);

            var addedCharacter = await _characterRepository.AddCharacter(bsonCharacter);

            return mapper.MapDocumentToViewModel(addedCharacter);
        }
    }
}
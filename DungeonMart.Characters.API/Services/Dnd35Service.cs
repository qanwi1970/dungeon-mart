using System.Threading.Tasks;
using DungeonMart.Characters.API.Mappers.Interfaces;
using DungeonMart.Characters.API.Models;
using DungeonMart.Characters.API.Repositories.Interfaces;
using DungeonMart.Characters.API.Services.Interfaces;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Services
{
    public class Dnd35Service : IDnd35Service
    {
        private readonly IDnd35Mapper _mapper;
        private readonly ICharacterRepository _characterRepository;

        public Dnd35Service(IDnd35Mapper mapper, ICharacterRepository characterRepository)
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }

        public async Task<Dnd35CharacterViewModel> AddCharacter(Dnd35CharacterViewModel character, string userName)
        {
            var bsonCharacter = _mapper.MapViewModelToDocument(character);
            bsonCharacter.Add(new BsonElement("owner", userName));

            var addedCharacter = await _characterRepository.AddCharacter(bsonCharacter);

            return _mapper.MapDocumentToViewModel(addedCharacter);
        }

        public Task UpdateCharacter(string id, Dnd35CharacterViewModel character, string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
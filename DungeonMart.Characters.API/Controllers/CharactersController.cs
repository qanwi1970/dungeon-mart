using System;
using System.Web.Http;
using DungeonMart.Characters.API.Models;
using System.Threading.Tasks;
using MongoDB.Bson;
using DungeonMart.Characters.API.Repositories.Interfaces;
using DungeonMart.Characters.API.Repositories;
using DungeonMart.Characters.API.Services.Interfaces;
using DungeonMart.Characters.API.Services;

namespace DungeonMart.Characters.API.Controllers
{
	[RoutePrefix("api/characters")]
    public class CharactersController : ApiController
    {
        private readonly ICharacterRepository repo;
        private readonly ICharacterService _characterService;

        // this constructor goes away when we introduce DI
        public CharactersController() : this(new CharacterRepository(), new CharacterService())
        {
        }

        public CharactersController(ICharacterRepository characterRepository, ICharacterService characterService)
        {
            repo = characterRepository;
            _characterService = characterService;
        }

		[Route("")]
		public async Task<IHttpActionResult> Get()
		{
			var characters = await _characterService.GetCharacters();

			return Ok(characters);
		}

        [Route("{id}", Name = "GetById")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            BaseCharacterViewModel character;
            try
            {
                character = await _characterService.GetCharacterById(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

		[Route("")]
        public async Task<IHttpActionResult> Post(BaseCharacterViewModel character)
        {
		    var addedCharacter = await _characterService.AddCharacter(character);

            return CreatedAtRoute("GetById", new { id = addedCharacter.CharacterID }, addedCharacter);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Put(string id, BaseCharacterViewModel character)
        {
            await _characterService.UpdateCharacter(id, character);

            return Ok();
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await _characterService.DeleteCharacter(id);

            return Ok();
        }
    }
}

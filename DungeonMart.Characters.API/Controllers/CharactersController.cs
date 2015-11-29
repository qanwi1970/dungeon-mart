using System;
using System.Web.Http;
using DungeonMart.Characters.API.Models;
using System.Threading.Tasks;
using DungeonMart.Characters.API.Services.Interfaces;
using DungeonMart.Characters.API.Services;
using Microsoft.AspNet.Identity;

namespace DungeonMart.Characters.API.Controllers
{
	[RoutePrefix("api/characters")]
    public class CharactersController : ApiController
    {
        private readonly ICharacterService _characterService;

        // this constructor goes away when we introduce DI
        public CharactersController() : this(new CharacterService())
        {
        }

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [Authorize]
		[Route("")]
		public async Task<IHttpActionResult> Get()
        {
            var user = User.Identity.Name;
			var characters = await _characterService.GetCharacters(user);

			return Ok(characters);
		}

        [Authorize]
        [Route("{id}", Name = "GetById")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            BaseCharacterViewModel character;
            try
            {
                character = await _characterService.GetCharacterById(id, User.Identity.Name);
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

        [Authorize]
		[Route("")]
        public async Task<IHttpActionResult> Post(BaseCharacterViewModel character)
        {
		    var addedCharacter = await _characterService.AddCharacter(character, User.Identity.Name);

            return CreatedAtRoute("GetById", new { id = addedCharacter.CharacterID }, addedCharacter);
        }
        
        [Authorize]
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(string id, BaseCharacterViewModel character)
        {
            await _characterService.UpdateCharacter(id, character, User.Identity.Name);

            return Ok();
        }

        [Authorize]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await _characterService.DeleteCharacter(id, User.Identity.Name);

            return Ok();
        }
    }
}

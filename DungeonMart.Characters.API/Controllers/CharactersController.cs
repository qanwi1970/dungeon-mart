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
        [Route("{system}/{id}")]
        public async Task<IHttpActionResult> Delete(GameSystem system, string id)
        {
            await _characterService.DeleteCharacter(id, User.Identity.Name);

            return Ok();
        }
    }
}

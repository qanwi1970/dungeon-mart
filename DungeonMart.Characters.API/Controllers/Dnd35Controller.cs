using System;
using System.Threading.Tasks;
using System.Web.Http;
using DungeonMart.Characters.API.Mappers;
using DungeonMart.Characters.API.Models;
using DungeonMart.Characters.API.Repositories;
using DungeonMart.Characters.API.Services;
using DungeonMart.Characters.API.Services.Interfaces;

namespace DungeonMart.Characters.API.Controllers
{
    [RoutePrefix("api/characters/dnd35")]
    public class Dnd35Controller : CharactersController
    {
        private readonly IDnd35Service _dnd35Service;

        public Dnd35Controller(IDnd35Service dnd35Service)
        {
            _dnd35Service = dnd35Service;
        }

        public Dnd35Controller() : this(new Dnd35Service(new Dnd35Mapper(), new CharacterRepository()))
        {
        }


        [Authorize]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var user = User.Identity.Name;
            var characters = await _dnd35Service.GetCharacters(user);

            return Ok(characters);
        }

        [Authorize]
        [Route("{id}", Name = "GetById")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            Dnd35CharacterViewModel character;
            try
            {
                character = await _dnd35Service.GetCharacterById(id, User.Identity.Name);
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
        public async Task<IHttpActionResult> Post(Dnd35CharacterViewModel character)
        {
            var addedCharacter = await _dnd35Service.AddCharacter(character, User.Identity.Name);

            return CreatedAtRoute("GetById", new { id = addedCharacter.CharacterID }, addedCharacter);
        }

        [Authorize]
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(string id, Dnd35CharacterViewModel character)
        {
            await _dnd35Service.UpdateCharacter(id, character, User.Identity.Name);

            return Ok();
        }

    }
}

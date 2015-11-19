using System;
using System.Collections.Generic;
using System.Web.Http;
using DungeonMart.Characters.API.Models;
using DungeonMart.Characters.API.Repositories;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DungeonMart.Characters.API.Controllers
{
	[RoutePrefix("api/characters")]
    public class CharactersController : ApiController
    {
        CharacterRepository repo = new CharacterRepository();

		[Route("")]
		public async Task<IHttpActionResult> Get()
		{
			var characters = await repo.GetCharacters();

			return Ok(characters);
		}

        [Route("{id}", Name = "GetById")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            ObjectId characterId;
            if (ObjectId.TryParse(id, out characterId))
            {
                var character = await repo.GetCharacter(characterId);
                if (character != null)
                {
                    return Ok(character);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest("The character id is not of the proper format.");
        }

		[Route("")]
        public async Task<IHttpActionResult> Post(BaseCharacterViewModel character)
        {
            var bsonCharacter = new BsonDocument
            {
                { "characterName", character.CharacterName },
                { "isShared", character.IsShared },
                { "system", character.System.ToString() }
            };

            var addedCharacter = await repo.AddCharacter(bsonCharacter);
            BsonValue characterId;
            addedCharacter.TryGetValue("_id", out characterId);

            return CreatedAtRoute("GetById", new { id = characterId.AsObjectId }, addedCharacter);
        }
    }
}

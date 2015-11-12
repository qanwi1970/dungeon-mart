using System;
using System.Collections.Generic;
using System.Web.Http;
using DungeonMart.Characters.API.Models;

namespace DungeonMart.Characters.API.Controllers
{
	[RoutePrefix("api/characters")]
    public class CharactersController : ApiController
    {
		[Route("")]
		public List<BaseCharacterViewModel> Get()
		{
			return new List<BaseCharacterViewModel>
			{
				new BaseCharacterViewModel
				{
					CharacterID = Guid.NewGuid(),
					CharacterName = "Bilbo Baggins",
					IsShared = true,
					System = GameSystem.Dnd5
				},
				new BaseCharacterViewModel
				{
					CharacterID = Guid.NewGuid(),
					CharacterName = "John Smith",
					IsShared = false,
					System = GameSystem.Dnd35
				}
			};
		}  
    }
}

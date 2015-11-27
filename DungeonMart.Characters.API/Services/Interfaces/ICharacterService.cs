using DungeonMart.Characters.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DungeonMart.Characters.API.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<List<BaseCharacterViewModel>> GetCharacters();
        Task<BaseCharacterViewModel> GetCharacterById(string id);
        Task<BaseCharacterViewModel> AddCharacter(BaseCharacterViewModel character);
        Task UpdateCharacter(string id, BaseCharacterViewModel character);
        Task DeleteCharacter(string id);
    }
}

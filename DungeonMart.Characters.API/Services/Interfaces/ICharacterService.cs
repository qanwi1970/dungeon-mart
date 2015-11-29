using DungeonMart.Characters.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DungeonMart.Characters.API.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<List<BaseCharacterViewModel>> GetCharacters(string user);
        Task<BaseCharacterViewModel> GetCharacterById(string id, string userName);
        Task<BaseCharacterViewModel> AddCharacter(BaseCharacterViewModel character, string userName);
        Task UpdateCharacter(string id, BaseCharacterViewModel character, string userName);
        Task DeleteCharacter(string id, string userName);
    }
}

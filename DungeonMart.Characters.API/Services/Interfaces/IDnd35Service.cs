using System.Threading.Tasks;
using DungeonMart.Characters.API.Models;

namespace DungeonMart.Characters.API.Services.Interfaces
{
    public interface IDnd35Service
    {
        Task<Dnd35CharacterViewModel> AddCharacter(Dnd35CharacterViewModel character, string userName);
        Task UpdateCharacter(string id, Dnd35CharacterViewModel character, string userName);
    }
}

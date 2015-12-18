using System.Threading.Tasks;

namespace DungeonMart.Characters.API.Services.Interfaces
{
    public interface ICharacterService
    {
        Task DeleteCharacter(string id, string userName);
    }
}

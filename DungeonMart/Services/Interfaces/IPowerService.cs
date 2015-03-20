using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IPowerService
    {
        IQueryable<PowerViewModel> GetPowers();
        PowerViewModel GetPowerById(int id);
        PowerViewModel AddPower(PowerViewModel power);
        PowerViewModel UdpatePower(int id, PowerViewModel power);
        void DeletePower(int id);
        void SeedPowers(string seedPath);
    }
}

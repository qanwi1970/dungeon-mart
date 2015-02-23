using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IPowerService
    {
        IQueryable<Power> GetPowers();
        Power GetPowerById(int id);
        Power AddPower(Power power);
        Power UdpatePower(int id, Power power);
        void DeletePower(int id);
        void SeedPowers(string seedPath);
    }
}

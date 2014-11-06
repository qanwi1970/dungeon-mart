using System.Collections.Generic;
using System.Threading.Tasks;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetEquipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(string id);
        Task<Equipment> AddEquipmentAsync(Equipment equipment);
        Task<Equipment> UpdateEquipmentAsync(string id, Equipment equipment);
        Task DeleteEquipmentAsync(string id);
    }
}

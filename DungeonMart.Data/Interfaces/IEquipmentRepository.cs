using System.Collections.Generic;
using System.Threading.Tasks;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetEquipments();
        Task<Equipment> GetEquipmentById(string id);
        Task<Equipment> AddEquipment(Equipment equipment);
        Task<Equipment> UpdateEquipment(string id, Equipment equipment);
        Task DeleteEquipment(string id);
    }
}

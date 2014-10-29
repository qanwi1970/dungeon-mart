using System.Collections.Generic;
using System.Threading.Tasks;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Interfaces
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetEquipments();
        Equipment GetEquipmentById(string id);
        Task<Equipment> AddEquipment(Equipment equipment);
        Task<Equipment> UpdateEquipment(string id, Equipment equipment);
        Task DeleteEquipment(string id);
    }
}

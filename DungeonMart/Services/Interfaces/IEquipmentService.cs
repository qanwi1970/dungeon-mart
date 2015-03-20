using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IEquipmentService
    {
        IQueryable<EquipmentViewModel> GetEquipments();
        EquipmentViewModel GetEquipmentById(int id);
        EquipmentViewModel AddEquipment(EquipmentViewModel equipment);
        EquipmentViewModel UpdateEquipment(int id, EquipmentViewModel equipment);
        void DeleteEquipment(int id);
        void SeedEquipment(string seedPath);
    }
}

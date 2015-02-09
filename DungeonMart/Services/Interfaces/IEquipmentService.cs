using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IEquipmentService
    {
        IQueryable<Equipment> GetEquipments();
        Equipment GetEquipmentById(int id);
        Equipment AddEquipment(Equipment equipment);
        Equipment UpdateEquipment(int id, Equipment equipment);
        void DeleteEquipment(int id);
        void SeedEquipment(string seedPath);
    }
}

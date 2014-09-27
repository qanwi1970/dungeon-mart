using System.Collections.Generic;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Interfaces
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetEquipments();
        Equipment GetEquipmentById(string id);
        Equipment AddEquipment(Equipment equipment);
        Equipment UpdateEquipment(string id, Equipment equipment);
        void DeleteEquipment(string id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMart.Data.DocumentDB;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IEquipmentRepository repo = new EquipmentDocDbRepository();

            System.Console.WriteLine("Adding Equipment");
            var newEquipment = repo.AddEquipment(new Equipment
            {
                Name = "test"
            }).Result;
            System.Console.WriteLine(newEquipment.id);

            System.Console.WriteLine("Getting list");
            var equipments = repo.GetEquipments().ToList();
            System.Console.WriteLine("List Count: " + equipments.Count);
            foreach (var equipment in equipments)
            {
                System.Console.Write(equipment.id + "\t");
            }

            System.Console.WriteLine("\nUpdating equipment");
            newEquipment.Family = "testfamily";
            var updatedEquipment = repo.UpdateEquipment(newEquipment.id, newEquipment).Result;
            System.Console.WriteLine(updatedEquipment.Family);

            System.Console.WriteLine("Deleting equipment");
            repo.DeleteEquipment(newEquipment.id);

            equipments = repo.GetEquipments().ToList();
            System.Console.WriteLine("Equipments count: " + equipments.Count);

            System.Console.ReadKey();
        }
    }
}

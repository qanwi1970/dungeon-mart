using System.Linq;
using DungeonMart.Data.OldSql;

namespace DungeonMart.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SRDContext())
            {
                System.Console.WriteLine("Equipment Count: {0}", dbContext.equipments.Count());
            }

            System.Console.ReadKey();
        }
    }
}

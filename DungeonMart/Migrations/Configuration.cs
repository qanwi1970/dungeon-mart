using System.Data.Entity.Migrations;
using DungeonMart.Data.DAL;

namespace DungeonMart.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DungeonMartContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DungeonMart.Data.DAL.DungeonMartContext";
        }

        protected override void Seed(DungeonMartContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

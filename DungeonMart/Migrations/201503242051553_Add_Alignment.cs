namespace DungeonMart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Alignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alignments",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Nickname = c.String(),
                        Good = c.Short(nullable: false),
                        Law = c.Short(nullable: false),
                        Description = c.String(),
                        Quote = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Alignments");
        }
    }
}

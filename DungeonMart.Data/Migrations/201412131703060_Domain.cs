namespace DungeonMart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Domain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Domain",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GrantedPowers = c.String(),
                        Spell1 = c.String(),
                        Spell2 = c.String(),
                        Spell3 = c.String(),
                        Spell4 = c.String(),
                        Spell5 = c.String(),
                        Spell6 = c.String(),
                        Spell7 = c.String(),
                        Spell8 = c.String(),
                        Spell9 = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Domain");
        }
    }
}

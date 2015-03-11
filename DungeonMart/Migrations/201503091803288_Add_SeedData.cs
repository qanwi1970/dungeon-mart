namespace DungeonMart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SeedData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterClass", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClassProgression", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Domain", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Equipment", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Feat", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Item", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Monster", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Power", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Skill", "SeedData", c => c.Boolean(nullable: false));
            AddColumn("dbo.Spell", "SeedData", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Spell", "SeedData");
            DropColumn("dbo.Skill", "SeedData");
            DropColumn("dbo.Power", "SeedData");
            DropColumn("dbo.Monster", "SeedData");
            DropColumn("dbo.Item", "SeedData");
            DropColumn("dbo.Feat", "SeedData");
            DropColumn("dbo.Equipment", "SeedData");
            DropColumn("dbo.Domain", "SeedData");
            DropColumn("dbo.ClassProgression", "SeedData");
            DropColumn("dbo.CharacterClass", "SeedData");
        }
    }
}

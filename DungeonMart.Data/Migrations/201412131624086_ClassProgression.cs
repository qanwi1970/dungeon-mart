namespace DungeonMart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassProgression : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassProgression",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Level = c.String(),
                        BaseAttackBonus = c.String(),
                        FortitudeSave = c.String(),
                        ReflexSave = c.String(),
                        WillSave = c.String(),
                        CasterLevel = c.String(),
                        PointsPerDay = c.String(),
                        ArmorClassBonus = c.String(),
                        FlurryOfBlows = c.String(),
                        BonusSpells = c.String(),
                        PowersKnown = c.String(),
                        UnarmoredSpeedBonus = c.String(),
                        UnarmedDamage = c.String(),
                        PowerLevel = c.String(),
                        Special = c.String(),
                        Slots0 = c.String(),
                        Slots1 = c.String(),
                        Slots2 = c.String(),
                        Slots3 = c.String(),
                        Slots4 = c.String(),
                        Slots5 = c.String(),
                        Slots6 = c.String(),
                        Slots7 = c.String(),
                        Slots8 = c.String(),
                        Slots9 = c.String(),
                        SpellsKnown0 = c.String(),
                        SpellsKnown1 = c.String(),
                        SpellsKnown2 = c.String(),
                        SpellsKnown3 = c.String(),
                        SpellsKnown4 = c.String(),
                        SpellsKnown5 = c.String(),
                        SpellsKnown6 = c.String(),
                        SpellsKnown7 = c.String(),
                        SpellsKnown8 = c.String(),
                        SpellsKnown9 = c.String(),
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
            DropTable("dbo.ClassProgression");
        }
    }
}

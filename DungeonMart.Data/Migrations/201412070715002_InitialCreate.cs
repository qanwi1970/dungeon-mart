namespace DungeonMart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Alignment = c.String(),
                        HitDie = c.String(),
                        ClassSkills = c.String(),
                        SkillPoints = c.String(),
                        SkillPointsAbility = c.String(),
                        SpellStat = c.String(),
                        Proficiencies = c.String(),
                        SpellType = c.String(),
                        EpicFeatBaseLevel = c.String(),
                        EpicFeatInterval = c.String(),
                        EpicFeatList = c.String(),
                        EpicFullText = c.String(),
                        RequiredRace = c.String(),
                        RequiredWeaponProficiency = c.String(),
                        RequiredBaseAttackBonus = c.String(),
                        RequiredSkill = c.String(),
                        RequiredFeat = c.String(),
                        RequiredSpells = c.String(),
                        RequiredLanguages = c.String(),
                        RequiredPsionics = c.String(),
                        RequiredEpicFeat = c.String(),
                        RequiredSpecial = c.String(),
                        SpellList1 = c.String(),
                        SpellList2 = c.String(),
                        SpellList3 = c.String(),
                        SpellList4 = c.String(),
                        SpellList5 = c.String(),
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
            DropTable("dbo.CharacterClass");
        }
    }
}

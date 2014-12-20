namespace DungeonMart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseSrd : DbMigration
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
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        Category = c.String(),
                        Subcategory = c.String(),
                        Cost = c.String(),
                        DamageSmall = c.String(),
                        ArmorShieldBonus = c.String(),
                        MaximumDexBonus = c.String(),
                        DamageMedium = c.String(),
                        Weight = c.String(),
                        Critical = c.String(),
                        ArmorCheckPenalty = c.String(),
                        ArcaneSpellFailureChance = c.String(),
                        RangeIncrement = c.String(),
                        Speed30 = c.String(),
                        WeaponType = c.String(),
                        Speed20 = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FeatType = c.String(),
                        Multiple = c.String(),
                        Stack = c.String(),
                        Choice = c.String(),
                        Prerequisite = c.String(),
                        Benefit = c.String(),
                        Normal = c.String(),
                        Special = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feat");
            DropTable("dbo.Equipment");
            DropTable("dbo.Domain");
            DropTable("dbo.ClassProgression");
            DropTable("dbo.CharacterClass");
        }
    }
}

namespace DungeonMart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RemainingSRD : DbMigration
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
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        SeedData = c.Boolean(nullable: false),
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
                        SeedData = c.Boolean(nullable: false),
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
                        SeedData = c.Boolean(nullable: false),
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
                        SeedData = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Subcategory = c.String(),
                        SpecialAbility = c.String(),
                        Aura = c.String(),
                        CasterLevel = c.String(),
                        Price = c.String(),
                        ManifesterLevel = c.String(),
                        Prerequisites = c.String(),
                        Cost = c.String(),
                        Weight = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        SeedData = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Family = c.String(),
                        Name = c.String(),
                        AlternateName = c.String(),
                        Size = c.String(),
                        Type = c.String(),
                        Descriptor = c.String(),
                        HitDice = c.String(),
                        Initiative = c.String(),
                        Speed = c.String(),
                        ArmorClass = c.String(),
                        BaseAttack = c.String(),
                        Grapple = c.String(),
                        Attack = c.String(),
                        FullAttack = c.String(),
                        Space = c.String(),
                        Reach = c.String(),
                        SpecialAttacks = c.String(),
                        SpecialQualities = c.String(),
                        Saves = c.String(),
                        Abilities = c.String(),
                        Skills = c.String(),
                        BonusFeats = c.String(),
                        Feats = c.String(),
                        EpicFeats = c.String(),
                        Environment = c.String(),
                        Organization = c.String(),
                        ChallengeRating = c.String(),
                        Treasure = c.String(),
                        Alignment = c.String(),
                        Advancement = c.String(),
                        LevelAdjustment = c.String(),
                        SpecialAbilities = c.String(),
                        StatBlock = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        SeedData = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Power",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discipline = c.String(),
                        Subdiscipline = c.String(),
                        Descriptor = c.String(),
                        Level = c.String(),
                        Display = c.String(),
                        ManifestingTime = c.String(),
                        Range = c.String(),
                        Target = c.String(),
                        Area = c.String(),
                        Effect = c.String(),
                        Duration = c.String(),
                        SavingThrow = c.String(),
                        PowerPoints = c.String(),
                        PowerResistance = c.String(),
                        ShortDescription = c.String(),
                        XPCost = c.String(),
                        Description = c.String(),
                        Augment = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        SeedData = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Subtype = c.String(),
                        KeyAbility = c.String(),
                        Psionic = c.String(),
                        Trained = c.String(),
                        ArmorCheck = c.String(),
                        Description = c.String(),
                        SkillCheck = c.String(),
                        Action = c.String(),
                        TryAgain = c.String(),
                        Special = c.String(),
                        Restriction = c.String(),
                        Synergy = c.String(),
                        EpicUse = c.String(),
                        Untrained = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        SeedData = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spell",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AlternateName = c.String(),
                        School = c.String(),
                        Subschool = c.String(),
                        Descriptor = c.String(),
                        SpellcraftDC = c.String(),
                        Level = c.String(),
                        Components = c.String(),
                        CastingTime = c.String(),
                        Range = c.String(),
                        Target = c.String(),
                        Area = c.String(),
                        Effect = c.String(),
                        Duration = c.String(),
                        SavingThrow = c.String(),
                        SpellResistance = c.String(),
                        ShortDescription = c.String(),
                        ToDevelop = c.String(),
                        MaterialComponents = c.String(),
                        ArcaneMaterialComponents = c.String(),
                        Focus = c.String(),
                        Description = c.String(),
                        XPCost = c.String(),
                        ArcaneFocus = c.String(),
                        WizardFocus = c.String(),
                        VerbalComponents = c.String(),
                        SorcererFocus = c.String(),
                        BardFocus = c.String(),
                        ClericFocus = c.String(),
                        DruidFocus = c.String(),
                        FullText = c.String(),
                        Reference = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        SeedData = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Spell");
            DropTable("dbo.Skill");
            DropTable("dbo.Power");
            DropTable("dbo.Monster");
            DropTable("dbo.Item");
            DropTable("dbo.Feat");
            DropTable("dbo.Equipment");
            DropTable("dbo.Domain");
            DropTable("dbo.ClassProgression");
        }
    }
}

using System.Web;
using DungeonMart.Data.Models;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Models;

namespace DungeonMart.Mappers
{
    public class SpellMapper : BaseMapper<SpellViewModel, Spell, SpellSeed>
    {
        public override void MapSeedToEntity(SpellSeed seed, Spell entity)
        {
            entity.AlternateName = seed.altname;
            entity.ArcaneFocus = seed.arcane_focus;
            entity.ArcaneMaterialComponents = seed.arcane_material_components;
            entity.Area = seed.area;
            entity.BardFocus = seed.bard_focus;
            entity.CastingTime = seed.casting_time;
            entity.ClericFocus = seed.cleric_focus;
            entity.Components = seed.components;
            entity.Description = HttpUtility.HtmlDecode(seed.description);
            entity.Descriptor = seed.descriptor;
            entity.DruidFocus = seed.druid_focus;
            entity.Duration = seed.duration;
            entity.Effect = seed.effect;
            entity.Focus = seed.focus;
            entity.FullText = HttpUtility.HtmlDecode(seed.full_text);
            entity.Id = seed.Id;
            entity.Level = seed.level;
            entity.MaterialComponents = seed.material_components;
            entity.Name = seed.name;
            entity.Range = seed.range;
            entity.Reference = seed.reference;
            entity.SavingThrow = seed.saving_throw;
            entity.School = seed.school;
            entity.ShortDescription = seed.short_description;
            entity.SorcererFocus = seed.sorcerer_focus;
            entity.SpellResistance = seed.spell_resistance;
            entity.SpellcraftDC = seed.spellcraft_dc;
            entity.Subschool = seed.subschool;
            entity.Target = seed.target;
            entity.ToDevelop = seed.to_develop;
            entity.VerbalComponents = seed.verbal_components;
            entity.WizardFocus = seed.wizard_focus;
            entity.XPCost = seed.xp_cost;
        }
    }
}
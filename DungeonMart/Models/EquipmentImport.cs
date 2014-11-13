using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonMart.Models
{
    public class EquipmentImport
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string cost { get; set; }
        public string dmg_s { get; set; }
        public string armor_shield_bonus { get; set; }
        public string dmg_m { get; set; }
        public string weight { get; set; }
        public string critical { get; set; }
        public string armor_check_penalty { get; set; }
        public string arcane_spell_failure_chance { get; set; }
        public string range_increment { get; set; }
        public string speed_30 { get; set; }
        public string type { get; set; }
        public string speed_20 { get; set; }
        public string full_text { get; set; }
        public string reference { get; set; }
    }
}
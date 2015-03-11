namespace DungeonMart.Shared.Models
{
    public class Feat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FeatType { get; set; }

        public string Multiple { get; set; }

        public string Stack { get; set; }

        public string Choice { get; set; }

        public string Prerequisite { get; set; }

        public string Benefit { get; set; }

        public string Normal { get; set; }

        public string Special { get; set; }

        public string FullText { get; set; }

        public string Reference { get; set; }

        public bool SeedData { get; set; }
    }
}

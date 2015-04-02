namespace DungeonMart.Services.Helpers
{
    public class AbilityHelper
    {
        public static int GetModifier(int ability)
        {
            return (ability - 10)/2;
        }
    }
}
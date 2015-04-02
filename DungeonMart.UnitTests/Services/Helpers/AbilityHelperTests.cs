using DungeonMart.Services.Helpers;
using NUnit.Framework;

namespace DungeonMart.UnitTests.Services.Helpers
{
    [TestFixture]
    public class AbilityHelperTests
    {
        [Test]
        public void GetModifierLowStatTest()
        {
            var modifier = AbilityHelper.GetModifier(6);

            Assert.AreEqual(-2, modifier);
        }

        [Test]
        public void GetModifierAvgTest()
        {
            var modifier = AbilityHelper.GetModifier(11);

            Assert.AreEqual(0, modifier);
        }

        [Test]
        public void GetModifierHighStatTest()
        {
            var modifier = AbilityHelper.GetModifier(20);

            Assert.AreEqual(5, modifier);
        }
    }
}

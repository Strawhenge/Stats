using NUnit.Framework;

namespace Strawhenge.Stats.Unity.Tests
{
    static class StatContainerExtensions
    {
        public static void VerifyStat(this StatContainer statContainer, string statName, int expectedValue,
            int expectedMax)
        {
            var stat = AssertMaybe.HasSome(
                statContainer.FindStat(statName));

            Assert.AreEqual(expectedValue, stat.Value);
            Assert.AreEqual(expectedMax, stat.Max);
        }
    }
}
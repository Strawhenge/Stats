using FunctionalUtilities;

namespace Strawhenge.Stats.Unity
{
    public static class StatContainerExtensions
    {
        public static Maybe<Stat> FindStat(this StatContainer stats, StatReferenceScriptableObject stat) =>
            stats.FindStat(stat.Name);
    }
}
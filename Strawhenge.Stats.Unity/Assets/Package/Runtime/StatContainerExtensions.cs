namespace Strawhenge.Stats.Unity
{
    public static class StatContainerExtensions
    {
        public static Stat GetStat(this StatContainer stats, StatReferenceScriptableObject stat) =>
            stats.GetStat(stat.Name);
    }
}
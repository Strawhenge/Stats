namespace Strawhenge.Stats
{
    public static class StatExtensions
    {
        public static void Increase(this Stat stat, int amount) =>
            stat.Set(stat.BaseValue + amount);

        public static void Decrease(this Stat stat, int amount) =>
            stat.Set(stat.BaseValue - amount);

        public static void IncreaseMax(this Stat stat, int amount) =>
            stat.SexMax(stat.Max + amount);

        public static void DecreaseMax(this Stat stat, int amount) =>
            stat.SexMax(stat.Max - amount);
    }
}
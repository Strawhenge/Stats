namespace Strawhenge.Stats
{
    public static class StatExtensions
    {
        public static void FillToMax(this Stat stat) => stat.Set(stat.Max);
        
        public static void Increase(this Stat stat, int amount) =>
            stat.Set(stat.BaseValue + amount);

        public static void Decrease(this Stat stat, int amount) =>
            stat.Set(stat.BaseValue - amount);

        public static void IncreaseMax(this Stat stat, int amount, bool maintainPercentage = false) =>
            stat.SetMax(stat.Max + amount, maintainPercentage);

        public static void DecreaseMax(this Stat stat, int amount, bool maintainPercentage = false) =>
            stat.SetMax(stat.Max - amount, maintainPercentage);
    }
}
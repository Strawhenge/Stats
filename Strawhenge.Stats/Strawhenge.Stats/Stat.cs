using System;

namespace Strawhenge.Stats
{
    public class Stat
    {
        public Stat(string name)
        {
            Name = name;
        }

        public Stat(string name, int max, int value = 0) : this(name)
        {
            SetMax(max);
            Set(value);
        }

        public event Action Changed;

        public string Name { get; }

        public int Max { get; private set; }

        /// <summary>
        /// Value of this stat, including buffs.
        /// </summary>
        public int Value => Math.Min(BaseValue + Buff, Max);

        /// <summary>
        /// Value of this stat, ignoring buffs.
        /// </summary>
        public int BaseValue { get; private set; }

        public int Percentage =>
            Max == 0 ? 0 : (int)Math.Floor(Value * 100d / Max);

        public int Buff { get; private set; }

        public bool IsEmpty => Value == 0;

        public bool IsFull => Value == Max;

        public void Set(int value)
        {
            BaseValue = Math.Min(
                Math.Max(value, 0), Max);
            Changed?.Invoke();
        }

        public void SetMax(int max, bool maintainPercentage = false)
        {
            if (maintainPercentage)
                BaseValue = (int)Math.Round((double)BaseValue / Max * max);

            Max = Math.Max(max, 0);
            BaseValue = Math.Min(BaseValue, Max);
            Changed?.Invoke();
        }

        public void AddBuff(int buff)
        {
            Buff += buff;
            Changed?.Invoke();
        }

        public void RemoveBuff(int buff)
        {
            Buff -= buff;
            Changed?.Invoke();
        }
    }
}
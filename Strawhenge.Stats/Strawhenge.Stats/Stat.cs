using System;

namespace Strawhenge.Stats
{
    public class Stat
    {
        public Stat()
        {
        }

        public Stat(int max, int value = 0)
        {
            SexMax(max);
            Set(value);
        }

        public event Action Changed;

        public int Max { get; private set; }

        public int Value => Math.Min(BaseValue + Buff, Max);

        public int BaseValue { get; private set; }

        public int Percentage =>
            Max == 0 ? 0 : (int)Math.Round(Value * 100d / Max, MidpointRounding.AwayFromZero);

        public int Buff { get; private set; }

        public bool IsEmpty => Value == 0;

        public bool IsFull => Value == Max;

        public void Set(int value)
        {
            BaseValue = Math.Min(
                Math.Max(value, 0), Max);
            Changed?.Invoke();
        }

        public void SexMax(int max)
        {
            Max = Math.Max(max, 0);
            BaseValue = Math.Min(Value, Max);
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
using System;

namespace Strawhenge.Stats
{
    public class Stat
    {
        int _value;

        public Stat()
        {
        }

        public Stat(int max, int value = 0)
        {
            SexMax(max);
            Set(value);
        }

        public int Max { get; private set; }

        public int Value => Math.Min(_value + Buff, Max);

        public int Buff { get; private set; }

        public void Set(int value)
        {
            _value = Math.Min(
                Math.Max(value, 0), Max);
        }

        public void SexMax(int max)
        {
            Max = Math.Max(max, 0);
            _value = Math.Min(Value, Max);
        }

        public void AddBuff(int buff)
        {
            Buff += buff;
        }

        public void RemoveBuff(int buff)
        {
            Buff -= buff;
        }
    }
}
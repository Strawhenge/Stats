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
            Max = max;
            Value = value;
        }

        public int Max { get; private set; }

        public int Value { get; private set; }

        public void Set(int value)
        {
            Value = Math.Min(
                Math.Max(value, 0), Max);
        }

        public void SexMax(int max)
        {
            Max = Math.Max(max, 0);
            Value = Math.Min(Value, Max);
        }
    }
}
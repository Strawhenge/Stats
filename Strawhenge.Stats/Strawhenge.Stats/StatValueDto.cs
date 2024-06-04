namespace Strawhenge.Stats
{
    public class StatValueDto
    {
        public StatValueDto(string statName, int value)
        {
            StatName = statName;
            Value = value;
        }

        public string StatName { get; }

        public int Value { get; }
    }
}
namespace Strawhenge.Stats.Unity
{
    public interface IStatSetup
    {
        string Name { get; }

        int Max { get; }

        int Value { get; }
    }
}
using Xunit;
using Xunit.Abstractions;

namespace Strawhenge.Stats.Tests
{
    public class ImportTests
    {
        const string HealthStat = "Health";
        const string EnergyStat = "Energy";

        readonly StatContainer _stats;
        readonly Stat _health;
        readonly Stat _energy;

        public ImportTests(ITestOutputHelper testOutputHelper)
        {
            _stats = new StatContainer(
                new TestOutputHelperLogger(testOutputHelper));

            _health = _stats.GetStat(HealthStat);
            _health.SetMax(100);

            _energy = _stats.GetStat(EnergyStat);
            _energy.SetMax(100);
        }

        [Fact]
        public void Stat_values_should_be_updated_after_loading_stats()
        {
            const int healthValue = 75;
            const int energyValue = 100;

            _stats.Import(
                new StatValueDto(HealthStat, healthValue),
                new StatValueDto(EnergyStat, energyValue));

            Assert.Multiple(
                () => Assert.Equal(healthValue, _health.Value),
                () => Assert.Equal(energyValue, _energy.Value));
        }
    }
}
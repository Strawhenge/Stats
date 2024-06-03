using Xunit;

namespace Strawhenge.Stats.Tests
{
    public class StatTests
    {
        const string StatName = "Health";
        
        [Fact]
        public void Value_lower_than_max_should_be_able_to_be_set()
        {
            var stat = new Stat(StatName, max: 100);

            const int value = 50;
            stat.Set(value);

            Assert.Equal(value, stat.Value);
        }

        [Fact]
        public void Value_greater_than_max_should_set_to_max()
        {
            const int max = 100;
            var stat = new Stat(StatName, max);

            stat.Set(150);

            Assert.Equal(max, stat.Value);
        }

        [Fact]
        public void Value_lower_than_0_should_set_to_0()
        {
            var stat = new Stat(StatName, max: 100);

            stat.Set(-10);

            Assert.Equal(0, stat.Value);
        }

        [Fact]
        public void Value_should_remain_the_same_when_max_increased()
        {
            const int value = 100;
            var stat = new Stat(StatName, max: 100, value);

            stat.SetMax(150);
            ;
            Assert.Equal(value, stat.Value);
        }

        [Fact]
        public void Value_should_be_max_when_max_set_to_less_than_value()
        {
            var stat = new Stat(StatName, max: 100, value: 100);

            const int max = 90;
            stat.SetMax(max);

            Assert.Equal(max, stat.Value);
        }

        [Fact]
        public void Max_lower_than_0_should_set_to_0()
        {
            var stat = new Stat(StatName, max: 100, value: 100);

            stat.SetMax(-30);

            Assert.Equal(0, stat.Max);
            Assert.Equal(0, stat.Value);
        }

        [Theory]
        [InlineData(0, 200, 0)]
        [InlineData(200, 200, 100)]
        [InlineData(100, 200, 50)]
        [InlineData(199, 200, 99)]
        [InlineData(0, 0, 0)]
        public void Value_should_have_percentage_of_max(int value, int max, int expectedPercentage)
        {
            var stat = new Stat(StatName, max, value);

            Assert.Equal(expectedPercentage, stat.Percentage);
        }
    }
}
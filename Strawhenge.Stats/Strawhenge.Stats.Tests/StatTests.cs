using Xunit;

namespace Strawhenge.Stats.Tests
{
    public class StatTests
    {
        [Fact]
        public void Value_lower_than_max_should_be_able_to_be_set()
        {
            var stat = new Stat(max: 100);

            const int value = 50;
            stat.Set(value);

            Assert.Equal(value, stat.Value);
        }

        [Fact]
        public void Value_greater_than_max_should_set_to_max()
        {
            const int max = 100;
            var stat = new Stat(max);

            stat.Set(150);

            Assert.Equal(max, stat.Value);
        }

        [Fact]
        public void Value_lower_than_0_should_set_to_0()
        {
            var stat = new Stat(max: 100);

            stat.Set(-10);

            Assert.Equal(0, stat.Value);
        }

        [Fact]
        public void Value_should_remain_the_same_when_max_increased()
        {
            const int value = 100;
            var stat = new Stat(max: 100, value);

            stat.SexMax(150);

            Assert.Equal(value, stat.Value);
        }

        [Fact]
        public void Value_should_be_max_when_max_set_to_less_than_value()
        {
            var stat = new Stat(max: 100, value: 100);

            const int max = 90;
            stat.SexMax(max);

            Assert.Equal(max, stat.Value);
        }

        [Fact]
        public void Max_lower_than_0_should_set_to_0()
        {
            var stat = new Stat(max: 100, value: 100);

            stat.SexMax(-30);

            Assert.Equal(0, stat.Max);
            Assert.Equal(0, stat.Value);
        }
    }
}
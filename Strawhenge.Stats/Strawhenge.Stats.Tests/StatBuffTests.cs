using Xunit;

namespace Strawhenge.Stats.Tests
{
    public class StatBuffTests
    {
        const string StatName = "Energy";

        [Fact]
        public void Buff_should_increase_value_until_removed()
        {
            const int initialValue = 50;
            var stat = new Stat(StatName, max: 100, value: initialValue);

            const int buff = 20;

            stat.AddBuff(buff);
            Assert.Equal(70, stat.Value);

            stat.RemoveBuff(buff);
            Assert.Equal(initialValue, stat.Value);
        }

        [Fact]
        public void Buff_should_set_value_to_max_when_increased_value_is_greater_than_max_until_removed()
        {
            const int max = 100;
            const int initialValue = 50;
            var stat = new Stat(StatName, max, value: initialValue);

            const int buff = 60;

            stat.AddBuff(buff);
            Assert.Equal(max, stat.Value);

            stat.RemoveBuff(buff);
            Assert.Equal(initialValue, stat.Value);
        }

        [Fact]
        public void Value_should_be_set_value_plus_buffs_when_changed_while_buffs_added()
        {
            var stat = new Stat(StatName, max: 100, value: 50);

            const int value = 70;
            const int buff = 20;
            stat.AddBuff(buff);
            stat.Set(value);
            Assert.Equal(90, stat.Value);

            stat.RemoveBuff(buff);
            Assert.Equal(value, stat.Value);
        }
    }
}
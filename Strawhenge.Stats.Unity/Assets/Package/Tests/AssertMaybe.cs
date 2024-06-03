using FunctionalUtilities;
using NUnit.Framework;

namespace Strawhenge.Stats.Unity.Tests
{
    public static class AssertMaybe
    {
        public static T HasSome<T>(Maybe<T> maybe)
        {
            Assert.True(maybe.HasSome(out var value), message: "Expected some but was none.");
            return value;
        }
    }
}
using System;
using Strawhenge.Common.Logging;
using Xunit.Abstractions;

namespace Strawhenge.Stats.Tests
{
    class TestOutputHelperLogger : ILogger
    {
        readonly ITestOutputHelper _testOutputHelper;

        public TestOutputHelperLogger(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public void LogInformation(string message) =>
            _testOutputHelper.WriteLine($"[Information] {message}");

        public void LogWarning(string message) =>
            _testOutputHelper.WriteLine($"[Warning] {message}");

        public void LogError(string message) =>
            _testOutputHelper.WriteLine($"[Error] {message}");

        public void LogException(Exception exception) =>
            _testOutputHelper.WriteLine(exception.ToString());
    }
}
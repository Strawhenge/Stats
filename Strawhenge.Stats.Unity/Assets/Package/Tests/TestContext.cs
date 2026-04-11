using Strawhenge.Common.Unity;
using UnityEngine;

namespace Strawhenge.Stats.Unity.Tests
{
    public class TestContext : MonoBehaviour
    {
        public StatContainer StatContainer { get; private set; }

        void Awake()
        {
            var stats = GetComponent<StatsScript>();
            StatContainer = stats.StatContainer;

            if (TryGetComponent<StatsChangeOverTimeScript>(out var changeOverTime))
                changeOverTime.Stats = StatContainer;
        }
    }
}
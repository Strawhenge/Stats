using Strawhenge.Common.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Stats.Unity.Tests
{
    public class TestContext : MonoBehaviour
    {
        public StatContainer StatContainer { get; private set; }

        void Awake()
        {
            var logger = new UnityLogger(gameObject);

            StatContainer = new StatContainer(logger);

            var stats = GetComponent<StatsScript>();
            stats.StatContainer = StatContainer;
        }
    }
}
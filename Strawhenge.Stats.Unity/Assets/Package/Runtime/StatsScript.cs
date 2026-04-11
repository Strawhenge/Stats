using Strawhenge.Common.Unity;
using Strawhenge.Common.Unity.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    public class StatsScript : MonoBehaviour
    {
        [SerializeField]
        SerializedSource<IStatSetupGroup, SerializedStatSetupGroup, StatSetupGroupScriptableObject> _stats;

        [SerializeField] LoggerScript _logger;

        StatContainer _statContainer;

        public StatContainer StatContainer => _statContainer ??= Create();

        void Awake()
        {
            _statContainer ??= Create();
        }

        StatContainer Create()
        {
            var logger = _logger != null
                ? _logger.Logger
                : new UnityLogger(gameObject);

            var statContainer = new StatContainer(logger);

            if (_stats.TryGetValue(out var stats))
                foreach (var statSetup in stats.All())
                {
                    statContainer
                        .GetStat(statSetup.Name)
                        .SetMaxAndValue(statSetup.Max, statSetup.Value);
                }

            return statContainer;
        }
    }
}
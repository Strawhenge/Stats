using FunctionalUtilities;
using Strawhenge.Common.Unity.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    public class StatsScript : MonoBehaviour
    {
        [SerializeField]
        SerializedSource<IStatSetupGroup, SerializedStatSetupGroup, StatSetupGroupScriptableObject> _stats;

        public bool IsReady { get; private set; }

        public StatContainer StatContainer { private get; set; }

        public IReadOnlyList<Stat> Stats =>
            StatContainer.Stats;

        public Maybe<Stat> FindStat(string name) =>
            StatContainer.FindStat(name);

        public void Import(IEnumerable<StatValueDto> statValues) =>
            StatContainer.Import(statValues);

        public IReadOnlyList<StatValueDto> Export() =>
            StatContainer.Export();

        void Start()
        {
            var stats = _stats.GetValue();

            foreach (var stat in stats.All())
                StatContainer.AddStat(stat.Name, stat.Max, stat.Value);

            IsReady = true;
        }
    }
}
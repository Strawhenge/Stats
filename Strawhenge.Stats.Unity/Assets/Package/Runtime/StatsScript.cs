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

        public IReadOnlyList<Stat> Stats => StatContainer.Stats;

        public void FillToMax(StatReferenceScriptableObject stat) =>
            StatContainer.GetStat(stat).FillToMax();

        public void Set(StatReferenceScriptableObject stat, int value) =>
            StatContainer.GetStat(stat).Set(value);

        public Stat GetStat(string name) =>
            StatContainer.GetStat(name);

        public Stat GetStat(StatReferenceScriptableObject stat) =>
            StatContainer.GetStat(stat);

        public void Import(IEnumerable<StatValueDto> statValues) =>
            StatContainer.Import(statValues);

        public IReadOnlyList<StatValueDto> Export() =>
            StatContainer.Export();

        void Start()
        {
            var stats = _stats.GetValue();

            foreach (var statSetup in stats.All())
            {
                var stat = StatContainer.GetStat(statSetup.Name);
                stat.SetMax(statSetup.Max);
                stat.Set(statSetup.Value);
            }

            IsReady = true;
        }
    }
}
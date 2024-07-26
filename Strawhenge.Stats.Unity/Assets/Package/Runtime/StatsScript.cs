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

        public Stat GetStat(StatReferenceScriptableObject stat) =>
            StatContainer.GetStat(stat);

        public void Set(SetStatScriptableObject setStat) =>
            StatContainer.GetStat(setStat.Stat).Set(setStat.Value);

        public void Increase(IncreaseStatScriptableObject increaseStat) =>
            StatContainer.GetStat(increaseStat.Stat).Increase(increaseStat.Amount);

        public void FillToMax(StatReferenceScriptableObject stat) =>
            StatContainer.GetStat(stat).FillToMax();

        public void Import(IEnumerable<StatValueDto> statValues) =>
            StatContainer.Import(statValues);

        public IReadOnlyList<StatValueDto> Export() =>
            StatContainer.Export();

        void Start()
        {
            var stats = _stats.GetValue();

            foreach (var statSetup in stats.All())
            {
                StatContainer
                    .GetStat(statSetup.Name)
                    .SetMaxAndValue(statSetup.Max, statSetup.Value);
            }

            IsReady = true;
        }
    }
}
using Strawhenge.Common.Unity.Helpers;
using System.Collections;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    public class StatsChangeOverTimeScript : MonoBehaviour
    {
        [SerializeField] StatsScript _stats;
        [SerializeField] SerializedStatChangeOverTime[] _changes;

        void Awake()
        {
            ComponentRefHelper.EnsureRootHierarchyComponent(ref _stats, nameof(_stats), this);

            foreach (var change in _changes)
            {
                var stat = _stats.GetStat(change.Stat);
                ChangeOverTime(stat, change.Interval, change.Amount);
            }
        }

        void ChangeOverTime(Stat stat, int interval, int amount)
        {
            StartCoroutine(ChangeOverTimeCoroutine());

            IEnumerator ChangeOverTimeCoroutine()
            {
                while (enabled)
                {
                    yield return new WaitForSeconds(interval);
                    stat.Increase(amount);
                }
            }
        }
    }
}
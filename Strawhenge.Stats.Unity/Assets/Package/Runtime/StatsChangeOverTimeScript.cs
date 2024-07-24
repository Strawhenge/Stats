using System.Collections;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    public class StatsChangeOverTimeScript : MonoBehaviour
    {
        [SerializeField] StatsScript _stats;
        [SerializeField] SerializedStatChangeOverTime[] _changes;

        void OnEnable()
        {
            if (_stats == null)
            {
                Debug.LogError($"{nameof(StatsScript)} not set.", this);
                enabled = false;
                return;
            }

            StartCoroutine(BeginCoroutine());

            IEnumerator BeginCoroutine()
            {
                yield return new WaitUntil(() => _stats.IsReady);

                foreach (var change in _changes)
                {
                    var stat = _stats.GetStat(change.Stat);
                    ChangeOverTime(stat, change.Interval, change.Amount);
                }
            }
        }

        void ChangeOverTime(Stat stat, int interval, int amount)
        {
            StartCoroutine(ChangeOverTimeCoroutine());

            IEnumerator ChangeOverTimeCoroutine()
            {
                while (true)
                {
                    yield return new WaitForSeconds(interval);
                    stat.Increase(amount);
                }
            }
        }
    }
}
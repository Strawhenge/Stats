using System.Collections;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    public class StatsChangeOverTimeScript : MonoBehaviour
    {
        [SerializeField] SerializedStatChangeOverTime[] _changes;

        public StatContainer Stats { private get; set; }

        void OnEnable()
        {
            foreach (var change in _changes)
            {
                var stat = Stats.GetStat(change.Stat);
                ChangeOverTime(stat, change.Interval, change.Amount);
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
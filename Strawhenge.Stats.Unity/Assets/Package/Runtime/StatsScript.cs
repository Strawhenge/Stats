using FunctionalUtilities;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    public class StatsScript : MonoBehaviour
    {
        [SerializeField] SerializedStat[] _stats;

        public StatContainer StatContainer { private get; set; }

        public Maybe<Stat> FindStat(string name) => StatContainer.FindStat(name);

        public bool IsReady { get; private set; }

        void Start()
        {
            foreach (var stat in _stats)
            {
                StatContainer.AddStat(stat.Name, stat.Max, stat.Value);
            }

            IsReady = true;
        }
    }
}
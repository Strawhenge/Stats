using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    public class StatsScript : MonoBehaviour
    {
        [SerializeField] SerializedStat[] _stats;

        public StatContainer StatContainer { private get; set; }

        void Start()
        {
            foreach (var stat in _stats)
            {
                StatContainer.AddStat(stat.Name, stat.Max, stat.Value);
            }
        }
    }
}
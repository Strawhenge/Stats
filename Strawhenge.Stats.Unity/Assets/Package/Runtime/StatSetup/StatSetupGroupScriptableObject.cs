using Strawhenge.Common.Unity.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    [CreateAssetMenu(menuName = "Strawhenge/Stats/Stat Setup Group")]
    public class StatSetupGroupScriptableObject : ScriptableObject, IStatSetupGroup
    {
        [SerializeField] SerializedSource<IStatSetup, SerializedStatSetup, StatSetupScriptableObject>[] _stats;

        public IEnumerable<IStatSetup> All()
        {
            foreach (var stat in _stats)
                if (stat.TryGetValue(out var value))
                    yield return value;
        }
    }
}
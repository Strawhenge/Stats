using Strawhenge.Common.Unity.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    [Serializable]
    public class SerializedStatSetupGroup : IStatSetupGroup
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
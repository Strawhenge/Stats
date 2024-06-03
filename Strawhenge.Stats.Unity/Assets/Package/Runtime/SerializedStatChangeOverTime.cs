using System;
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    [Serializable]
    public class SerializedStatChangeOverTime
    {
        [SerializeField] StatReferenceScriptableObject _stat;

        [SerializeField, Tooltip("In seconds."), Min(0)]
        int _interval;

        [SerializeField] int _amount;

        public string StatName => _stat.Name;

        public int Interval => _interval;

        public int Amount => _amount;
    }
}
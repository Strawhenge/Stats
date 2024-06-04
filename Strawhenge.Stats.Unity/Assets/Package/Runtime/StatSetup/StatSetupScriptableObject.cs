using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    [CreateAssetMenu(menuName = "Strawhenge/Stats/Stat Setup")]
    public class StatSetupScriptableObject : ScriptableObject, IStatSetup
    {
        [SerializeField] StatReferenceScriptableObject _stat;
        [SerializeField] int _max;
        [SerializeField] int _value;

        public string Name => _stat.Name;

        public int Max => _max;

        public int Value => _value;
    }
}
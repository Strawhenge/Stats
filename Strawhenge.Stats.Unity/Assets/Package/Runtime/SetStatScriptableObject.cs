using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    [CreateAssetMenu(menuName = "Strawhenge/Stats/Set Stat")]
    public class SetStatScriptableObject : ScriptableObject
    {
        [SerializeField] StatReferenceScriptableObject _stat;
        [SerializeField] int _value;

        public StatReferenceScriptableObject Stat => _stat;

        public int Value => _value;
    }
}
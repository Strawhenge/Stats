using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    [CreateAssetMenu(menuName = "Strawhenge/Stats/Increase Stat")]
    public class IncreaseStatScriptableObject : ScriptableObject
    {
        [SerializeField] StatReferenceScriptableObject _stat;
        [SerializeField] int _amount;

        public StatReferenceScriptableObject Stat => _stat;

        public int Amount => _amount;
    }
}
using UnityEngine;

namespace Strawhenge.Stats.Unity
{
    [CreateAssetMenu(menuName = "Strawhenge/Stats/Stat")]
    public class StatReferenceScriptableObject : ScriptableObject
    {
        public string Name => name;
    }
}
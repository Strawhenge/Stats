using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Stats.Unity
{
    public class StatHudScript : MonoBehaviour
    {
        [SerializeField] Text _nameText;
        [SerializeField] Text _valueText;
        [SerializeField] StatReferenceScriptableObject _statReference;

        Stat _stat;
        
        public StatContainer Stats { private get; set; }
        
        void Start()
        {
            _stat = Stats.GetStat(_statReference);
            _nameText.text = _stat.Name;
            
            _stat.Changed += OnChanged;
            OnChanged();
        }

        void OnDestroy()
        {
            _stat.Changed -= OnChanged;
        }

        void OnChanged()
        {
            _valueText.text = _stat.Value.ToString();
        }
    }
}
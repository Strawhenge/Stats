using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Strawhenge.Stats.Unity
{
    public class StatHudScript : MonoBehaviour
    {
        [SerializeField] Text _nameText;
        [SerializeField] Text _valueText;
        [SerializeField] StatsScript _player;
        [SerializeField] StatReferenceScriptableObject _statReference;

        Stat _stat;

        void Start()
        {
            _stat = _player.GetStat(_statReference);
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
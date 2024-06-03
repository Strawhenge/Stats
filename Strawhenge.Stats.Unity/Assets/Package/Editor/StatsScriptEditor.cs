using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Stats.Unity.Editor
{
    [CustomEditor(typeof(StatsScript))]
    public class StatsScriptEditor : UnityEditor.Editor
    {
        StatsScript _target;
        Dictionary<string, bool> _foldout;
        int _setValue;
        int _setMax;
        int _setBuffIncrease;
        int _setBuffDecrease;

        void OnEnable()
        {
            _target ??= target as StatsScript;
            _foldout = new Dictionary<string, bool>();
        }

        public override void OnInspectorGUI()
        {
            if (_target.IsReady)
                InspectStats(_target.Stats);

            base.OnInspectorGUI();
        }

        void InspectStats(IReadOnlyList<Stat> stats)
        {
            foreach (var stat in stats)
                InspectStat(stat);
        }

        void InspectStat(Stat stat)
        {
            _foldout.TryAdd(stat.Name, false);

            _foldout[stat.Name] = EditorGUILayout.Foldout(_foldout[stat.Name], stat.Name);

            if (!_foldout[stat.Name])
                return;

            var info = new StringBuilder();
            info.AppendLine($"{nameof(Stat.Value)}: {stat.Value}");
            info.AppendLine($"{nameof(Stat.BaseValue)}: {stat.BaseValue}");
            info.AppendLine($"{nameof(Stat.Buff)}: {stat.Buff}");
            info.AppendLine($"{nameof(Stat.Percentage)}: {stat.Percentage}");
            info.AppendLine($"{nameof(Stat.Max)}: {stat.Max}");

            EditorGUILayout.HelpBox(info.ToString(), MessageType.Info);

            EditorGUILayout.BeginHorizontal();

            _setValue = EditorGUILayout.IntField(_setValue);

            if (GUILayout.Button(nameof(Stat.Set)))
                stat.Set(_setValue);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            _setBuffIncrease = EditorGUILayout.IntField(_setBuffIncrease);

            if (GUILayout.Button(nameof(Stat.AddBuff)))
                stat.AddBuff(_setBuffIncrease);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            _setBuffDecrease = EditorGUILayout.IntField(_setBuffDecrease);

            if (GUILayout.Button(nameof(Stat.RemoveBuff)))
                stat.RemoveBuff(_setBuffDecrease);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            _setMax = EditorGUILayout.IntField(_setMax);

            if (GUILayout.Button(nameof(Stat.SexMax)))
                stat.SexMax(_setMax);

            EditorGUILayout.EndHorizontal();
        }
    }
}
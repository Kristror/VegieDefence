using Assets.Code.Enemy;
using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Assets.Code.EditorScripts
{
    [CustomEditor(typeof(EnemyStats))]
    public class TestScriptableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var script = (EnemyStats) target;

            if (GUILayout.Button("Set to base stats", GUILayout.Height(40)))
            {
                script.SetBasicStats();
            }

        }
    }
}
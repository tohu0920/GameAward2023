using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StageManagerBase))]
public class StageManagerBaseEditor : Editor
{
    //public override void OnInspectorGUI()
    //{
    //    base.OnInspectorGUI();

    //    StageManagerBase manager = (StageManagerBase)target;

    //    GUILayout.Space(10);

    //    EditorGUILayout.LabelField("Stage Dictionary", EditorStyles.boldLabel);
    //    foreach (KeyValuePair<string, GameObject> pair in manager.Objects)
    //    {
    //        if(pair.Value != null)
    //            EditorGUILayout.LabelField(pair.Key, pair.Value.name);
    //    }
    //}
}
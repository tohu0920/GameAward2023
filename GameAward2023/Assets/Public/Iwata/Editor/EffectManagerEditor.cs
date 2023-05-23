#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EffectManager_iwata))]
public class EffectManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EffectManager_iwata effectManager = (EffectManager_iwata)target;

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Effect List", EditorStyles.boldLabel);

        for (int i = 0; i < effectManager.effectList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            effectManager.effectList[i].type = (EffectType)EditorGUILayout.EnumPopup("Type", effectManager.effectList[i].type);
            effectManager.effectList[i].effectPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab", effectManager.effectList[i].effectPrefab, typeof(GameObject), false);

            if (GUILayout.Button("-", GUILayout.Width(20f)))
            {
                effectManager.effectList.RemoveAt(i);
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Effect"))
        {
            effectManager.effectList.Add(new EffectInfo());
        }
    }
}
#endif
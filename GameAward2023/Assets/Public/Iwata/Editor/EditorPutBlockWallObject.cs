using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PutBlockWallObject))]
public class EditorPutBlockWallObject : Editor
{
    //OnInspectorGUIでカスタマイズのGUIに変更する
    public override void OnInspectorGUI()
    {
        //元のInspector部分を表示する
        base.OnInspectorGUI();

        //元のInspector部分の下にボタンを表示
        if (GUILayout.Button("Block更新"))
        {
            var hoge = target as PutBlockWallObject;
            hoge.Deploy();
        }
    }
}

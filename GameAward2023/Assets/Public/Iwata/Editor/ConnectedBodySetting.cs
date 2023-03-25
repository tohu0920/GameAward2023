using UnityEngine;
using UnityEditor;

public class ConnectedBodySetting : EditorWindow
{
    [MenuItem("Editor/ConnectedBodySetting")]
    private static void Create()
    {
        // ê∂ê¨
        GetWindow<ConnectedBodySetting>("ConnectedBodySetting");
    }

    private ConnectedBodySetting _sample;

    private void OnGUI()
    {
        if (_sample == null)
        {
            _sample = ScriptableObject.CreateInstance<ConnectedBodySetting>();
        }

        using (new GUILayout.HorizontalScope())
        {
            // èëÇ´çûÇ›É{É^Éì
            if (GUILayout.Button("ConnectedBodySetting"))
            {
                Export();
            }
        }
    }

    private void Export()
    {
        
    }
}

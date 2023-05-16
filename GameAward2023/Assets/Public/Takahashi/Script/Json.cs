using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PrefabData_Json
{
    public string m_prevabName;
    public string m_junkName;
    public string m_categoriz;
    public string m_property;
    public string m_explnation;
}

[System.Serializable]
public class PrefabList
{
    public List<PrefabData_Json> m_prefabs;
}

public class JunkData_Json
{
    public string m_junkName;
    public string m_categoriz;
    public string m_property;
    public string m_explnation;
}

public class Json : MonoBehaviour
{
    Dictionary<string, JunkData_Json> m_junkData;
    public Text textComponent;
    public Font font;
    public int fontSize = 64;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.fontSize = fontSize;
        if (font != null)
            textComponent.font = font;
    }

    public void SettingPrefab(string fileName)
    {
        //--- jsonファイルの読み込み
        PrefabList list;
        LoadJsonFile(fileName, out list);

        //--- 読み込んだデータを基に処理
        foreach (PrefabData_Json prefab in list.m_prefabs)
        {
            // ---データ作成
            JunkData_Json junk = new JunkData_Json();
            junk.m_junkName   = prefab.m_junkName;
            junk.m_categoriz  = prefab.m_categoriz;
            junk.m_property   = prefab.m_property;
            junk.m_explnation = prefab.m_explnation;
            m_junkData.Add(prefab.m_prevabName, junk);
        }
    }

    /// <summary>
	/// jsonファイルの読み込み
	/// </summary>
	static void LoadJsonFile<T>(string fileName, out T list)
    {
        //--- jsonファイルの読み込み
        string inputText = Resources.Load<TextAsset>(fileName).ToString();
        list = JsonUtility.FromJson<T>(inputText);  // 読み込んだデータをリスト化
    }

    /// <summary>
    /// jsonのテキスト表示
    /// </summary>
    /// <param name="prefabName"></param>
    public void DisplayText(string prefabName)
    {
        JunkData_Json junk = new JunkData_Json();
        junk = m_junkData[prefabName];
        textComponent.text  = junk.m_junkName   + "\n";
        textComponent.text += junk.m_categoriz  + "\n";
        textComponent.text += junk.m_property   + "\n";
        textComponent.text += junk.m_explnation;
    }

    public void ClearText(string prefabName)
    {
        textComponent.text = "";
    }
}

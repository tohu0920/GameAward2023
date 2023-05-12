using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ObjectData
{
	public string m_name;
	public float[] m_pos;
	public float m_rotY;
}

[System.Serializable]
public class JunkData
{
	public string m_name;
	public float[] m_pos;
	public float[] m_rot;
	public float[] m_params;
}

[System.Serializable]
public class ObjectList
{
	public List<ObjectData> m_objects;
}

[System.Serializable]
public class JunkList
{
	public List<JunkData> m_junks;
}

public static class LoadStageData_araki
{
	/// <summary>
	/// ステージ上にオブジェクトを設置
	/// </summary>
	public static void SettingStageObjects(string fileName)
	{
		//--- jsonファイルの読み込み
		ObjectList list;
		LoadJsonFile(fileName, out list);

		//--- 読み込んだデータを基に処理
		foreach (ObjectData obj in list.m_objects)
		{
			//--- データを作成
			Object prefab = Resources.Load<Object>("Prefabs/" + obj.m_name);
			Vector3 pos = new Vector3(obj.m_pos[0], obj.m_pos[1], obj.m_pos[2]);
			Quaternion rot = Quaternion.Euler(0.0f, obj.m_rotY, 0.0f);	// X.Z回転は必要ない

			// オブジェクトを生成
			GameObject.Instantiate(prefab, pos, rot);
		}
	}

	/// <summary>
	/// 読み込んだガラクタを設置
	/// </summary>
	public static void SettingJunks(string fileName)
	{
		//--- jsonファイルの読み込み
		JunkList list;
		LoadJsonFile(fileName, out list);

		//--- 読み込んだデータを基に処理
		foreach (JunkData junk in list.m_junks)
		{
			//--- データを作成
			Object prefab = Resources.Load<Object>("Prefabs/" + junk.m_name);
			Vector3 pos = new Vector3(junk.m_pos[0], junk.m_pos[1], junk.m_pos[2]);
			Quaternion rot = Quaternion.Euler(junk.m_rot[0], junk.m_rot[1], junk.m_rot[2]);  // X.Z回転は必要ない

			// オブジェクトを生成
			GameObject gameObject = (GameObject)GameObject.Instantiate(prefab, pos, rot);	
#if false	//TODO:JunkBaseにSetParam()を作成したら解禁
			JunkBase junkBase = gameObject.GetComponent<JunkBase>();
			junkBase.SetParam(junk.m_params);	// パラメータを設定
#endif
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
}
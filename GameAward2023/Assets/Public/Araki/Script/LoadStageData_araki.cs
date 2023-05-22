using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ObjectData
{
	public string m_name;
	public float[] m_pos;
	public float[] m_rot;
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

		// ガラクタを保持する親オブジェクト
		GameObject stageObjectPparent = GameObject.Find("StageObject");

		//--- 読み込んだデータを基に処理
		foreach (ObjectData obj in list.m_objects)
		{
			//--- データを作成
			Object objData = Resources.Load<Object>("Prefabs/" + obj.m_name);
			GameObject prefab = (GameObject)objData;

			//--- オブジェクトの子の情報を全て取得
			IEnumerable<Transform> children = prefab.GetComponentsInChildren<Transform>(true);
			int j = 0;
			foreach (Transform child in children)
			{
				//--- 座標
				child.position = new Vector3(
					obj.m_pos[j * 3 + 0], obj.m_pos[j * 3 + 1], obj.m_pos[j * 3 + 2]);

				//--- 回転
				child.localEulerAngles = new Vector3(
					obj.m_rot[j * 3 + 0], obj.m_rot[j * 3 + 1], obj.m_rot[j * 3 + 2]);

				j++;
			}

			//--- オブジェクトを生成
			Transform prefabData = prefab.transform;
			GameObject stageObject = (GameObject)GameObject.Instantiate(
				objData, prefabData.position, prefabData.localRotation);

			// 親オブジェクトが無い場合は処理しない
			if (stageObjectPparent == null) continue;

			// 親をJankに設定
			stageObject.transform.SetParent(stageObjectPparent.transform);

			stageObject.name = prefab.name;	// 名前をプレハブと一致させる
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
		
		// ガラクタを保持する親オブジェクト
		GameObject junkPparent = GameObject.Find("Jank");

		//--- 読み込んだデータを基に処理
		foreach (JunkData junk in list.m_junks)
		{
			//--- データを作成
			Object prefab = Resources.Load<Object>("Prefabs/" + junk.m_name);
			Vector3 pos = new Vector3(junk.m_pos[0], junk.m_pos[1], junk.m_pos[2]);
			Quaternion rot = Quaternion.Euler(junk.m_rot[0], junk.m_rot[1], junk.m_rot[2]);  // X.Z回転は必要ない

			// オブジェクトを生成
			GameObject gameObject = (GameObject)GameObject.Instantiate(prefab, pos, rot);	

			//--- パラメータを設定
			List<float> param = new List<float>();
			for (int i = 0; i < junk.m_params.Length; i++)
				param.Add(junk.m_params[i]);

			JankBase_iwata junkBase = gameObject.GetComponent<JankBase_iwata>();
			junkBase.SetParam(param);   // パラメータを設定

			// 親オブジェクトが無い場合は処理しない
			if (junkPparent == null) continue;

			// 親をJankに設定
			gameObject.transform.SetParent(junkPparent.transform);
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
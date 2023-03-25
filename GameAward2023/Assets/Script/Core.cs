using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
	const float ROT = 90.0f;  // 回転角度

	[SerializeReference] float m_dampingRate;   // 減衰率
	int m_timeToRotate;     // 回転に必要なフレーム数
	int m_rotFrameCnt;      // 回転時のフレームカウント
	int m_rotFrameCntX;      // 回転時のフレームカウント
	float m_rotY, m_lateY; // 回転パラメータ
	float m_rotX, m_lateX; // 回転パラメータ

	// Start is called before the first frame update
	void Start()
	{
		m_rotFrameCnt = -1;
		m_rotFrameCntX = -1;
		m_rotY = m_lateY = 0.0f;
		m_rotX = m_lateX = 0.0f;
		m_timeToRotate = (int)(Mathf.Log(0.005f) / Mathf.Log(1.0f - m_dampingRate));
	}

	// Update is called once per frame
	void Update()
	{
		RotateCoreY((int)Input.GetAxisRaw("Horizontal"));
		RotateCoreX((int)Input.GetAxisRaw("Vertical"));

		float lastY = m_lateY;
		float lastX = m_lateX;

		// 遅延処理
		m_lateY = (m_rotY - m_lateY) * m_dampingRate + m_lateY;
		m_lateX = (m_rotX - m_lateX) * m_dampingRate + m_lateX;

		// 座標計算
		//this.transform.eulerAngles = new Vector3(0.0f , m_lateY, 0.0f);
		//this.transform.eulerAngles = new Vector3(m_lateX, m_lateY, 0.0f);
		this.transform.Rotate(Vector3.up, m_lateY - lastY, Space.World);
		this.transform.Rotate(Vector3.right, m_lateX - lastX, Space.World);
		//this.transform.Rotate(new Vector3(m_lateX, m_lateY, 0.0f), Space.World);

		Debug.Log("lateX" + m_lateX);
		Debug.Log("lateY" + m_lateY);

		if (m_rotFrameCnt >= 0)
		{
			m_rotFrameCnt++;    // 回転中のフレームカウント

			if (m_rotFrameCnt > m_timeToRotate) m_rotFrameCnt = -1; // カウントのリセット
		}

		if(m_rotFrameCntX >= 0)
		{
			m_rotFrameCntX++;

			if (m_rotFrameCntX > m_timeToRotate) m_rotFrameCntX = -1;
		}
	}

	/// <summary>
	/// コアのY回転開始
	/// </summary>
	public void RotateCoreY(int direction)
	{
		if (direction == 0) return;
		if (m_rotFrameCnt > 0) return;
		if (m_rotFrameCntX > 0) return;

		m_rotY += ROT * direction;

		m_rotFrameCnt = 0;
	}

	/// <summary>
	/// コアのX回転開始
	/// </summary>
	public void RotateCoreX(int direction)
	{
		if (direction == 0) return;
		if (m_rotFrameCnt > 0) return;
		if (m_rotFrameCntX > 0) return;

		m_rotX -= ROT * direction;

		m_rotFrameCntX = 0;
	}

	/// <summary>
	/// 部品をアタッチ出来る面を取得
	/// </summary>
	public List<Transform> GetAttachFace()
	{
		List<Transform> attachFace = new List<Transform>();

		//--- 子オブジェクトを順番に配列に格納
		foreach (Transform child in this.transform)
		{
			Ray ray = new Ray(child.position, Vector3.back);
			RaycastHit hit;
			if (!Physics.Raycast(ray, out hit, 10.0f))
				attachFace.Add(child);
		}

		//--- ソート
		attachFace.Sort((a, b) => {
			if (a.position.y != b.position.y)
			{
				// Y 座標が異なる場合は Y 座標で比較する
				return b.position.y.CompareTo(a.position.y);
			}
			else
			{
				// Y 座標が同じ場合は X 座標で比較する
				return a.position.x.CompareTo(b.position.x);
			}
		});

		return attachFace;
	}

	/// <summary>
	/// 回転終了フラグ
	/// </summary>
	public bool IsRotEnd()
	{
		if (m_rotFrameCnt > m_timeToRotate)
		{
			m_rotFrameCnt = -1; // カウントのリセット
			return true;
		}

		return false;
	}

	/// <summary>
	/// 部品をアタッチする
	/// </summary>
	public void AttachParts(Transform face, GameObject prefabParts)
	{
		Vector3 pos = face.position + (Vector3.forward.normalized * -1.0f);
		GameObject parts = Instantiate(prefabParts, pos, Quaternion.identity);

		parts.transform.SetParent(this.transform);
	}
}
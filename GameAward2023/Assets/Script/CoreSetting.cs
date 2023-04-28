using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSetting : MonoBehaviour
{
	const float ROTATION	 = 90.0f;   // 回転角度
	const float DAMPING_RATE = 0.5f;   // 回転減衰率

	List<Transform> m_AttachFaces;	// 組み立てられる面
	int m_selectFaceNum;			// 選択面の番号
	int m_timeToRotate;				// 回転時間
	float m_rotateY, m_rotateX;     // 角度
	float m_lateY, m_lateX;			// 遅延角度
	int m_rotateFrameCnt;           // 回転フレームのカウント]
	bool m_isDepath;		// 面情報を取得し直すフラグ

    [SerializeReference] AudioClip m_RotSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
		m_AttachFaces = GetAttachFace();	// 組み立てられる面を取得
		m_selectFaceNum = 0;
		m_rotateY = m_rotateX = 0.0f;
		m_lateY = m_lateX = 0.0f;

		// 回転時間を計算
		m_timeToRotate = (int)(Mathf.Log(0.00001f) / Mathf.Log(1.0f - DAMPING_RATE));

		// 選択中の面を大きく協調する
		m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.25f, 1.25f, 1.25f);

		m_isDepath = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		//--- 回転中
		if(m_rotateFrameCnt > 0)
		{
			RotateCore();	// 回転処理			
			return;
		}

		if(m_isDepath)
		{
			m_AttachFaces = GetAttachFace();    // 次の組み立てられる面を取得
		
			// 選択中の面を大きく協調する
			m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.25f, 1.25f, 1.25f);
			Debug.Log(m_selectFaceNum);
			Debug.Log(m_AttachFaces.Count);
			for (int i = 0; i < m_AttachFaces.Count; i++)
			{
				Vector3 pos = m_AttachFaces[i].position;
				Debug.Log("X:" + pos.x + " Y:" + pos.y + " Z:" + pos.z);
			}
		
			m_isDepath = false;
		}

		SelectFace();   // 面を選択
	}

	/// <summary>
	/// 組み立てられる面を返す
	/// </summary>
	List<Transform> GetAttachFace()
	{
		// 面の格納先を用意
		List<Transform> attachFaces = new List<Transform>();

		//--- 組み立てられる面を順番に格納
		foreach (Transform child in this.transform)
		{
			// 手前に伸びるレイを用意
			Ray ray = new Ray(child.position, Vector3.back);
			RaycastHit hit;

            // 組み立てられない面はスルー
            // 手前に物があったらスキップ
            if (Physics.Raycast(ray, out hit, 10.0f)) continue;

            attachFaces.Add(child);	// 面を格納
		}

		//--- ソート
		attachFaces.Sort((a, b) => {
			//if (a.position.y != b.position.y)
			if(Mathf.Abs(a.position.y - b.position.y) > 0.75f)
			{
				// Y座標が異なる場合はY座標で比較する
				return b.position.y.CompareTo(a.position.y);
			}
			else
			{
				// Y座標が同じ場合はX座標で比較する
				return a.position.x.CompareTo(b.position.x);
			}
		});

		return attachFaces;
	}

	/// <summary>
	/// 面の選択
	/// </summary>
	void SelectFace()
	{
		int lastSelectFaceNum = m_selectFaceNum;	// 過去の選択面番号を格納

		float axisX = AxisInput.GetAxisRawRepeat("Horizontal_PadX");         // 横に移動

		//--- 横に入力があった時のみ処理
		if (axisX != 0)
		{
			Vector3 facePos = m_AttachFaces[m_selectFaceNum].position;  // 現在の面の座標を取得
			facePos.x += axisX; // 移動先の面の座標に修正

			bool isRotate = true;

			//--- 一致する面を探索
			for (int i = 0; i < m_AttachFaces.Count; i++)
			{
				//--- 現在の面と次の面のXY座標をVector2に格納
				Vector2 currentFacePos = new Vector2(m_AttachFaces[i].position.x, m_AttachFaces[i].position.y);
				Vector2 newxtFacePos = new Vector2(facePos.x, facePos.y);

				// XY平面での距離が離れすぎていたらスルー
				if (Vector2.Distance(currentFacePos, newxtFacePos) > 0.05f) continue;

				m_selectFaceNum = i;
				isRotate = false;
				break;
			}

			if (isRotate)
			{
				m_AttachFaces[lastSelectFaceNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);    // 過去の面を初期化
				StartRotateY((int)axisX);
				return;
			}
		}

		float axisY = (float)AxisInput.GetAxisRawRepeat("Vertical_PadX");    // 縦に移動

		//--- 縦に入力があった時のみ処理
		if (axisY != 0)
		{
			Vector3 facePos = m_AttachFaces[m_selectFaceNum].position;	// 現在の面の座標を取得
			facePos.y += axisY; // 移動先の面の座標に修正

			bool isRotate = true;

			//--- 一致する面を探索
			for (int i = 0; i < m_AttachFaces.Count; i++)
			{
				//--- 現在の面と次の面のXY座標をVector2に格納
				Vector2 currentFacePos = new Vector2(m_AttachFaces[i].position.x, m_AttachFaces[i].position.y);
				Vector2 newxtFacePos = new Vector2(facePos.x, facePos.y);

				// XY平面での距離が離れすぎていたらスルー
				if (Vector2.Distance(currentFacePos, newxtFacePos) > 0.05f) continue;

				m_selectFaceNum = i;
				isRotate = false;
				break;
			}

			if (isRotate)
			{
				m_AttachFaces[lastSelectFaceNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);    // 過去の面を初期化
				StartRotateX((int)axisY);
				return;
			}
		}

		//--- 選択面が変更された場合
		if (m_selectFaceNum != lastSelectFaceNum)
		{
			m_AttachFaces[lastSelectFaceNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);	// 過去の面を初期化
			m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.25f, 1.25f, 1.25f);	// 現在の面を協調
		}

	}

	/// <summary>
	/// コアの回転処理
	/// </summary>
	void RotateCore()
	{
		float lastY = m_lateY;
		float lastX = m_lateX;

		//--- 遅延処理
		m_lateY = (m_rotateY - m_lateY) * DAMPING_RATE + m_lateY;
		m_lateX = (m_rotateX - m_lateX) * DAMPING_RATE + m_lateX;

		//--- 座標計算
		this.transform.Rotate(Vector3.up, m_lateY - lastY, Space.World);
		this.transform.Rotate(Vector3.right, m_lateX - lastX, Space.World);

		m_rotateFrameCnt++; // 回転フレームカウント

		//--- 回転終了時の処理
		if (m_rotateFrameCnt > m_timeToRotate)
		{
			m_AttachFaces = GetAttachFace();    // 次の組み立てられる面を取得
			m_rotateFrameCnt = 0;   // 回転フレームをリセット
			m_selectFaceNum = 0;    // 選択面の番号をリセット
			m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.25f, 1.25f, 1.25f);   // 現在の面を協調
		}
	}

	/// <summary>
	/// コアのY軸回転開始
	/// </summary>
	void StartRotateY(int direction)
	{
		if (direction == 0) return;

		m_rotateY += ROTATION * direction;	// 角度を設定
		m_rotateFrameCnt = 1;	// 最初のカウント
        audioSource.PlayOneShot(m_RotSound);    //SEの再生
    }

	/// <summary>
	/// コアのX軸回転開始
	/// </summary>
	void StartRotateX(int direction)
	{
		if (direction == 0) return;

		m_rotateX -= ROTATION * direction;  // 角度を設定
		m_rotateFrameCnt = 1;   // 最初のカウント
        audioSource.PlayOneShot(m_RotSound);    //SEの再生
    }

	/// <summary>
	/// FixedJointを追加
	/// </summary>
	void AddFixedJoint(GameObject junk, Vector3 junkPos, Vector3 direction)
	{
		// 指定方向に伸びるレイを用意
		Ray ray = new Ray(junkPos, direction);
		RaycastHit hit;

		// 指定方向にガラクタが存在しないならスルー
		if (!Physics.Raycast(ray, out hit, 1.0f)) return;

		//--- ガラクタの場合、組み立てられる面かを判定する
        //iwata:ここコアとミニコアをPlayerタグつけてPlayerを判定する
		if (hit.transform.tag == "Player")
		{
			JunkSetting junkSetting = hit.transform.GetComponent<JunkSetting>();
			if (!junkSetting.CanAttach(-direction))	return;
		}

		//--- FixedJointを設定
		FixedJoint fixedJoint = junk.AddComponent<FixedJoint>();
		fixedJoint.connectedBody = hit.rigidbody;
		fixedJoint.breakForce = 2000.0f;
		fixedJoint.breakTorque = 2000.0f;

		Rigidbody junkRigidbody = junk.GetComponent<Rigidbody>();
		junkRigidbody.constraints = RigidbodyConstraints.FreezeAll; // 座標・角度を固定する
		junkRigidbody.isKinematic = false;  // 物理演算を有効化
	}

	/// <summary>
	/// FixedJointを削除
	/// </summary>
	void RemoveFixedJoint(GameObject junk, Vector3 direction)
	{
		// 指定方向に伸びるレイを用意
		Ray ray = new Ray(junk.transform.position, direction);
		RaycastHit hit;

		// 指定方向にガラクタが存在しないならスルー
		if (!Physics.Raycast(ray, out hit, 1.0f)) return;

		//--- ガラクタの場合、組み立てられる面かを判定する
		if (hit.transform.tag == "Junk")
		{
			JunkSetting junkSetting = hit.transform.GetComponent<JunkSetting>();
			if (!junkSetting.CanAttach(-direction)) return;
		}

		//--- 周囲の自身を繋いでいるFixedJointを削除
		Rigidbody rigidbody = junk.GetComponent<Rigidbody>();
		FixedJoint[] fixedJoints = hit.transform.GetComponents<FixedJoint>();
		for(int i = 0; i < fixedJoints.Length; i++)
		{
			if (rigidbody != fixedJoints[i].connectedBody) continue;

			Destroy(fixedJoints[i]);
		}
	}

	/// <summary>
	/// 回転中フラグを取得
	/// </summary>
	public bool IsRotate()
	{
		return (m_rotateFrameCnt > 0);
	}

	/// <summary>
	/// ガラクタをアタッチする
	/// アタッチの成功フラグを返す
	/// </summary>
	public bool AttachJunk(GameObject junk)
	{
        if (junk.tag == "Junk" && m_AttachFaces[m_selectFaceNum].tag == "Junk") return false;

		//--- 組み立てられない面であればキャンセル
		if(m_AttachFaces[m_selectFaceNum].transform.tag == "Junk")
		{
			//--- 組み立てられない場合
			if (!m_AttachFaces[m_selectFaceNum].GetComponent<JunkSetting>().CanAttach(Vector3.back))	return false;
		}

		m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);

		//--- アタッチする座標を指定
		Vector3 junkPos = m_AttachFaces[m_selectFaceNum].position;
		//Vector3 junkPos = face.position;
		junkPos -= Vector3.forward.normalized * 1.0f;
		junk.transform.position = junkPos;

		JunkSetting junkSetting = junk.GetComponent<JunkSetting>();
		List<Vector3> searchDirects = junkSetting.GetAttachVector();

		//--- 各方向にFixedJointを設定
		for (int i = 0; i < searchDirects.Count; i++)
			AddFixedJoint(junk, junkPos, searchDirects[i]);

		junk.transform.SetParent(this.transform);   // コアの子にする

		m_AttachFaces = GetAttachFace();    // 次の組み立てられる面を取得
		
		// 選択中の面を大きく協調する
		m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.25f, 1.25f, 1.25f);

		return true;
	}

	public void DetachJunk()
	{
		// ガラクタでない場合スルー
		if (m_AttachFaces[m_selectFaceNum].transform.tag != "Junk") return;

		m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);

		// 探索する方向を取得
		List<Vector3> searchDirects = m_AttachFaces[m_selectFaceNum].transform.GetComponent<JunkSetting>().GetAttachVector();

		//--- 各方向のFixedJointを削除
		for (int i = 0; i < searchDirects.Count; i++)
			RemoveFixedJoint(
				m_AttachFaces[m_selectFaceNum].transform.gameObject,
				searchDirects[i]);

		//--- 自身のFixedJointを全て削除
		FixedJoint[] joints = m_AttachFaces[m_selectFaceNum].transform.GetComponents<FixedJoint>();
		for (int i = 0; i < joints.Length; i++)
			Destroy(joints[i]);

		//--- ゴミ山に戻す
		Transform junkTransform = m_AttachFaces[m_selectFaceNum].transform;
		junkTransform.GetComponent<JunkController>().ResetTransform();

		m_isDepath = true;	// 面情報を取得し直すフラグを立てる

		// HACK:即実行すると面の情報が上手く取得されない為
		/**
		 *	if (m_isDepath)
		 *	{
		 *		m_AttachFaces = GetAttachFace();    // 次の組み立てられる面を取得
		 *
		 *		// 選択中の面を大きく協調する
		 *		m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.25f, 1.25f, 1.25f);
		 *		Debug.Log(m_selectFaceNum);
		 *		Debug.Log(m_AttachFaces.Count);
		 *		for (int i = 0; i < m_AttachFaces.Count; i++)
		 *		{
		 *			Vector3 pos = m_AttachFaces[i].position;
		 *			Debug.Log("X:" + pos.x + " Y:" + pos.y + " Z:" + pos.z);
		 *		}
		 *
		 *		m_isDepath = false;
		 *	}
		 */
	}

	/// <summary>
	/// コア自身の準備
	/// </summary>
	public void CoreReady()
	{
		m_AttachFaces[m_selectFaceNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);

		foreach (Transform child in this.transform)
		{
			// 固定を解除
			child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

			// スタート位置へ移動
			this.transform.position = new Vector3(-10.0f, 2.5f, -10.0f);
		}
	}
}
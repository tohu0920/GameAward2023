using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--- レイの衝突状況の遷移
enum E_RAY_HIT_STATE
{
	ENTER,	//当たった瞬間
	EXIT,	//離れた瞬間
	STAY,	//当たっている
	NOT_HIT	//当たっていない
}

public class CursorController_araki : MonoBehaviour
{
	static RectTransform m_rectTransform;   // カーソルの座標情報
    [SerializeReference] GameObject m_lastPointJunk; // 前フレームで指していたガラクタのデータ
    [SerializeReference] GameObject m_previewJunk;   // プレビュー用ガラクタのデータ
	[SerializeReference]PreviewCamera_araki m_previreCamera;

	// Start is called before the first frame update
	void Start()
	{
		m_rectTransform = GetComponent<RectTransform>();
		m_rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
		m_lastPointJunk = null;
	}

    // Update is called once per frame
    void Update()
    {
		//--- プレビュー用ガラクタを生成
		switch (CheckRayHitState())
		{
			case E_RAY_HIT_STATE.ENTER: // 指した瞬間
				m_previreCamera.StartNoise();	// ノイズを再生		
				break;
			case E_RAY_HIT_STATE.EXIT:  // 離れた瞬間
				m_previreCamera.EndPreview();
				Destroy(m_previewJunk);
				m_previewJunk = null;
				break;
			case E_RAY_HIT_STATE.STAY:
				if (!m_previreCamera.isEndNoise) break;

				//--- ノイズが終わったらガラクタを生成
				m_previewJunk = (GameObject)Instantiate((Object)m_lastPointJunk,
					new Vector3(1114.4f, 0.0f, 2.5f), Quaternion.identity);
				// 動作を固定
				m_previewJunk.GetComponent<Rigidbody>().constraints
					= RigidbodyConstraints.FreezeAll;
				m_previewJunk.AddComponent<PreviewJunk_araki>();
				break;
			default:    // 上記以外の場合は処理しない
				break;
		}

		//--- 移動処理
		Vector2 pos = m_rectTransform.anchoredPosition;
		pos.x += PadInput.GetAxis("Horizontal_R") * 7.5f;
		pos.y += PadInput.GetAxis("Vertical_R") * 7.5f;

		//--- 画面外に出ていくのを防ぐ(左画面のみ移動可能)
		if (pos.x >  Screen.width / 2.0f) pos.x =  Screen.width / 2.0f;
		if (pos.x < -Screen.width / 2.0f) pos.x = -Screen.width / 2.0f;
		if (pos.y >  Screen.height / 2.0f) pos.y =  Screen.height / 2.0f;
		if (pos.y < -Screen.height / 2.0f) pos.y = -Screen.height / 2.0f;

		m_rectTransform.anchoredPosition = pos;	// カーソルの位置を確定
	}

	/// <summary>
	/// カーソルとガラクタの衝突状況を取得
	/// </summary>
	E_RAY_HIT_STATE CheckRayHitState()
	{
		//--- カメラを取得
		GameObject cam = GameObject.Find("JointCamera");
		if (cam == null) return E_RAY_HIT_STATE.NOT_HIT;    // カメラが無ければ処理しない

		//--- レイで当たり判定を取る
		Ray ray = GetCameraToRay(cam);
		RaycastHit hit;
		// 入れ子を削減する為に否定で判定
		if (!Physics.Raycast(ray, out hit)) // カーソルが指す物を取得
		{
			GameObject temp = m_lastPointJunk;
			m_lastPointJunk = null; // 過去のデータをリセット

			// 前フレームでガラクタを指していた場合
			if (temp != null) return E_RAY_HIT_STATE.EXIT;

			return E_RAY_HIT_STATE.NOT_HIT;
		}

		GameObject hitJunk = hit.transform.gameObject;

		// ガラクタに当たっていなければ処理しない
		if (hitJunk.transform.parent.name != "Jank")
		{
			GameObject temp = m_lastPointJunk;
			m_lastPointJunk = null; // 過去のデータをリセット

			// 前フレームでガラクタを指していた場合
			if (temp != null) return E_RAY_HIT_STATE.EXIT;

			return E_RAY_HIT_STATE.NOT_HIT;
		}

		//--- 前フレームでガラクタを指していなかった場合
		if (m_lastPointJunk == null)
		{
			m_lastPointJunk = hitJunk;  // 過去のデータとして退避
			return E_RAY_HIT_STATE.ENTER;
		}

		// 指し続けている場合
		if (m_lastPointJunk == hitJunk) return E_RAY_HIT_STATE.STAY;

		//--- 何も指さなくなった場合
		m_lastPointJunk = null; // 過去のデータをリセット
		return E_RAY_HIT_STATE.EXIT;
	}

	/// <summary>
	/// カーソルからのレイを取得
	/// </summary>
	public static Ray GetCameraToRay(GameObject cam)
	{
        // カメラ→カーソル(ワールド座標系)のレイを取得
		Vector2 pos = m_rectTransform.anchoredPosition;
        Camera camdata = cam.GetComponent<Camera>();
        Debug.Log(camdata.transform.name);
		return camdata.ScreenPointToRay(new Vector3(pos.x + Screen.width / 2.0f, pos.y + Screen.height / 2.0f, 0.0f));
	}

    public GameObject SelectJank
    {
        get { return m_lastPointJunk; }
    }
}
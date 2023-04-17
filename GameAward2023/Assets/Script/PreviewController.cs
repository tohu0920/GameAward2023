using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController : MonoBehaviour
{
	[SerializeReference] TargetFace m_targetFace;
	[SerializeReference] CoreController m_coreController;
	[SerializeReference] SeController m_seController;

    // Start is called before the first frame update
    void Start()
    {
		this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		// Aボタン
		if(Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			//--- 回転中でない時のみ処理
			if (!m_coreController.CoreSetting.IsRotate())
			{
				bool isAttach = false;

				//--- 子オブジェクトからガラクタを探索
				foreach (Transform child in this.transform)
				{
					// ガラクタ以外はスルー
					if (child.transform.tag != "Junk") continue;

					isAttach = m_coreController.CoreSetting.AttachJunk(child.gameObject);
					break;
				}

				//--- アタッチが成功した時のみ処理する
				if (isAttach)
				{
					Active = false; // 自分自身を無効化
					m_seController.PlaySe("SetParts");
				}
			}
		}

		// Bボタン
        if(Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			//--- 子オブジェクトからガラクタを探索
			foreach(Transform child in this.transform)
			{
				// ガラクタ以外はスルー
				if (child.transform.tag != "Junk") continue;

				child.GetComponent<JunkController>().ResetTransform();	// 座標・回転・親を初期化
			}

			Active = false;	// 自分自身を無効化
		}
    }

	public bool Active
	{
		set { this.gameObject.SetActive(value); }
		get { return this.gameObject.activeSelf; }
	}

	public TargetFace TargetFace
	{
		get { return m_targetFace; }
	}
}
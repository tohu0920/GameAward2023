using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCopy: MonoBehaviour
{
	[SerializeReference] GameSceneController m_gameSceneController;
	[SerializeReference] SeController m_seController;
	//[SerializeReference] CoreControllerCopy m_coreController;
	//[SerializeReference] PreviewControllerCopy m_previewController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		////--- Aボタンを押したら
		//if (Input.GetKeyDown(KeyCode.JoystickButton0))
		//{
		//	//--- プレビューが有効でない場合のみ選択可能
		//	if (!m_previewController.Active)
		//	{
		//		// 判定用のレイを用意
		//		Ray ray = CursorController.GetCameraToRay();
		//		RaycastHit hit;

		//		if (Physics.Raycast(ray, out hit))
		//		{
		//			// ガラクタではないならスルー
		//			if (hit.transform.tag != "Junk") return;

		//			// プレビューを有効化
		//			m_previewController.Active = true;
		//			m_previewController.TargetFace.AttachJunk(hit.transform.gameObject);

		//			m_seController.PlaySe("Select");
		//		}
		//	}
		//}

		////--- Bボタンを押したら
		//if (Input.GetKeyDown(KeyCode.JoystickButton1))
		//{
		//	//--- プレビューが有効でない場合のみ切り離し可能
		//	if (!m_previewController.Active)
		//	{
		//		m_coreController.CoreSetting.DetachJunk();
		//	}
		//}

		////--- Xボタンを押したら
		//if(Input.GetKeyDown(KeyCode.JoystickButton2) && !m_gameSceneController.IsStart)
		//{
		//	//--- 各オブジェクトのスタート処理
		//	m_coreController.StartCore();
		//	m_gameSceneController.StartStage();
		//}
	}
}
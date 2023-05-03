using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PadInput
{
	static Dictionary<KeyCode, KeyCode> m_keyCode;
	static Dictionary<string, string> m_axisName;

	/// <summary>
	/// ゲーム起動時に呼び出される
	/// </summary>
	[RuntimeInitializeOnLoadMethod]
	static void Initialize()
	{
		//--- 要素の追加
		m_keyCode = new Dictionary<KeyCode, KeyCode>();
		m_keyCode.Add(KeyCode.JoystickButton0, KeyCode.Space);			// Aボタン
		m_keyCode.Add(KeyCode.JoystickButton1, KeyCode.Backspace);		// Bボタン
		m_keyCode.Add(KeyCode.JoystickButton2, KeyCode.Return);			// Xボタン
		m_keyCode.Add(KeyCode.JoystickButton3, KeyCode.RightShift);		// Yボタン
		m_keyCode.Add(KeyCode.JoystickButton4, KeyCode.Q);				// Lボタン
		m_keyCode.Add(KeyCode.JoystickButton5, KeyCode.E);				// Rボタン
		m_keyCode.Add(KeyCode.JoystickButton6, KeyCode.LeftShift);		// ビューボタン
		m_keyCode.Add(KeyCode.JoystickButton7, KeyCode.LeftControl);	// メニューボタン
		m_keyCode.Add(KeyCode.JoystickButton8, KeyCode.LeftAlt);		// 左スティック押し込み
		m_keyCode.Add(KeyCode.JoystickButton9, KeyCode.RightAlt);		// 右スティック押し込み
		m_keyCode.Add(KeyCode.JoystickButton10, KeyCode.RightAlt);		// 右スティック押し込み

		//--- 要素の追加
		m_axisName = new Dictionary<string, string>();
		m_axisName.Add("Horizontal_R", "Horizontal_Arrow");	// 右スティック[水平方向]
		m_axisName.Add("Vertical_R", "Vertical_Arrow");		// 右スティック[垂直方向]
		m_axisName.Add("Horizontal_L", "Horizontal_AD");	// 左スティック[水平方向]
		m_axisName.Add("Vertical_L", "Vertical_SW");		// 左スティック[垂直方向]
		m_axisName.Add("Horizontal_PadX", "Horizontal_JL"); // 十字キー[水平方向]
		m_axisName.Add("Vertical_PadX", "Vertical_KI");		// 十字キー[垂直方向]
	}

	/// <summary>
	/// プレス入力
	/// </summary>
	public static bool GetKey(KeyCode keyCode)
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD	// デバッグ用処理

		// キーボードからも入力を取得
		if (m_keyCode.ContainsKey(keyCode))
			return Input.GetKey(keyCode) || Input.GetKey(m_keyCode[keyCode]);
		
		return Input.GetKey(keyCode);

#else  // リリース用処理
		return Input.GetKey(keyCode);
#endif
	}

	/// <summary>
	/// トリガー入力
	/// </summary>
	public static bool GetKeyDown(KeyCode keyCode)
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD  // デバッグ用処理

		// キーボードからも入力を取得
		if (m_keyCode.ContainsKey(keyCode))
			return Input.GetKeyDown(keyCode) || Input.GetKeyDown(m_keyCode[keyCode]);

		return Input.GetKeyDown(keyCode);

#else   // リリース用処理
		return Input.GetKeyDown(keyCode);
#endif
	}

	/// <summary>
	/// リリース入力
	/// </summary>
	public static bool GetKeyUp(KeyCode keyCode)
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD  // デバッグ用処理

		// キーボードからも入力を取得
		if (m_keyCode.ContainsKey(keyCode))
			return Input.GetKeyUp(keyCode) || Input.GetKeyUp(m_keyCode[keyCode]);

		return Input.GetKeyUp(keyCode);

#else   // リリース用処理
		return Input.GetKeyUp(keyCode);
#endif
	}

	/// <summary>
	/// スティック(十字キー)入力
	/// ※プレス入力
	/// </summary>
	public static float GetAxis(string axisName)
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD  // デバッグ用処理

		// ゲームパッドからの入力
		float axis = Input.GetAxis(axisName);

		// ゲームパッドの入力を優先
		if (Mathf.Abs(axis) > 0.0f) return axis;

		// キーボードからも入力を取得
		if (m_axisName.ContainsKey(axisName))
			axis = Input.GetAxis(m_axisName[axisName]);

		return axis;

#else   // リリース用処理
		return Input.GetAxis(axisName);
#endif
	}

	/// <summary>
	/// スティック(十字キー)入力(-1 ～ 0 ～ 1)
	/// ※プレス入力
	/// </summary>
	public static int GetAxisRaw(string axisName)
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD  // デバッグ用処理

		// ゲームパッドからの入力
		int axis = (int)Input.GetAxisRaw(axisName);

		// キーボードからも入力を取得
		if (m_axisName.ContainsKey(axisName))
			axis += (int)Input.GetAxisRaw(m_axisName[axisName]);

		// 入力がない場合
		if (Mathf.Abs(axis) <= 0) return 0;

		// 両方から入力があった場合を考慮して計算
		return axis / Mathf.Abs(axis);

#else   // リリース用処理
		return (int)Input.GetAxisRaw(axisName);
#endif
	}

	/// <summary>
	/// スティック(十字キー)入力
	/// ※リピート入力
	/// </summary>
	public static int GetAxisRawRepeat(string axisName)
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD  // デバッグ用処理

		// ゲームパッドからの入力
		int axis = AxisInput.GetAxisRawRepeat(axisName);

		// キーボードからも入力を取得
		if (m_axisName.ContainsKey(axisName))
			axis += AxisInput.GetAxisRawRepeat(m_axisName[axisName]);

		// 入力がない場合
		if (Mathf.Abs(axis) <= 0) return 0;

		// 両方から入力があった場合を考慮して計算
		return axis / Mathf.Abs(axis);

#else   // リリース用処理
		return AxisInput.GetAxisRawRepeat(axisName);
#endif
	}
}
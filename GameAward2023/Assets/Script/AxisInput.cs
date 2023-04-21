using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AxisInput
{
	//static int m_lastRaw = 0;
	static string m_lastAxisName = null;
	static int m_frameCnt = 0;

	/// <summary>
	/// 軸入力のリピート入力を取得
	/// </summary>
	public static int GetAxisRawRepeat(string axisName)
	{
		const int START_PRESS_CNT = 40;     //判定開始フレーム
		const int INTERVAL_PRESS_CNT = 7;	//判定間隔フレーム

		// 軸の入力を取得(-1.0～1.0)
		int axisRaw = (int)PadInput.GetAxisRaw(axisName);

		//--- 押されてない場合
		if (axisRaw == 0)
		{
			//--- 前フレームと同一キー
			if (m_lastAxisName == axisName)
			{
				m_lastAxisName = null;
				m_frameCnt = 0;
			}
			return axisRaw;
		}
		//--- 押されている場合
		else
		{
			//--- 前フレームと異なるキー
			if (m_lastAxisName != axisName)
			{
				m_frameCnt = 1;         // 最初のカウント
				m_lastAxisName = axisName;    // 過去の入力として退避

				return axisRaw;
			}

			m_lastAxisName = axisName;	// 過去の入力として退避
			
			//--- リピート入力中
			if (m_frameCnt > 0)
			{
				m_frameCnt++;   // フレーム数をカウント

				// リピート入力判定
				if (m_frameCnt == START_PRESS_CNT)	return axisRaw;				

				//--- フレームを判定開始前に戻す
				if (m_frameCnt == START_PRESS_CNT + INTERVAL_PRESS_CNT + 1)
					m_frameCnt = START_PRESS_CNT - INTERVAL_PRESS_CNT;
			}

			return 0;
		}
	}
}
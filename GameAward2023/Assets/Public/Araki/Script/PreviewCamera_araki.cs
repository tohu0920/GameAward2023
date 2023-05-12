using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PreviewCamera_araki: MonoBehaviour
{
	VideoPlayer m_videoPlayer;	// 動画操作用
	int m_freamCnt;				// フレームカウント
	bool m_isEndNoise;			// ノイズ終了の瞬間
	bool m_isStopRequest;		// ノイズ停止のリクエスト

    // Start is called before the first frame update
    void Start()
    {
		m_videoPlayer = GetComponent<VideoPlayer>();
		m_freamCnt = 0;
		m_isEndNoise = false;
		m_isStopRequest = false;
	}

    // Update is called once per frame
    void Update()
    {
		m_isEndNoise = false;
		if(!m_videoPlayer.isPlaying) return;
		if (!m_isStopRequest) return;

		m_freamCnt++;	// フレームをカウント

		//--- 1秒でノイズを終了
		if (m_freamCnt > 30)
		{
			m_freamCnt = 0;                 // カウントをリセット
			m_videoPlayer.Stop();			// ノイズ動画を停止
			m_isEndNoise = true;            // ノイズ終了フラグを立てる
			m_isStopRequest = false;
		}
    }

	/// <summary>
	/// ノイズを停止(30フレーム後)
	/// </summary>
	public void StopNoise()
	{
		m_freamCnt = 0;	// カウントをリセット
		m_isStopRequest = true;
	}

	/// <summary>
	/// ノイズを再開
	/// </summary>
	public void StartNoise()
	{
		m_videoPlayer.Play();	// ノイズを再生

		// ノイズ停止リクエストを削除
		m_isStopRequest = false;
		m_freamCnt = 0;
	}

	public bool isEndNoise
	{
		get { return m_isEndNoise; }
	}
}

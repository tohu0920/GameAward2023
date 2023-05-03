using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PreviewCamera_araki: MonoBehaviour
{
	VideoPlayer m_videoPlayer;
	int m_freamCnt;
	bool m_isEndNoise;

    // Start is called before the first frame update
    void Start()
    {
		m_videoPlayer = GetComponent<VideoPlayer>();
		m_freamCnt = 0;
		m_isEndNoise = false;
		gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		m_isEndNoise = false;
		if(!m_videoPlayer.isPlaying) return;

		m_freamCnt++;	// フレームをカウント

		//--- 1秒でノイズを終了
		if (m_freamCnt > 60)
		{
			m_freamCnt = 0;                 // カウントをリセット
			m_videoPlayer.Stop();			// ノイズ動画を停止
			m_isEndNoise = true;            // ノイズ終了フラグを立てる
		}
    }

	/// <summary>
	/// ノイズを再生
	/// </summary>
	public void StartNoise()
	{
		gameObject.SetActive(true);		// 自信を有効化
		m_videoPlayer.Play();			// ノイズ動画を再生

		m_freamCnt = 0;	// カウントをリセット
	}

	/// <summary>
	/// プレビュー用カメラの無効化
	/// </summary>
	public void EndPreview()
	{
		gameObject.SetActive(false);	// 自信を無効化
	}

	public bool isEndNoise
	{
		get { return m_isEndNoise; }
	}
}

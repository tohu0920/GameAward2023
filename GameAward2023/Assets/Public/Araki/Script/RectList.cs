using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectList : MonoBehaviour
{
	[SerializeReference] List<GameObject> m_rectList;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	/// <summary>
	/// 画像の切り替え
	/// </summary>
	/// <param name="index">区画番号</param>
	/// <param name="image">画像データ</param>
	public void ChangeImage(int index, Sprite image)
	{
		if (index >= m_rectList.Count) return;
		Image currentImage = m_rectList[index].GetComponent<Image>();
		if (currentImage == null) return;
		currentImage.sprite = image;
	}

	/// <summary>
	/// 画像のスケール変更
	/// </summary>
	/// <param name="index">区画番号</param>
	/// <param name="scale">スケール</param>
	public void SetSizeImage(int index, float scale)
	{
		if (index >= m_rectList.Count) return;
		RectTransform rect = m_rectList[index].GetComponent<RectTransform>();
		if (rect == null) return;
		rect.localScale = new Vector3(scale, scale, scale);
	}
}
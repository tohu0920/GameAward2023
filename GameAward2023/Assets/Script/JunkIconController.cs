using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JunkIconController : MonoBehaviour
{
	RectTransform[] m_rectTranform;
	int m_selectNum;
	bool m_isChange;

    // Start is called before the first frame update
    void Start()
    {
		m_rectTranform = new RectTransform[this.transform.childCount];

		//--- 子の画像情報を取得
		for (int i = 0; i < this.transform.childCount; i++)
			m_rectTranform[i] = this.transform.GetChild(i).GetComponent<RectTransform>();

		//--- 最初のアイテムを選択
		m_selectNum = 0;
		m_rectTranform[m_selectNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);

		m_isChange = true;	// 変更フラグを取得
	}

    // Update is called once per frame
    void Update()
	{
		int lastSelectNum = m_selectNum;

		if (Input.GetKeyDown(KeyCode.JoystickButton5))
			m_selectNum++;

		if (Input.GetKeyDown(KeyCode.JoystickButton4))
			m_selectNum--;

		m_selectNum += m_rectTranform.Length;
		m_selectNum %= m_rectTranform.Length;

		Debug.Log("選択：" + m_selectNum);

		m_isChange = (m_selectNum != lastSelectNum);

		if (m_isChange)
		{
			m_rectTranform[lastSelectNum].localScale = new Vector3(0.75f, 0.75f, 0.75f);
			m_rectTranform[m_selectNum].localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
    }

	public bool isChange
	{
		get { return m_isChange; }
	}
}
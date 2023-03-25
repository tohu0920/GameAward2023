using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
	RectTransform m_rectTransform;
	Vector2 m_pos;

    // Start is called before the first frame update
    void Start()
    {
		m_rectTransform = this.GetComponent<RectTransform>();

		m_pos = new Vector2(200.0f, 0.0f);

		m_rectTransform.anchoredPosition = m_pos;
	}

    // Update is called once per frame
    void Update()
    {
		m_pos.x += Input.GetAxisRaw("Horizontal_L") * 7.5f;
		m_pos.y += Input.GetAxisRaw("Vertical_L") * 7.5f;

		m_rectTransform.anchoredPosition = m_pos;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewJunk_araki : MonoBehaviour
{
	float m_rotY;

    // Start is called before the first frame update
    void Start()
    {
		m_rotY = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
		transform.eulerAngles = new Vector3(0.0f, m_rotY, 0.0f);
		m_rotY += 1.0f;
	}
}
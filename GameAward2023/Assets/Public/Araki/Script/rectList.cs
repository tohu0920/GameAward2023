using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectList : MonoBehaviour
{
	List<RectTransform> m_rectList;

    // Start is called before the first frame update
    void Start()
    {
		m_rectList = new List<RectTransform>();

		//--- Žq‚ÌRectTransform‚ðƒŠƒXƒg‰»
		int childCnt = transform.childCount;
		for(int i =0; i < childCnt; i++)
		{
			RectTransform rectTransform = transform.GetChild(i).GetComponent<RectTransform>();

			if (rectTransform == null) continue;
			m_rectList.Add(rectTransform);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	List<RectTransform> rectList
	{
		get { return m_rectList; }
	}
}
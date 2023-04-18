using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankController : MonoBehaviour
{
    [SerializeField] GameObject selectJank;

    // Start is called before the first frame update
    void Start()
    {
        selectJank = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SelectJank
    {
        get { return selectJank; }
        set { selectJank = value; }
    }

    public void PreviewRot(float radius)
    {
        GameObject obj = selectJank;

        obj.transform.Rotate(0.0f, radius, 0.0f);

        IsAttachFace_iwata hoge;
        if (hoge = obj.GetComponent<IsAttachFace_iwata>())
        {
            //つけても大丈夫な向き
            List<Vector3> attachVector = hoge.GetRotVector();

            for (int i = 0; i < attachVector.Count; i++)
            {
                if (Vector3.Distance(attachVector[i], Vector3.forward) < 0.5f)  
                {//奥に進むベクトルと同じ向き
                    selectJank.transform.rotation = obj.transform.rotation;
                    return;
                }
                
            }


        }
        
    }

    public void ReturnJank()
    {
        selectJank.GetComponent<SpownJank_iwata>().ReturnJank();
    }
}

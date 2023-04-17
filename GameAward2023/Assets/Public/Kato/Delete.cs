using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//プレハブに入れないとオブジェクトごと消えるので注意
public class Delete : MonoBehaviour
{
    public float duration = 2.0f; // エフェクトの再生時間
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, duration);
    }
}

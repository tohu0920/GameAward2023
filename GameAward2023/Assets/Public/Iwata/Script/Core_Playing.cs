using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_Playing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in this.transform)
        {
            child.GetComponent<JankStatus>().UndoSize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

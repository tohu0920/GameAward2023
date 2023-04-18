using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController_iwata : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Active
    {
        set { this.gameObject.SetActive(value); }
        get { return this.gameObject.activeSelf; }
    }
}

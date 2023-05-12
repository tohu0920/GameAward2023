using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGroung : MonoBehaviour
{
    [SerializeField] GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.parent.name == "Core(Clone)")
        {
            collision.transform.parent.GetComponent<Core_Playing>().DestroyCore();
        }
    }
}

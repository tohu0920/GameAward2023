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

    public void ReturnJank()
    {
        selectJank.GetComponent<SpownJank_iwata>().ReturnJank();
    }
}

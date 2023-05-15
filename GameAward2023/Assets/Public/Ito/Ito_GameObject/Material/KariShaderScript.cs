using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KariShaderScript : MonoBehaviour
{
    public bool colorFlagValue;
    public bool craftFlagValue;

    private Renderer Cube;

    // Start is called before the first frame update
    void Start()
    {
        Cube = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Cube.material.SetInt("_ColorFlag",  colorFlagValue ? 0 : 1);
            colorFlagValue = !colorFlagValue;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cube.material.SetInt("_CraftFlag",  craftFlagValue ? 0 : 1);
            craftFlagValue = !craftFlagValue;
        }

    }
}

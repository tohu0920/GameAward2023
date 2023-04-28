using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		Vector3 pos = this.transform.position;

		pos.x += PadInput.GetAxis("Horizontal_R");
		pos.y += PadInput.GetAxis("Vertical_R");

		this.transform.position = pos;

		if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
			LoadStageData.CreateStage("testData");
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YNChoice : MonoBehaviour
{
    public GameObject LoadNextScene; 

    static public int choiceNum;

    // Start is called before the first frame update
    public void Start()
    {        
        choiceNum = 0;
    }

    // Update is called once per frame
    static public void Update()
    {
        choiceNum += AxisInput.GetAxisRawRepeat("Horizontal_PadX");

        choiceNum += 2;
        choiceNum %= 2;

        if(choiceNum == 1 && PadInput.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //SceneManager.LoadScene(LoadNextScene.name);
        }

        if(choiceNum == 0 && PadInput.GetKeyDown(KeyCode.Joystick1Button0) || PadInput.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Pose.activetoStage = false;
            Pose.activetoTitle = false;

        }
    }
}

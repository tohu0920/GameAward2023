using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YNChoice : MonoBehaviour
{    
    [SerializeReference] public GameObject toStageCanvas;
    [SerializeReference] public GameObject toTitleCanvas;
    [SerializeReference] public string LoadNextScene;

    private int oldChoiceNum;
    public int choiceNum;

    private RectList toStageRect;
    private RectList toTitleRect;

    // Start is called before the first frame update
    public void Start()
    {
        toStageRect = toStageCanvas.GetComponent<RectList>();
        toTitleRect = toTitleCanvas.GetComponent<RectList>();

        toStageRect.SetSizeImage(0, 1.2f);
        toTitleRect.SetSizeImage(0, 1.2f);

        choiceNum = 0;
        oldChoiceNum = 99;
    }

    // Update is called once per frame
    public void Update()
    {
        oldChoiceNum = choiceNum;
        choiceNum += AxisInput.GetAxisRawRepeat("Horizontal_PadX");

        choiceNum += 2;
        choiceNum %= 2;

        if(choiceNum == 1 && PadInput.GetKeyDown(KeyCode.Joystick1Button0))
        {
            SceneManager.LoadScene(LoadNextScene);
        }

        if(choiceNum == 0 && PadInput.GetKeyDown(KeyCode.Joystick1Button0) || PadInput.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Pose.activetoStage = false;
            Pose.activetoTitle = false;
        }

        if (oldChoiceNum == choiceNum) return;
        toStageRect.SetSizeImage(choiceNum, 1.2f);   
        toStageRect.SetSizeImage(oldChoiceNum, 1.0f);
        toTitleRect.SetSizeImage(choiceNum, 1.2f);
        toTitleRect.SetSizeImage(oldChoiceNum, 1.0f);
    }
}

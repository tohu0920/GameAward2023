using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelect_Ito : MonoBehaviour
{
    public enum WorldNum
    {
        World1,     //‘æ‚RŠK‘w
        World2,     //‘æ‚QŠK‘w
        World3,     //‘æ‚PŠK‘w
    }

    [SerializeReference] GameObject World1;
    [SerializeReference] GameObject World2;
    [SerializeReference] GameObject World3;
    [SerializeReference] GameObject W1Stage;
    [SerializeReference] GameObject W2Stage;
    [SerializeReference] GameObject W3Stage;
    [SerializeReference] GameObject WorldCtrlObj;
    [SerializeReference] GameObject StageCtrlObj;


    public int SelectNum;
    static WorldNum worldNum;


    // Start is called before the first frame update
    void Start()
    {
        SelectNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SelectNum += AxisInput.GetAxisRawRepeat("Vertical_PadX");

        if (SelectNum == -1)
        {
            SelectNum = 0;
        }
        if (SelectNum == 3)
        {
            SelectNum = 2;
        }

        WorldChange();

        if(PadInput.GetKeyDown(KeyCode.Joystick1Button0))
        { 
            switch (SelectNum)
            {
                case 0:                       
                    W1Stage.SetActive(true);
                    World1.SetActive(false);
                    WorldCtrlObj.SetActive(false);
                    worldNum = WorldNum.World1;
                    break;

                case 1:
                    W2Stage.SetActive(true);
                    World2.SetActive(false);
                    WorldCtrlObj.SetActive(false);
                    worldNum = WorldNum.World2;
                    break;

                case 2:
                    W3Stage.SetActive(true);
                    World3.SetActive(false);
                    WorldCtrlObj.SetActive(false);
                    worldNum = WorldNum.World3;
                    break;            
            }
        }
    }

    private void WorldChange()
    {
        switch (SelectNum)
        {
            case 0:
                World1.SetActive(true);
                World2.SetActive(false);
                World3.SetActive(false);
                break;

            case 1:
                World1.SetActive(false);
                World2.SetActive(true);
                World3.SetActive(false);
                break;

            case 2:
                World1.SetActive(false);
                World2.SetActive(false);
                World3.SetActive(true);                
                break;
        }
    }

    public static WorldNum GetWorld()
    {
        return worldNum;
    }
}

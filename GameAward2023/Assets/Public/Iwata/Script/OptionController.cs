using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public enum OptionSelect
    {
        E_OPTION_SELECT_BGM = 0,
        E_OPTION_SELECT_SE,
        E_OPTION_SELECT_TUTO,
        E_OPTION_SELECT_EXIT,
        E_OPTION_SELECT_MAX
    }

    [System.Serializable]
    public struct NameTag
    {
        public Image image;
        public Text text;
    }

    [SerializeField] private NameTag[] nametag = new NameTag[(int)OptionSelect.E_OPTION_SELECT_MAX];

    [SerializeField] private Slider[] slider = new Slider[2];

    [SerializeField] private OptionSelect select;

    [SerializeField] private AudioManager AudioManager;

    [SerializeField] private GameObject titleObj;

    [SerializeField] private static int Split = 5;
    private float SliderValue = 1.0f / Split;

    // Start is called before the first frame update
    void OnEnable()
    {
        select = OptionSelect.E_OPTION_SELECT_BGM;

        nametag[(int)select].image.color = new Color(0, 0, 0, 255);
        nametag[(int)select].text.color = new Color(255, 255, 255, 255);

        //for(int i = 0; i < slider.Length; i++)
        //{
        //    slider[i].value = 1.0f;
        //}
        
        slider[(int)OptionSelect.E_OPTION_SELECT_BGM].value = AudioManager.BGMvolume;
        slider[(int)OptionSelect.E_OPTION_SELECT_SE].value = AudioManager.SEvolume;
    }

    // Update is called once per frame
    void Update()
    {
        bool update = false;
        OptionSelect stack = select;

        int axisY = AxisInput.GetAxisRawRepeat("Vertical_PadX");
        if (axisY < 0)
        {
            update = true;
            if (select == OptionSelect.E_OPTION_SELECT_TUTO || select == OptionSelect.E_OPTION_SELECT_EXIT)
            {
                select = OptionSelect.E_OPTION_SELECT_BGM;
            }
            else
            {
                select++;
            }
        }
        else if (axisY > 0)
        {
            update = true;
            if (select == OptionSelect.E_OPTION_SELECT_TUTO || select == OptionSelect.E_OPTION_SELECT_EXIT)
            {
                select = OptionSelect.E_OPTION_SELECT_SE;
            }
            else if(select == OptionSelect.E_OPTION_SELECT_BGM)
            {
                select = OptionSelect.E_OPTION_SELECT_TUTO;
            }
            else
            {
                select--;
            }
        }

        int axisX = AxisInput.GetAxisRawRepeat("Horizontal_PadX");

        if(axisX != 0)
        {
            switch(select)
            {
                case OptionSelect.E_OPTION_SELECT_BGM:
                    if (axisX < 0)
                    {
                        slider[(int)select].value -= SliderValue;
                    }
                    else if (axisX > 0)
                    {
                        slider[(int)select].value += SliderValue;
                    }
                    AudioManager.BGMvolume = slider[(int)select].value;
                    break;
                case OptionSelect.E_OPTION_SELECT_SE:
                    if (axisX < 0)
                    {
                        slider[(int)select].value -= SliderValue;
                    }
                    else if (axisX > 0)
                    {
                        slider[(int)select].value += SliderValue;
                    }
                    AudioManager.SEvolume = slider[(int)select].value;
                    break;
                case OptionSelect.E_OPTION_SELECT_TUTO:
                    select = OptionSelect.E_OPTION_SELECT_EXIT;
                    update = true;
                    break;
                case OptionSelect.E_OPTION_SELECT_EXIT:
                    select = OptionSelect.E_OPTION_SELECT_TUTO;
                    update = true;
                    break;
            }
        }

        if(update)
        {
            nametag[(int)stack].image.color = new Color(255, 255, 255, 255);
            nametag[(int)stack].text.color = new Color(0, 0, 0, 255);

            nametag[(int)select].image.color = new Color(0, 0, 0, 255);
            nametag[(int)select].text.color = new Color(255, 255, 255, 255);
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            switch(select)
            {
                case OptionSelect.E_OPTION_SELECT_TUTO:
                    Debug.Log("ëÄçÏê‡ñæ");
                    break;
                case OptionSelect.E_OPTION_SELECT_EXIT:
                    nametag[(int)select].image.color = new Color(255, 255, 255, 255);
                    nametag[(int)select].text.color = new Color(0, 0, 0, 255);
                    titleObj.SetActive(true);
                    this.gameObject.SetActive(false);
                    break;
            }
        }
    }
}

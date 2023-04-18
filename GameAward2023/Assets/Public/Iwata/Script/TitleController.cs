using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SelectCursor_Title
{
    E_SELECT_CURSOR_TITLE_NULL = 0,
    E_SELECT_CURSOR_TITLE_PLAY,
    E_SELECT_CURSOR_TITLE_OPTION,
    E_SELECT_CURSOR_TITLE_END,

    E_SELECT_CURSOR_TITLE_MAX
}

public class TitleController : MonoBehaviour
{
    private Text start;
    private Text option;
    private Text end;

    [SerializeField] SelectCursor_Title select;
    [SerializeField] GameObject optionObj;

    [SerializeField] AudioManager AM;

    
    // Start is called before the first frame update
    void Start()
    {
        start = this.transform.Find("Start").gameObject.GetComponent<Text>();
        option = this.transform.Find("Option").gameObject.GetComponent<Text>();
        end = this.transform.Find("End").gameObject.GetComponent<Text>();
        select = SelectCursor_Title.E_SELECT_CURSOR_TITLE_PLAY;
        start.color = new Color(255, 0, 0, 255);
        option.color = new Color(255, 255, 255, 255);
        end.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        float axisY = (float)AxisInput.GetAxisRawRepeat("Vertical");
        bool update = false;

        if(axisY < 0)
        {
            select++;
            update = true;
            if (select == SelectCursor_Title.E_SELECT_CURSOR_TITLE_MAX)
            {
                select = SelectCursor_Title.E_SELECT_CURSOR_TITLE_PLAY;
            }
            AM.PlaySE(AudioManager.SEKind.E_SE_KIND_SELECT);
        }
        else if(axisY > 0)
        {
            select--;
            update = true;
            if (select == SelectCursor_Title.E_SELECT_CURSOR_TITLE_NULL)
            {
                select = SelectCursor_Title.E_SELECT_CURSOR_TITLE_END;
            }
            AM.PlaySE(AudioManager.SEKind.E_SE_KIND_SELECT);
        }

        if(update)
        {
            update = false;
            switch(select)
            {
                case SelectCursor_Title.E_SELECT_CURSOR_TITLE_PLAY:
                    start.color = new Color(255, 0, 0, 255);
                    option.color = new Color(255, 255, 255, 255);
                    end.color = new Color(255, 255, 255, 255);
                    break;
                case SelectCursor_Title.E_SELECT_CURSOR_TITLE_OPTION:
                    start.color = new Color(255, 255, 255, 255);
                    option.color = new Color(255, 0, 0, 255);
                    end.color = new Color(255, 255, 255, 255);
                    break;
                case SelectCursor_Title.E_SELECT_CURSOR_TITLE_END:
                    start.color = new Color(255, 255, 255, 255);
                    option.color = new Color(255, 255, 255, 255);
                    end.color = new Color(255, 0, 0, 255);
                    break;
                default:
                    Debug.Log("selectÉGÉâÅ[");
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            switch (select)
            {
                case SelectCursor_Title.E_SELECT_CURSOR_TITLE_PLAY:
                    SceneManager.LoadScene("StageSelectScene");
                    break;
                case SelectCursor_Title.E_SELECT_CURSOR_TITLE_OPTION:
                    optionObj.SetActive(true);
                    this.gameObject.SetActive(false);
                    break;
                case SelectCursor_Title.E_SELECT_CURSOR_TITLE_END:
                    Debug.Log("Ç®ÇÌÇË");
                    Application.Quit();
                    break;
                default:
                    
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenChange : MonoBehaviour
{
    [SerializeReference] Object nextScene;

    public void ChangeScene()
    {
        Debug.Log(nextScene.name);
        SceneManager.LoadScene(nextScene.name);
    }
}

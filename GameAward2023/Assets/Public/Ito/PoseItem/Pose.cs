using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose : MonoBehaviour
{
    [SerializeReference] GameObject poseScreen;

    public void PauseGame()
    {
        Time.timeScale = 0;
        poseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        poseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActiveCanvas()
    {
        poseScreen.SetActive(true);
    }

    public void NonActiveCanvas()
    {
        poseScreen.SetActive(false);
    }
}

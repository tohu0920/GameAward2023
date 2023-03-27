using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBGM : MonoBehaviour
{
    public AudioClip Title;
    public AudioClip Stage1;
    public AudioClip CraftScene;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Title;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            audioSource.Stop();
            audioSource.clip = Title;
            audioSource.Play();
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            audioSource.Stop();
            audioSource.clip = Stage1;
            audioSource.Play();
        }


        if (Input.GetKeyDown(KeyCode.F3))
        {
            audioSource.Stop();
            audioSource.clip = CraftScene;
            audioSource.Play();
        }
    }
}

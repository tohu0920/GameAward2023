using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnLoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeReference] Object UnScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.UnloadSceneAsync(UnScene.name);
    }
}

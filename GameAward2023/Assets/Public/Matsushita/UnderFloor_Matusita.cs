using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderFloor_Matusita : MonoBehaviour
{
    public Explosion explosionReference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.root.name != "Core") return;

        explosionReference.Blast();

        SceneManager.LoadScene("GameScene");
	}
}

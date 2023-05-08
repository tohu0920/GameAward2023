using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
        Debug.Log("Ç‘Ç¬Ç©Ç¡ÇΩ" + collision.transform.name);

		if (collision.transform.name.Contains("Core_Child"))
        {
            if (!collision.transform.parent.GetComponent<Core_Playing>().Life) return;

            Debug.Log("ÉSÅ[ÉãÇµÇΩ");
            SceneManager.LoadScene("GameScene_v2.0");
        }

	}
}
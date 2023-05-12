using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager GM;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.name.Contains("Core_Child"))
        {
            if (!collision.transform.parent.GetComponent<Core_Playing>().Life) return;

            Debug.Log("ƒS[ƒ‹‚µ‚½");
            GM.GameStatus = GameManager.eGameStatus.E_GAME_STATUS_END;
        }
    }
}
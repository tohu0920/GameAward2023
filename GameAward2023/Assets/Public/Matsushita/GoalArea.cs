using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Transform parent = other.transform.parent;
            for(int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).tag == "Player") continue;
                FixedJoint[] joint = parent.GetChild(i).GetComponents<FixedJoint>();
                foreach(FixedJoint child in joint)
                {
                    Destroy(child);
                }
                float explosionForce = 20.0f; // ”š”­—Í
                float explosionRadius = 5.0f; // ”š”­”¼Œa
                parent.GetChild(i).transform.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, parent.GetChild(i).transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
            }
            GameManager.GameStatus = GameManager.eGameStatus.E_GAME_STATUS_END;
        }
    }
}
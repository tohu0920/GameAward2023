using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string sceneName = "GameOver";  // 移動先のシーン名

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 衝突したオブジェクトがプレイヤーの場合
        {
            SceneManager.LoadScene(sceneName); // 指定したシーンに移動する
        }
    }
}


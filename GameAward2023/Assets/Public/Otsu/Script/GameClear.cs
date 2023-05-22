using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastSceneSwitch : MonoBehaviour
{
    public Camera camera; // レイを飛ばすカメラ
    public float maxDistance = 100f; // レイが届く最大距離

    void Update()
    {
        // マウスの左クリックでレイを飛ばす
        if (Input.GetMouseButtonDown(0))
        {
            // スクリーン座標をワールド座標に変換する
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            // レイが衝突したオブジェクトを取得する
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                // 衝突したオブジェクトが目的のオブジェクトだった場合、シーンを切り替える
                if (hit.collider.CompareTag("Goal"))
                {
                    SceneManager.LoadScene("ClearScene");
                }
            }
        }
    }
}

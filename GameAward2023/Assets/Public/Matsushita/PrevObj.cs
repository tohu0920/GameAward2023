using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevObj : MonoBehaviour
{
    private GameObject clonedObject;
    private GameObject originalObject;
    private Quaternion rotation;

    [SerializeField] GameObject target;
    private CameraSwitch cameraSwitchScript;
    private bool onCamera;

    void Start()
    {
        cameraSwitchScript = GetComponent<CameraSwitch>();
        target = GameObject.Find("core");
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked on " + hit.collider.gameObject.name);

                // 複製元のオブジェクトを記憶
                GameObject originalObject = hit.collider.gameObject;

                // もし以前に複製したオブジェクトがあれば、異なる場合は削除する
                if (clonedObject != null)
                {
                    Destroy(clonedObject);
                    clonedObject = null;
                }

                // 複製先の座標を計算
                Vector3 newPosition = target.transform.position;
                newPosition.z -= 3.0f;

                // オブジェクトを複製
                clonedObject = Instantiate(originalObject, newPosition, originalObject.transform.rotation);

                // 複製したオブジェクトに名前を付ける
                clonedObject.name = originalObject.name + "_clone";
            }
        }

        // 複製されたオブジェクトが存在する場合に回転を適用する
        if (clonedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Eキーが押された場合
            {
                // 回転を適用
                clonedObject.transform.RotateAround(clonedObject.transform.position, Vector3.up, 90f);

            }
            else if (Input.GetKeyDown(KeyCode.Q)) // Qキーが押された場合
            {
                // 回転を適用
                clonedObject.transform.RotateAround(clonedObject.transform.position, Vector3.up, -90f);

            }
        }
    }
}

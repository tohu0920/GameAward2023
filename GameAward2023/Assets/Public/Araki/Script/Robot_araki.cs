using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_araki : MonoBehaviour
{
    Vector3 forwardDirect;
    float rayCastDistance = 1.0f;
	[SerializeReference] float moveSpeed = 0.05f;

    private void Start()
    {
		// 何がぶつかってきても動じないようにする
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        forwardDirect = transform.forward * moveSpeed;	// 最初は前に進むように設定
    }

    private void Update()
    {
		//--- パネルを踏んだ時の処理
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, rayCastDistance))
        {
            Panel_araki panel = hit.collider.GetComponent<Panel_araki>();
			if (panel == null) return;

            // パネルによって進行方向を更新
            forwardDirect = panel.GetForwardDirect() * moveSpeed;
        }
    }

	private void FixedUpdate()
	{
		// 移動処理(等速直線運動)
		transform.position += forwardDirect;
	}
}
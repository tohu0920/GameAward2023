using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeReference] float m_crashRate = 80.0f;

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
        if (collision.transform.tag == "Wall")
        {
            Debug.Log("当たった！");
            // ベクトルを計算
            Vector3 vForce = (collision.contacts[0].point - this.transform.position).normalized;

            // ベクトルを適用
            collision.gameObject.GetComponent<Rigidbody>().AddForce(vForce * m_crashRate, ForceMode.Impulse);

 //           FixedJoint jointP = collision.gameObject.GetComponent<FixedJoint>();
 //           FixedJoint jointC = collision.gameObject.GetComponentInChildren<FixedJoint>();
 //           if (jointP != null)
 //               jointP.breakForce *= 0.1f;
 //           if (jointC != null)
 //               jointC.breakForce *= 0.1f;
        }
    }
}

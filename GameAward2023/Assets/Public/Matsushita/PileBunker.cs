using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PileBunker : JankBase_iwata
{
    public float speed = 5f;
    public float interval = 1f;
    public float distance = 1f;
    public float m_crashRate = 200.0f;

    private float currentDistance = 0f;
    private bool isMove = true;

    private Transform needleTransform;

    public override void work()
    {

    }

    public override List<float> GetParam()
    {
        List<float> list = new List<float>();

        return list;
    }

    public override void SetParam(List<float> paramList)
    {

    }

    void Start()
    {
        needleTransform = transform.GetChild(0);
        StartCoroutine(MoveNeedle());
    }


    IEnumerator MoveNeedle()
    {
        while (true)
        {
            if (currentDistance >= distance || currentDistance <= 0f)
            {
                isMove = !isMove;
                yield return new WaitForSeconds(interval);
            }

            if (isMove)
            {
                currentDistance += speed * Time.deltaTime;
                needleTransform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                currentDistance -= speed * Time.deltaTime;
                needleTransform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            // FixedJointを削除
            FixedJoint joint = collision.gameObject.GetComponent<FixedJoint>();
            if (joint != null)
                Destroy(joint);

            // ベクトルを計算
            Vector3 vForce = (collision.contacts[0].point - this.transform.position).normalized;

            // ベクトルを適用
            if (collision.gameObject.GetComponent<Rigidbody>() != null)
                collision.gameObject.GetComponent<Rigidbody>().AddForce(vForce * m_crashRate, ForceMode.Impulse);
        }
    }

}

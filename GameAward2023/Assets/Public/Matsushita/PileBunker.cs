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
    Rigidbody rb;

    public override void work()
    {
        if (currentDistance >= distance || currentDistance <= 0f)
        {
            isMove = !isMove;
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
        rb = transform.GetChild(1).GetComponent<Rigidbody>();
        needleTransform = transform.GetChild(0);
        //StartCoroutine(MoveNeedle());
    }


    //IEnumerator MoveNeedle()
    //{
    //    while (true)
    //    {
    //        if (currentDistance >= distance || currentDistance <= 0f)
    //        {
    //            isMove = !isMove;
    //            yield return new WaitForSeconds(interval);
    //        }

    //        if (isMove)
    //        {
    //            currentDistance += speed * Time.deltaTime;
    //            needleTransform.Translate(Vector3.right * speed * Time.deltaTime);
    //        }
    //        else
    //        {
    //            currentDistance -= speed * Time.deltaTime;
    //            needleTransform.Translate(Vector3.left * speed * Time.deltaTime);
    //        }

    //        yield return null;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("Cage"))
        {
            Debug.Log("‘¬“x:" + rb.velocity);
            Vector3 force = rb.velocity * 150f; // “K‹X’²®
            Debug.Log("force:" + force);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }

}

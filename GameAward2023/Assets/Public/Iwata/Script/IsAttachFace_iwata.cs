using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttachFace_iwata : MonoBehaviour
{
    [SerializeReference] bool m_forward;
    [SerializeReference] bool m_back;
    [SerializeReference] bool m_right;
    [SerializeReference] bool m_left;
    [SerializeReference] bool m_up;
    [SerializeReference] bool m_down;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RotateJunk()
    {
        //if (Input.GetKeyDown(KeyCode.JoystickButton5)) // RB
        //{
        //    // 回転を適用
        //    this.transform.RotateAround(this.transform.position, Vector3.up, -90f);

        //    while (!CanAttach(Vector3.forward))
        //        this.transform.RotateAround(this.transform.position, Vector3.up, -90f);
        //}
        //if (Input.GetKeyDown(KeyCode.JoystickButton4)) // LB
        //{
        //    // 回転を適用
        //    this.transform.RotateAround(this.transform.position, Vector3.up, 90f);

        //    while (!CanAttach(Vector3.forward))
        //        this.transform.RotateAround(this.transform.position, Vector3.up, 90f);
        //}
    }

    /// <summary>
    /// 組み立てられる面かを判定
    /// </summary>
    public bool CanAttach(Vector3 toFace)
    {
        //--- 組み立てられる面を全て洗い出す
        List<Vector3> attachVector = GetAttachVector();

        //--- 組み立てられる面かを判定する
        for (int i = 0; i < attachVector.Count; i++)
        {
            if (Vector3.Distance(attachVector[i], toFace) > 0.5f) continue;

            return true;
        }

        return false;
    }

    /// <summary>
    /// 組み立てられる面を取得
    /// </summary>
    /// <returns></returns>
    public List<Vector3> GetAttachVector()
    {
        //--- 組み立てられる面を全て洗い出す
        List<Vector3> attachVector = new List<Vector3>();
        if (m_forward) attachVector.Add(this.transform.forward);
        if (m_back) attachVector.Add(-this.transform.forward);
        if (m_right) attachVector.Add(this.transform.right);
        if (m_left) attachVector.Add(-this.transform.right);
        if (m_up) attachVector.Add(this.transform.up);
        if (m_down) attachVector.Add(-this.transform.up);

        return attachVector;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    const float ROT_Y = 90.0f;  // ��]�p�x
    const float ROT_X = 90.0f;  // ��]�p�x

    //[SerializeReference] GameController m_gameController;   // �Q�[���̏�ԂɊւ�������擾
    [SerializeReference] float m_dampingRate;   // ������
    int m_timeToRotate;     // ��]�ɕK�v�ȃt���[����
    int m_rotFrameCnt;      // ��]���̃t���[���J�E���g
    float m_rotx,m_rotY, m_lateXZ; // ��]�p�����[�^
    Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rotFrameCnt = -1;
        m_rotY = m_lateXZ = 0.0f;
        m_timeToRotate = (int)(Mathf.Log(0.01f) / Mathf.Log(1.0f - m_dampingRate));
        m_rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_gameController.IsStart) return;

        // �x������
        m_lateXZ = (m_rotY - m_lateXZ) * m_dampingRate + m_lateXZ;

        // ���W�v�Z
        transform.eulerAngles = new Vector3(0.0f, m_lateXZ, 0.0f);

        if (m_rotFrameCnt < 0) return;

        m_rotFrameCnt++;    // ��]���̃t���[���J�E���g
    }

    /// <summary>
    /// �R�A�̉�]�J�n
    /// </summary>
    public void RotateCoreY(int direction)
    {

        m_rotY += ROT_Y * direction;

        m_rotFrameCnt = 0;
    }

    public void RotateCoreX(int direction)
    {

        //m_rotX += ROT_X * direction;

        m_rotFrameCnt = 0;
    }

    /// <summary>
    /// ���i���A�^�b�`�o����ʂ��擾
    /// </summary>
    public List<Transform> GetAttachFace()
    {
        List<Transform> attachFace = new List<Transform>();

        // �q�I�u�W�F�N�g�����Ԃɔz��Ɋi�[
        foreach (Transform child in this.transform)
        {
            Ray ray = new Ray(child.position, Vector3.back);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit, 10.0f))
                attachFace.Add(child);
        }

        //--- �\�[�g
        attachFace.Sort((a, b) => {
            if (a.position.y != b.position.y)
            {
                // Y ���W���قȂ�ꍇ�� Y ���W�Ŕ�r����
                return b.position.y.CompareTo(a.position.y);
            }
            else
            {
                // Y ���W�������ꍇ�� X ���W�Ŕ�r����
                return a.position.x.CompareTo(b.position.x);
            }
        });

        return attachFace;
    }

    /// <summary>
    /// ��]�I���t���O
    /// </summary>
    public bool IsRotEnd()
    {
        if (m_rotFrameCnt > m_timeToRotate)
        {
            m_rotFrameCnt = -1; // �J�E���g�̃��Z�b�g
            return true;
        }

        return false;
    }

    /// <summary>
    /// ���i���A�^�b�`����
    /// </summary>
    public void AttachParts(Transform face, GameObject prefabParts)
    {
        Vector3 pos = face.position + (Vector3.forward.normalized * -1.0f);
        GameObject parts = Instantiate(prefabParts, pos, Quaternion.identity);

        parts.transform.SetParent(this.transform);
    }

    /// <summary>
    /// ���W�E��]��Freeze������
    /// </summary>
    public void UnlockFreeze()
    {
        // �X�^�[�g�n�_�ֈړ�
        this.transform.position = new Vector3(-10.0f, 2.5f, -10.0f);
        this.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        m_rigidbody.constraints = RigidbodyConstraints.None;    // �������Z���X�^�[�g

       // m_gameController.IsStart = true;
    }

    //public bool IsStart
    //{
    //    get { return m_gameController.IsStart; }
    //}
}
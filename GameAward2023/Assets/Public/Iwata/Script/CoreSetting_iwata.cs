using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSetting_iwata : MonoBehaviour
{
    public struct AttachFace
    {
        public Transform Trans;
        public bool isAttach;
        public bool isRelease;
    };

    public enum RotateFlag
    {
        E_ROTATE_FLAG_NULL = 0,
        E_ROTATE_FLAG_X_P,
        E_ROTATE_FLAG_X_M,
        E_ROTATE_FLAG_Y_P,
        E_ROTATE_FLAG_Y_M,

        E_ROTATE_FLAG_Y_MAX
    }
    
    const float ROTATION = 90.0f;   // 回転角度
    const float DAMPING_RATE = 0.5f;   // 回転減衰率
    const float ENLARGE_SiZE = 1.25f;   //選択中のCoreの大きさ
    const float ORIZIN_SiZE = 1.00f;   //選択外のCoreの大きさ

    List<AttachFace> m_attachFaces;	// 組み立てられる面
    List<Transform> hoge;
    int m_SelectFaceNum;     // 選択面の番号
    int m_timeToRotate;             // 回転時間
    float m_rotateY, m_rotateX;     // 角度
    float m_lateY, m_lateX;         // 遅延角度
    public int m_rotateFrameCnt;    // 回転フレームのカウント
    RotateFlag m_rotFlag;           //どっちに回転しているか
    bool m_isDepath;        // 面情報を取得し直すフラグ
    public PlayerController_iwata PController;
    public GameManager GMManager;
    Vector3 RotVectorX;
    static int num = 0;

    //[SerializeReference] AudioClip m_RotSound;  //オーディオファイルの情報
    //AudioSource audioSource;    //再生するためのハンドル

    // Start is called before the first frame update
    void Start()
    {
        m_attachFaces = GetAttachFace();	// 組み立てられる面を取得
        m_SelectFaceNum = 0;
        m_rotateY = m_rotateX = 0.0f;
        m_lateY = m_lateX = 0.0f;

        // 回転時間を計算
        m_timeToRotate = (int)(Mathf.Log(0.00001f) / Mathf.Log(1.0f - DAMPING_RATE));

        //選ばれているCoreを大きくする
        //EnlargeSizeCore();
        m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().PickupSize();


        //再検索が必要な時に立てるFlagを設定
        m_isDepath = false;

        m_rotFlag = RotateFlag.E_ROTATE_FLAG_NULL;

        RotVectorX = this.transform.up;

        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //--- 回転中
        if (m_rotateFrameCnt > 0)
        {
            RotateCore();   // 回転処理			
            return;
        }

        if (m_isDepath)
        {
            ResetAttachFace();
        }
    }

    private void ResetAttachFace()
    {
        m_attachFaces = GetAttachFace();    // 次の組み立てられる面を取得

        if (m_SelectFaceNum > m_attachFaces.Count - 1)
        {
            m_SelectFaceNum = 0;
        }

        // 選択中の面を大きく協調する
        m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().PickupSize();

        m_isDepath = false;
    }

    List<AttachFace> GetAttachFace()
    {
        // 面の格納先を用意
        List<AttachFace> attachFaces = new List<AttachFace>();
        AttachFace TempFace = new AttachFace();

        //--- 組み立てられる面を順番に格納
        foreach (Transform child in this.transform)
        {
            //if (child.tag != "Player") continue;

            // 手前に伸びるレイを用意
            Ray ray = new Ray(child.position, Vector3.back);
            RaycastHit hit;

            // 組み立てられない面はスルー
            // 手前に物があったらスキップ
            if (Physics.Raycast(ray, out hit, 10.0f)) continue;

            //Transformの情報登録
            TempFace.Trans = child;

            //アタッチできる面かを判断するフラグを格納
            if(!child.GetComponent<IsAttachFace_iwata>())
            {
                TempFace.isAttach = true;
            }
            else
            {
                TempFace.isAttach = child.GetComponent<IsAttachFace_iwata>().CanAttach(Vector3.back);
            }

            //取り外せる面かを判断するフラグを格納
            if(child.name.Contains("Core_Child"))
            {
                TempFace.isRelease = false;
            }
            else
            {
                TempFace.isRelease = true;
            }

            attachFaces.Add(TempFace); // 面を格納
        }

        //--- ソート
        attachFaces.Sort((a, b) => {
            if (Mathf.Abs(a.Trans.position.y - b.Trans.position.y) > 0.75f)
            {
                // Y座標が異なる場合はY座標で比較する
                return b.Trans.position.y.CompareTo(a.Trans.position.y);
            }
            else
            {
                // Y座標が同じ場合はX座標で比較する
                return a.Trans.position.x.CompareTo(b.Trans.position.x);
            }
        });

        return attachFaces;
    }

    //void EnlargeSizeCore()
    //{
    //    m_attachFaces[m_SelectFaceNum].Trans.localScale *= ENLARGE_SiZE;
    //}

    //void UndoSizeCore()
    //{
    //    m_attachFaces[m_SelectFaceNum].Trans.localScale = m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().OrizinSize;
    //}

    public void ResetCoreSize()
    {
        Debug.Log(m_attachFaces[m_SelectFaceNum].Trans.name);
        m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().UndoSize();
    }

    public void ChangeFaceX(float axis)
    {
        this.transform.Rotate(-10.0f, 0.0f, 0.0f, Space.World);
        m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().UndoSize();
        Vector3 pos = m_attachFaces[m_SelectFaceNum].Trans.position;
        pos.x += axis;
        for(int i = 0; i < m_attachFaces.Count; i++)
        {
            //--- 現在の面と次の面のXY座標をVector2に格納
            Vector2 currentFacePos = new Vector2(m_attachFaces[i].Trans.position.x, m_attachFaces[i].Trans.position.y);
            Vector2 newxtFacePos = new Vector2(pos.x, pos.y);

            //Debug.Log(m_attachFaces[m_SelectFaceNum].Trans.name + ":" + m_attachFaces[i].Trans.name + " = " + Vector2.Distance(currentFacePos, newxtFacePos) + "(" + (bool)!(Vector2.Distance(currentFacePos, newxtFacePos) > 0.05f) + ")");

            // XY平面での距離が離れすぎていたらスルー
            if (Vector2.Distance(currentFacePos, newxtFacePos) > 0.05f) continue;

            m_SelectFaceNum = i;
            m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().PickupSize();
            this.transform.Rotate(10.0f, 0.0f, 0.0f, Space.World);
            return;
        }

        m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().UndoSize();
        m_rotateY += ROTATION * (int)axis;  // 角度を設定
        m_rotateFrameCnt = 1;	// 最初のカウント
        if(axis < 0)
        {
            m_rotFlag = RotateFlag.E_ROTATE_FLAG_X_M;
            Debug.Log("XM");
        }
        else
        {
            m_rotFlag = RotateFlag.E_ROTATE_FLAG_X_P;
            Debug.Log("XP");
        }
        m_isDepath = true;
        this.transform.Rotate(10.0f, 0.0f, 0.0f, Space.World);
        //audioSource.PlayOneShot(m_RotSound);    //SEの再生
    }

    public void ChangeFaceY(float axis)
    {
        this.transform.Rotate(-10.0f, 0.0f, 0.0f, Space.World);
        m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().UndoSize();
        Vector3 pos = m_attachFaces[m_SelectFaceNum].Trans.position;
        pos.y += axis;
        for (int i = 0; i < m_attachFaces.Count; i++)
        {
            //--- 現在の面と次の面のXY座標をVector2に格納
            Vector2 currentFacePos = new Vector2(m_attachFaces[i].Trans.position.x, m_attachFaces[i].Trans.position.y);
            Vector2 newxtFacePos = new Vector2(pos.x, pos.y);

            // XY平面での距離が離れすぎていたらスルー
            if (Vector2.Distance(currentFacePos, newxtFacePos) > 0.05f) continue;

            m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().UndoSize();
            m_SelectFaceNum = i;
            m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().PickupSize();
            this.transform.Rotate(10.0f, 0.0f, 0.0f, Space.World);
            return;
        }

        m_rotateX -= ROTATION * (int)axis;  // 角度を設定
        m_rotateFrameCnt = 1;   // 最初のカウント
        if (axis < 0)
        {
            m_rotFlag = RotateFlag.E_ROTATE_FLAG_Y_M;
            Debug.Log("YM");
        }
        else
        {
            m_rotFlag = RotateFlag.E_ROTATE_FLAG_Y_P;
            Debug.Log("YP");
        }
        m_isDepath = true;
        this.transform.Rotate(10.0f, 0.0f, 0.0f, Space.World);
        //audioSource.PlayOneShot(m_RotSound);    //SEの再生
    }

    //Coreを回転される
    void RotateCore()
    {
        float lastY = m_lateY;
        float lastX = m_lateX;

        //--- 遅延処理
        m_lateY = (m_rotateY - m_lateY) * DAMPING_RATE + m_lateY;
        m_lateX = (m_rotateX - m_lateX) * DAMPING_RATE + m_lateX;

        //--- 座標計算
        this.transform.Rotate(RotVectorX, m_lateY - lastY, Space.World);
        this.transform.Rotate(Vector3.right, m_lateX - lastX, Space.World);

        m_rotateFrameCnt++; // 回転フレームカウント

        //--- 回転終了時の処理
        if (m_rotateFrameCnt > m_timeToRotate)
        {
            //Transform RotStack = m_attachFaces[m_SelectFaceNum].Trans;

            m_attachFaces = GetAttachFace();    // 次の組み立てられる面を取得
            m_rotateFrameCnt = 0;   // 回転フレームをリセット

            float hogepos;
            int nextnum = 0;
            List<int> selectnum = new List<int>();

            switch (m_rotFlag)
            {
                case RotateFlag.E_ROTATE_FLAG_X_P:
                    hogepos = m_attachFaces[m_SelectFaceNum].Trans.position.y;
                    Debug.Log("target:" + hogepos);
                    for (int i = 0; i < m_attachFaces.Count; i++)
                    {
                        Debug.Log(m_attachFaces[i].Trans.name + ":" + Mathf.Abs(m_attachFaces[i].Trans.position.y - hogepos));

                        //if (m_attachFaces[i].Trans.position.y != hogepos) continue;

                        if (Mathf.Abs(m_attachFaces[i].Trans.position.y - hogepos) > 0.05f) continue;

                        selectnum.Add(i);

                        if (m_attachFaces[nextnum].Trans.position.x >= m_attachFaces[i].Trans.position.x) nextnum = i;
                    }
                    foreach (int child in selectnum)
                    {
                        Debug.Log(child);
                    }
                    break;

                case RotateFlag.E_ROTATE_FLAG_X_M:
                    hogepos = m_attachFaces[m_SelectFaceNum].Trans.position.y;
                    for (int i = 0; i < m_attachFaces.Count; i++)
                    {
                        //if (m_attachFaces[i].Trans.position.y != hogepos) continue;
                        if (Mathf.Abs(m_attachFaces[i].Trans.position.y - hogepos) > 0.05f) continue;

                        selectnum.Add(i);

                        if (m_attachFaces[nextnum].Trans.position.x <= m_attachFaces[i].Trans.position.x) nextnum = i;
                    }
                    foreach (int child in selectnum)
                    {
                        Debug.Log(child);
                    }
                    break;

                case RotateFlag.E_ROTATE_FLAG_Y_P:
                    hogepos = m_attachFaces[m_SelectFaceNum].Trans.position.x;
                    for (int i = 0; i < m_attachFaces.Count; i++)
                    {
                        Debug.Log(m_attachFaces[i].Trans.name + ":" + Mathf.Abs(m_attachFaces[i].Trans.position.x - hogepos));


                        //if (m_attachFaces[i].Trans.position.x != hogepos) continue;
                        if (Mathf.Abs(m_attachFaces[i].Trans.position.x - hogepos) > 0.05f) continue;

                        selectnum.Add(i);

                        if (m_attachFaces[nextnum].Trans.position.y >= m_attachFaces[i].Trans.position.y) nextnum = i;
                    }
                    foreach (int child in selectnum)
                    {
                        Debug.Log(child);
                    }
                    break;

                case RotateFlag.E_ROTATE_FLAG_Y_M:
                    hogepos = m_attachFaces[m_SelectFaceNum].Trans.position.x;
                    for (int i = 0; i < m_attachFaces.Count; i++)
                    {
                        //if (m_attachFaces[i].Trans.position.x != hogepos) continue;
                        if (Mathf.Abs(m_attachFaces[i].Trans.position.x - hogepos) > 0.05f) continue;

                        selectnum.Add(i);

                        if (m_attachFaces[nextnum].Trans.position.y <= m_attachFaces[i].Trans.position.y) nextnum = i;
                    }
                    foreach (int child in selectnum)
                    {
                        Debug.Log(child);
                    }
                    break;
            }


            m_SelectFaceNum = nextnum;

            //---------------------

            m_rotFlag = RotateFlag.E_ROTATE_FLAG_NULL;
            m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().PickupSize();   // 現在の面を協調
        }
    }

    public bool AttachCore(GameObject obj)
    {
        Debug.Log("a");
        if(m_attachFaces[m_SelectFaceNum].isAttach)
        {//組み立てる処理
            Debug.Log("b");
            m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().UndoSize();
            Debug.Log("c");
            obj.GetComponent<JankBase>().JointJank(m_attachFaces[m_SelectFaceNum].Trans);
            Debug.Log("d");
            m_isDepath = true;
            return true;
        }
        else
        {//組み立てられなかったときに鳴らすSE
            Debug.Log("組めないよ！");
            return false;
        }
    }

    public void ReleaseCore()
    {
        if(m_attachFaces[m_SelectFaceNum].isRelease)
        {
            //外す処理
            Debug.Log(m_attachFaces[m_SelectFaceNum].Trans.name + "外した");
            m_attachFaces[m_SelectFaceNum].Trans.GetComponent<SpownJank_iwata>().RemoveCore();
            m_isDepath = true;
        }
        else
        {
            //外せなかったときに鳴らすSE
            Debug.Log(m_attachFaces[m_SelectFaceNum].Trans.name + "外せない");
        }
    }

    public void JointToRot()
    {
        m_attachFaces[m_SelectFaceNum].Trans.GetComponent<JankStatus>().UndoSize();
        Debug.Log(num);
        num++;
        GameObject clone = Instantiate(this.gameObject, new Vector3(-9.0f, 1.5f, -9.0f), Quaternion.identity);
        clone.AddComponent<RotationCore>();
        clone.AddComponent<CloneCoreMove>();
    }

    public void RotToJoint()
    {
        m_isDepath = true;
        this.transform.position = new Vector3(-4.0f, 11.0f, -38.0f);
        this.transform.rotation = Quaternion.identity;
        foreach (Transform child in this.transform)
        {
            child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void RotToPlay()
    {
        foreach (Transform child in this.transform)
        {
            child.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeAll;
        }
    }

    public void PlayToJoint()
    {
        m_isDepath = true;
        this.transform.position = new Vector3(-4.0f, 11.0f, -38.0f);
        this.transform.rotation = Quaternion.identity;
        foreach (Transform child in this.transform)
        {
            child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void PlayToRot()
    {
        Debug.Log("回転初期化");
        this.transform.rotation = Quaternion.identity;
    }

    public Transform SelectFace
    {
        get { return m_attachFaces[m_SelectFaceNum].Trans; }
    }
}

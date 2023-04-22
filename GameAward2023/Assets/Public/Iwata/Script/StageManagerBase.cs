using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerBase : MonoBehaviour
{
    //[SerializeField] private Dictionary<string, GameObject> m_Objects = new Dictionary<string, GameObject>();   //今実行している環境で扱えるオブジェクトを登録

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //foreach (Transform childTransform in transform)
        //{
        //    GameObject childObject = childTransform.gameObject;
        //    string objectName = childObject.name;

        //    // Dictionaryに登録する
        //    m_Objects[objectName] = childObject;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("実際：" + this.transform.childCount);
        //Debug.Log("おｂｊnai ：" + m_Objects.Count);

        //if(this.transform.childCount < m_Objects.Count)
        //{//減った
        //    OnDisable();
        //}
        //else if(this.transform.childCount > m_Objects.Count)
        //{//増えた
        //    OnEnable();
        //}

        //List<string> key = new List<string>();
        //Dictionary<string, GameObject> hoge = Objects;

        //foreach (Transform child in this.transform) //実際にある子オブジェクト
        //{
        //    for(int i = 0; i < hoge.Count; i++)     //Objectsに登録されているもの
        //    {
        //        if(child == hoge.)
        //    }
        //}

        //List<GameObject> obj = new List<GameObject>();
        //foreach(GameObject child in Objects.Values)
        //{
        //    Debug.Log("obj内：" + child.name);
        //    obj.Add(child);
        //}
        //List<GameObject> now = new List<GameObject>();
        //foreach(GameObject child in transform)
        //{
        //    Debug.Log("実際：" + child.name);
        //    now.Add(child);
        //}

        //if(obj != now)
        //{
        //    Objects.Clear();

        //    foreach (Transform childTransform in transform)
        //    {
        //        GameObject childObject = childTransform.gameObject;
        //        string objectName = childObject.name;

        //        // Dictionaryに登録する
        //        m_Objects[objectName] = childObject;
        //    }
        //}        //List<GameObject> obj = new List<GameObject>();
        //foreach(GameObject child in Objects.Values)
        //{
        //    Debug.Log("obj内：" + child.name);
        //    obj.Add(child);
        //}
        //List<GameObject> now = new List<GameObject>();
        //foreach(GameObject child in transform)
        //{
        //    Debug.Log("実際：" + child.name);
        //    now.Add(child);
        //}

        //if(obj != now)
        //{
        //    Objects.Clear();

        //    foreach (Transform childTransform in transform)
        //    {
        //        GameObject childObject = childTransform.gameObject;
        //        string objectName = childObject.name;

        //        // Dictionaryに登録する
        //        m_Objects[objectName] = childObject;
        //    }
        //}
    }

    //public virtual void OnEnable()
    //{

    //    Debug.Log("hueta");

    //    // 子オブジェクトが追加されたときに呼ばれる
    //    foreach (Transform childTransform in transform)
    //    {
    //        GameObject childObject = childTransform.gameObject;
    //        if (!m_Objects.ContainsKey(childObject.name))
    //        {
    //            m_Objects.Add(childObject.name, childObject);
    //            Debug.Log("Add:" + childObject.name);
    //        }
    //    }
    //}

    //public virtual void OnDisable()
    //{

    //    Debug.Log("hetta");

    //    // 子オブジェクトが削除されたときに呼ばれる
    //    List<string> removeKeys = new List<string>();

    //    foreach (KeyValuePair<string, GameObject> kvp in m_Objects)
    //    {
    //        if (kvp.Value == null)
    //        {
    //            removeKeys.Add(kvp.Key);
    //        }
    //    }

    //    foreach (string key in removeKeys)
    //    {
    //        m_Objects.Remove(key);
    //        m_Objects[key] = null;
    //        Debug.Log("Remove:" + key);
    //    }
    //}    //public virtual void OnEnable()
    //{

    //    Debug.Log("hueta");

    //    // 子オブジェクトが追加されたときに呼ばれる
    //    foreach (Transform childTransform in transform)
    //    {
    //        GameObject childObject = childTransform.gameObject;
    //        if (!m_Objects.ContainsKey(childObject.name))
    //        {
    //            m_Objects.Add(childObject.name, childObject);
    //            Debug.Log("Add:" + childObject.name);
    //        }
    //    }
    //}

    //public virtual void OnDisable()
    //{

    //    Debug.Log("hetta");

    //    // 子オブジェクトが削除されたときに呼ばれる
    //    List<string> removeKeys = new List<string>();

    //    foreach (KeyValuePair<string, GameObject> kvp in m_Objects)
    //    {
    //        if (kvp.Value == null)
    //        {
    //            removeKeys.Add(kvp.Key);
    //        }
    //    }

    //    foreach (string key in removeKeys)
    //    {
    //        m_Objects.Remove(key);
    //        m_Objects[key] = null;
    //        Debug.Log("Remove:" + key);
    //    }
    //}

}

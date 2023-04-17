using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : MonoBehaviour
{
	Vector3 m_startPos;
	Quaternion m_startRotate;
	Transform m_startParent;

	JunkSetting m_junkSetting;
	JunkBase m_junkBase;

	// Start is called before the first frame update
	void Start()
    {
		m_startPos = this.transform.position;
		m_startRotate = this.transform.rotation;
		m_startParent = this.transform.parent;

		m_junkSetting = this.GetComponent<JunkSetting>();
		m_junkBase = this.GetComponent<JunkBase>();

		m_junkBase.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (this.transform.parent == null) return;

		if (this.transform.parent.name == "Preview")	m_junkSetting.RotateJunk();
	}

	/// <summary>
	/// 座標・回転・親を初期化
	/// </summary>
	public void ResetTransform()
	{
		this.transform.position = m_startPos;		// 座標
		this.transform.rotation = m_startRotate;    // 回転
		this.transform.SetParent(m_startParent);    // 親

		Rigidbody rigidbody = this.transform.GetComponent<Rigidbody>();
		rigidbody.constraints = RigidbodyConstraints.None;
		rigidbody.isKinematic = false;
	}

	public void StartJunk()
	{
		m_junkSetting.enabled = false;
		m_junkBase.enabled = true;
	}

	public JunkSetting JunkSetting
	{
		get;
	}

	public JunkBase JunkBase
	{
		get;
	}
}
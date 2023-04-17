using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSprings : JunkBase
{
	[SerializeReference] float m_bounceRate;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	/// <summary>
	/// 跳ね返す処理
	/// </summary>
	private void OnCollisionStay(Collision collision)	// 瞬間的に大きな力を加えるとタイヤが取れてしまう為
	{
		//--- 壁と衝突した時の処理
		if (collision.transform.tag == "Wall")
		{
			//--- 反発するベクトルを計算
			Vector3 vToSelf = this.transform.position - collision.contacts[0].point;
			vToSelf.y = 0.0f;	// Y軸方向への移動を無視
			vToSelf = vToSelf.normalized * m_bounceRate;

			// 反発するベクトルを適用
			this.GetComponent<Rigidbody>().AddForce(vToSelf,ForceMode.Impulse);
		}
	}
}
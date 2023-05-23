using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{

    public float fadeTime = 3.0f; // フェードにかける時間（秒）
    private float currentTime = 0.0f; // 現在の経過時間

    private Image BlindFadeImage;
    private float Alpha = 0.0f;
    public bool isFade = false;
    public bool isClear = false;
    // Start is called before the first frame update
    void Start()
    {
        BlindFadeImage = GetComponent<Image>();
        BlindFadeImage.color = new Color(BlindFadeImage.color.r, BlindFadeImage.color.g, BlindFadeImage.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BlindFadeImage.color.a == 0.0f)
        {
            isFade = true;
        }

        if(isFade == true)
        {
            //α値を計算する
            Alpha = Mathf.Clamp01(currentTime / fadeTime);
            
            //カラーの更新
            BlindFadeImage.color = new Color(BlindFadeImage.color.r, BlindFadeImage.color.g, BlindFadeImage.color.b, Alpha);

            // 経過時間を加算する
            currentTime += Time.deltaTime;

            // フェードが完了したらスクリプトを無効化する
            if (BlindFadeImage.color.a == 1.0f)
            {
                isFade = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && BlindFadeImage.color.a >= 0.99f)
        {
            isClear = true;
            currentTime = fadeTime;
        }

        if (isClear == true)
        {
            //α値を計算する
            Alpha = Mathf.Clamp01(currentTime / fadeTime);

            //カラーの更新
            BlindFadeImage.color = new Color(BlindFadeImage.color.r, BlindFadeImage.color.g, BlindFadeImage.color.b, Alpha);

            // 経過時間を加算する
            currentTime -= Time.deltaTime;

            // フェードが完了したらスクリプトを無効化する
            if (BlindFadeImage.color.a == 0.0f)
            {
                isClear = false;
            }
        }
    }
}

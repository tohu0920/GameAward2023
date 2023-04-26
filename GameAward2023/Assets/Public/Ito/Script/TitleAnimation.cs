using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    public Animator animator;
    public float animationTime = 2.0f; //アニメーションを再生する時間
    public bool isPlaying = false; //アニメーションが再生中か判定するフラグ

    void Update()
    {
        
    }

    public void StartAnimetion()
    {
        if (PadInput.GetKeyDown(KeyCode.Joystick1Button1) && isPlaying == false) //条件を「はじめから」or「つづきから」を押されたらに変更する
        {
            animator.Play("AnimationName"); //アニメーションを再生する
            isPlaying = true;
            Invoke("ResetIsPlaying", animationTime); //アニメーションが終了したらフラグをリセットする
        }
    }

    //アニメーションが終了したらフラグをリセットする
    void ResetIsPlaying()
    {
        isPlaying = false;
    }
}








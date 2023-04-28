using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneAnimation : MonoBehaviour
{
    public Animator animator;
    public float animationTime = 2f; //アニメーションを再生する時間
    private bool isPlaying = false; //アニメーションが再生中か判定するフラグ

    void Update()
    {
        
    }

    void StartAnimetion()
    {
        if (Input.GetButtonDown("A") && !isPlaying) //条件を「はじめから」or「つづきから」を押されたらに変更する
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








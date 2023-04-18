using UnityEngine;

public class MovingEffect : MonoBehaviour
{
    public float speed = 1f;
    public float resetPosition = -20f;
    public float startingPosition = 20f;

    private Vector3 currentPosition;

    private void Start()
    {
        // エフェクトの初期位置を設定する
        currentPosition = transform.position;
        currentPosition.x = startingPosition;
        transform.position = currentPosition;
    }

    private void Update()
    {
        // エフェクトを左に動かす
        currentPosition.x -= speed * Time.deltaTime;
        transform.position = currentPosition;

        // 画面外に出たら、右端に戻す
        if (transform.position.x < resetPosition)
        {
            currentPosition.x = startingPosition;
            transform.position = currentPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRoad : MonoBehaviour
{
    private Countdown countdown; // Countdownスクリプトへの参照を追加
    public float moveSpeed = 3f; // 前進速度
    public float acceleration = 0.01f; // 加速
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // このGameObjectにアタッチされているRigidbodyコンポーネントを取得
        GameObject gameManagerObj = GameObject.Find("GameManager"); // GameManagerオブジェクトを取得
        countdown = gameManagerObj.GetComponent<Countdown>(); // Countdownスクリプトを取得
        
    }


    void Update()
    {
        if (countdown != null && countdown.start) // カウントダウンが終了したかどうか
        {
            
            //-----------------移動、ジャンプのスクリプト----------------------
            transform.Translate(Vector3.forward * UnityEngine.Time.deltaTime * moveSpeed, Space.World);
            moveSpeed += UnityEngine.Time.deltaTime * acceleration;
        }
    }
   void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject); // 触れたすべてのオブジェクトを破壊
        Debug.Log($"{collision.gameObject.name}オブジェクトを破壊しました");
    }
}

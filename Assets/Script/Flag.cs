using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private tTime ttime; // Time スクリプトへの参照を追加
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager"); // GameManagerオブジェクトを取得
        ttime = gameManagerObj.GetComponent<tTime>(); // Timeスクリプトを取得
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            Debug.Log("旗に触れる");
            ttime.ResetCountdown(); // カウントダウンをリセット
            Destroy(this.gameObject);
        }
    }
}
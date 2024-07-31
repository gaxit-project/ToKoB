using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private HPDecrease hpDecrease; // HPDecrease スクリプトへの参照を追加

    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager"); // GameManagerオブジェクトを取得
        hpDecrease = gameManagerObj.GetComponent<HPDecrease>(); // HPDecreaseスクリプトを取得
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("障害物に触れる");
            StartCoroutine(hpDecrease.DestroyImagesCoroutine()); // 画像破壊コルーチン
            Destroy(this.gameObject);
        }
    }
}

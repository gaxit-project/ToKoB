using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TatchTonWall : MonoBehaviour
{
    private HPDecrease hpDecrease; // HPDecrease スクリプトへの参照を追加

    public bool OneCount;　//1カウントするためのブール

    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TonnWall" /*&& OneCount == true*/)
        {
            Debug.Log("壁に衝突！");
            this.transform.position = new Vector3(0, transform.position.y, transform.position.z);
            //StartCoroutine(hpDecrease.DestroyImagesCoroutine()); // 画像破壊コルーチン
            //OneCount = false;
        }
        /*else if (collision.gameObject.tag == "TonnOut")
        {
            OneCount = true;
        }*/
    }

    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager"); // GameManagerオブジェクトを取得
        hpDecrease = gameManagerObj.GetComponent<HPDecrease>(); // HPDecreaseスクリプトを取得
        OneCount = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

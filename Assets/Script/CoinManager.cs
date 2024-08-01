using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public CoinScript target;
    //public TextMesh Coin管理;
    public TextMeshProUGUI CountCoinText;

    private int CoinCount;　//コインのカウント
    public bool OneCount;　//1カウントするためのブール

    // Start is called before the first frame update
    void OnDisable()
    {
        target.OnDestroyed.RemoveAllListeners();
    }

    void OnEnable()　//鍵を取った際スクリプトがつけられたオブジェクトの処理
    {
        target.OnDestroyed.AddListener(() => {
            if (OneCount)
            {
                HowMuchCoin();
                Debug.Log("コインカウント！");
            }
            //Destroy(gameObject, 0.0f);
            //CloseDoor.SetActive(false);   // 無効にする
        });
    }

    public void HowMuchCoin()
    {
        OneCount = false;                                                                              //ターンのカウントを複数回行わないようにするため
        CoinCount++;                                                                                       //ターンをカウント
        Debug.Log(CoinCount);
        CountCoinText.text = "Score : " + CoinCount.ToString();
        StartCoroutine("ReCoinCountCoroutine");
    }

    IEnumerator ReCoinCountCoroutine()　//エネミーのターンの終了、終了後の処理を行うコルーチン
    {
        //ここに処理を書く
        Debug.Log("修正中");


        //1フレーム停止
        yield return new WaitForSeconds(0.5f);　//0.5f時間をストップ

        //ここに再開後の処理を書く
        OneCount = true;
        //Debug.Log("ターンエンド！");

    }

    void Start()
    {
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinGet : MonoBehaviour
{
    public TextMeshProUGUI CountCoinText;

    public static int CoinCount;　//コインのカウント
    public bool OneCount;　//1カウントするためのブール

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            HowMuchCoin();
        }
        else if (collision.gameObject.tag == "TsujinoTest")
        {
            SceneManager.LoadScene("Clear");
        }
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

    // Start is called before the first frame update
    void Start()
    {
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
